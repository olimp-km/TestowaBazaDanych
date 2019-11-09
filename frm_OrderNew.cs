using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestowaBazaDanych
{
    public partial class frm_OrderNew : Form
    {
        private bool AddMode;
        private DataRow OrderRow;

        public frm_OrderNew(bool addMode, ref DataRow currentRow)
        {
            InitializeComponent();
            this.AddMode = addMode;
            this.OrderRow = currentRow;
        }

        private void Frm_CustomerNew_Load(object sender, EventArgs e)
        {

            if (AddMode) {
                Text = "Dodanie nowego klienta";
            } else {
                Text = "Edycja danych klienta";

                dtOrderDate.Value = OrderRow.Field<DateTime>("OrderDate");
                txtInvoice.Text = OrderRow.Field<string>("Invoice");
                chkPaymend.Checked = (OrderRow.Field<int>("Paymend") == 1);
                txtPrice.Text = OrderRow.Field<decimal>("Price").ToString(CultureInfo.CurrentUICulture);
            }
        }

        private void Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            char sep = CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator[0];

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != sep)
            {
                e.Handled = true;
            }
            TextBox txtDec = sender as TextBox;
            if (e.KeyChar == sep && txtDec.Text.Contains(sep))
            {
                e.Handled = true;
            }
        }

        private void CmdAccept_Click(object sender, EventArgs e)
        {
            OrderRow.SetField<DateTime>("OrderDate", dtOrderDate.Value);
            OrderRow.SetField<string>("Invoice", txtInvoice.Text);
            if (chkPaymend.Checked)
                OrderRow.SetField<int>("Paymend", 1);
            else
                OrderRow.SetField<int>("Paymend", 0);
            float Price;
            float.TryParse(txtPrice.Text,out Price);
            OrderRow.SetField<float>("Price", Price);
            DialogResult = DialogResult.OK;
        }

        private void cmdReject_Click(object sender, EventArgs e)
        {
            if (OrderRow != null)
            {
                OrderRow.RejectChanges();
            }
            DialogResult = DialogResult.Cancel;
        }
    }
}
