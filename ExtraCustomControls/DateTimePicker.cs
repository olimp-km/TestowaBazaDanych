//----------------------------------------------------------------------------------
// - Author			   - Pham Minh Tri
// - Last Updated      - 19/Nov/2003
//----------------------------------------------------------------------------------
// - Component:        - Nullable DateTimePicker
// - Version:          - 1.0
// - Description:      - A datetimepicker that allow null value.
//----------------------------------------------------------------------------------

using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace ExtraCustomControls
{
	/// <summary>
	/// Summary description for DateTimePicker.
	/// </summary>
	public class DateTimePicker : System.Windows.Forms.DateTimePicker   
	{
		private DateTimePickerFormat oldFormat = DateTimePickerFormat.Long;
		private string oldCustomFormat = null;
		private bool bIsNull = false;

		/// <summary>
        /// 
        /// </summary>
        public DateTimePicker() : base()
		{
        }

        /// <summary>
        /// 
        /// </summary>
        public Object ValueDate 
		{
			get 
			{
                if (bIsNull)
                    return DBNull.Value;
				else
					return base.Value;
			}
			set 
			{
				if ((value == DBNull.Value) || (value == null))
				{
                    if (bIsNull == false) 
					{
						oldFormat = this.Format;
						oldCustomFormat = this.CustomFormat;
						bIsNull = true;
					}

					this.Format = DateTimePickerFormat.Custom;
					this.CustomFormat = " ";
				}
				else 
				{
                    if (bIsNull) 
					{
						this.Format = oldFormat;
						this.CustomFormat = oldCustomFormat;
						bIsNull = false;
					}
                    base.Value = (DateTime)value;
				}
			}
		}

		/// <summary>
        /// 
        /// </summary>
        /// <param name="eventargs"></param>
        protected override void OnCloseUp(EventArgs eventargs)
		{
			if (Control.MouseButtons == MouseButtons.None) 
			{
				if (bIsNull) 
				{
					this.Format = oldFormat;
					this.CustomFormat = oldCustomFormat;
					bIsNull = false;
				}
			}
			base.OnCloseUp (eventargs);
		}

		/// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown (e);

            if (e.KeyCode == Keys.Delete) 
            {
                this.Format = DateTimePickerFormat.Custom;
                this.CustomFormat = " ";
                bIsNull = true;
            }
			//	this.Value = DateTime.MinValue; 
		}
	}
}
