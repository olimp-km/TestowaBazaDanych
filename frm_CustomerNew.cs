using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestowaBazaDanych
{
    public partial class frm_CustomerNew : Form
    {
        private bool AddMode;
        private DataRow CustomerRow;

          public frm_CustomerNew(bool addMode, ref DataRow currentRow)
        {
            InitializeComponent();
            this.AddMode = addMode;
            this.CustomerRow = currentRow;
        }

        private void Frm_CustomerNew_Load(object sender, EventArgs e)
        {
            cboStates.MaxDropDownItems = 4;
            cboStates.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStates.DataSource = frm_main.dtState;
            cboStates.ValueMember = "name";
            cboStates.DisplayMember = "name";

            if (AddMode) {
                Text = "Dodanie nowego klienta";
            } else {
                Text = "Edycja danych klienta";

                txtFirstName.Text = CustomerRow.Field<string>("FirstName");
                txtSecondName.Text = CustomerRow.Field<string>("LastName");
                txtAddress.Text = CustomerRow.Field<string>("Address");
                txtCity.Text = CustomerRow.Field<string>("City");
                cboStates.Text = CustomerRow.Field<string>("State");
                txtZipCode.Text = CustomerRow.Field<string>("ZipCode");
                txtAccountNumber.Text = CustomerRow.Field<string>("AccountNumber");
            }
        }

        private void CmdAccept_Click(object sender, EventArgs e)
        {
            CustomerRow.SetField<string>("FirstName", txtFirstName.Text);
            CustomerRow.SetField<string>("LastName", txtSecondName.Text);
            CustomerRow.SetField<string>("Address", txtAddress.Text);
            CustomerRow.SetField<string>("City", txtCity.Text);
            CustomerRow.SetField<string>("State", cboStates.Text);
            CustomerRow.SetField<string>("ZipCode", txtZipCode.Text);
            CustomerRow.SetField<string>("AccountNumber", txtAccountNumber.Text);
            DialogResult = DialogResult.OK;
        }

        private void cmdReject_Click(object sender, EventArgs e)
        {
            if (CustomerRow != null)
            {
                CustomerRow.RejectChanges();
            }
            DialogResult = DialogResult.Cancel;
        }
    }
}
