using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace ExtraCustomControls
{
    public partial class currencyTextBox : TextBox
    {
        private decimal _WorkingValue;
        private CultureInfo culture;

        private void InitializeSetValue()
        {
            this.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.NumberFormat.CurrencySymbol = "";
            // - ustawienia formatowania tekstu
            _WorkingValue = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        public currencyTextBox()
        {
            InitializeComponent();
            InitializeSetValue();
        }

        /// <summary>
        /// opis ....
        /// </summary>
        /// <param name="container"></param>
        public currencyTextBox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            InitializeSetValue();
        }

        /// <summary>
        /// separator tysiêczny
        /// </summary>
        public string ThousandsSeparator
        {
            get { return culture.NumberFormat.NumberGroupSeparator; }
            set { culture.NumberFormat.NumberGroupSeparator = value; }
        }

        /// <summary>
        /// separator czêœci ca³kowitej i dziesiêtnej
        /// </summary>
        public string DecimalsSeparator
        {
            get
            {
                return culture.NumberFormat.CurrencyDecimalSeparator;
            }
            set
            {
                culture.NumberFormat.CurrencyDecimalSeparator = value;
                culture.NumberFormat.NumberDecimalSeparator = value;
            }
        }

        /// <summary>
        /// iloœæ miejsc po przecinku
        /// </summary>
        public int DecimalPlaces
        {
            get { return culture.NumberFormat.CurrencyDecimalDigits; }
            set
            {
                culture.NumberFormat.CurrencyDecimalDigits = value;
                culture.NumberFormat.NumberDecimalDigits = value;
            }
        }

        /// <summary>
        /// wartoœæ
        /// </summary>
        public decimal ValueDouble
        {
            get { return _WorkingValue; }
            set
            {
                _WorkingValue = value;
                this.Text = String.Format(culture, "{0:C" + culture.NumberFormat.CurrencyDecimalDigits.ToString() + "}", _WorkingValue);
            }
        }

        /// <summary>
        /// przy uzyskaniu aktywnoœci
        /// </summary>
        protected override void OnGotFocus(EventArgs e)
        {
            this.Text = String.Format(culture, "{0:F" + culture.NumberFormat.CurrencyDecimalDigits.ToString() + "}", _WorkingValue);
            if (this.Text.Length > 0)
            {
                this.SelectionStart = this.Text.Length;
                this.SelectionLength = 0;
            }
            base.OnGotFocus(e);
        }

        /// <summary>
        /// przy utracie aktywnoœci
        /// </summary>
        protected override void OnLostFocus(EventArgs e)
        {
            this.Text = String.Format(culture, "{0:C" + culture.NumberFormat.CurrencyDecimalDigits.ToString() + "}", _WorkingValue);
            base.OnLostFocus(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            bool isValid = false;

            StringBuilder strNew = new StringBuilder(this.Text);
            strNew.Insert(this.SelectionStart, e.KeyChar);
            try
            {
                Convert.ToDecimal(strNew.ToString());
                isValid = true;
            }
            catch {
                isValid = false;
            }

            // pierwszym znakiem mo¿e byæ minus
            if ((e.KeyChar == '-') && (_WorkingValue >= 0) && (this.SelectionStart == 0)) isValid = true;

            bool isDecimalSeparate = false;
            char[] charArray = strNew.ToString().ToCharArray();

            StringBuilder strBefore = new StringBuilder();
            StringBuilder strAfter = new StringBuilder();

            // rozdziel ci¹g na czêœæ ca³kowit¹ i dziesi¹tn¹ 
            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i].ToString() == culture.NumberFormat.NumberDecimalSeparator)
                    isDecimalSeparate = true;
                else
                if (isDecimalSeparate)
                    strAfter.Append(charArray.GetValue(i));
                else
                if (Char.IsDigit(charArray[i]))
                    strBefore.Append(charArray.GetValue(i));
            }

            // czy czeœæ dziesiêtna nie jest za d³uga
            if (
                 (Char.IsDigit(e.KeyChar))
                 &&
                 (culture.NumberFormat.NumberDecimalDigits > 0)
                 &&
                 (strAfter.Length > culture.NumberFormat.CurrencyDecimalDigits)
               )
                isValid = false;

            if (isValid == false)
            {
                if (!(e.KeyChar == Convert.ToChar(Keys.Back)))
                    e.Handled = true;
            }
            base.OnKeyPress(e);
        }

        // - gdy tekst ulega zmianie
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        protected override void OnTextChanged(System.EventArgs args)
        {
            // - jaka to jest wartoœæ
            try
            {
                _WorkingValue = Convert.ToDecimal(this.Text);
            }
            catch { }
            base.OnTextChanged(args);
        }
    }
}
