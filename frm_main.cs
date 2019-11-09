using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DataGridViewCustomization;
using System.Resources;
using ExtensionMethods;

namespace TestowaBazaDanych
{
    public partial class frm_main : Form
    {
        string connectString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=MasterDetailSimple;Data Source=localhost";
        SqlConnection connection;
        DataSet ds;

        // - Województwo
        SqlDataAdapter daState;
        //BindingSource bsState;
        public static DataTable dtState;

        // - Klient
        SqlDataAdapter daCustomer;
        BindingSource bsCustomer;
        DataTable dtCustomer;
        // - Zamówienia
        SqlDataAdapter daOrder;
        BindingSource bsOrder;
        DataTable dtOrder;

        public frm_main()
        {
            InitializeComponent();
        }

        private void But_connect_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectString);
            connection.Open();
            //MessageBox.Show(connection.State.ToString());

            ds = new DataSet("Northwind");

            SqlCommand command;
            daState = new SqlDataAdapter();
            command = new SqlCommand("Select * From State", connection);
            daState.SelectCommand = command;

            dtState = ds.Tables.Add("State");
            daState.Fill(dtState);


            daCustomer = new SqlDataAdapter();
            
            // - SELECT
            command = new SqlCommand("Select ':)' as Etykieta,* From Customer", connection);
            daCustomer.SelectCommand = command;
            // - INSERT
            command = new SqlCommand("INSERT INTO Customer (FirstName,LastName,Address,City,State,ZipCode,AccountNumber) VALUES (@FirstName,@LastName,@Address,@City,@State,@ZipCode,@AccountNumber)", connection);
            //command.Parameters.Add("@id", SqlDbType.Int, 0, "id");
            command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 40, "FirstName");
            command.Parameters.Add("@LastName", SqlDbType.NVarChar, 40, "LastName");
            command.Parameters.Add("@Address", SqlDbType.NVarChar, 40, "Address");
            command.Parameters.Add("@City", SqlDbType.NVarChar, 40, "City");
            command.Parameters.Add("@State", SqlDbType.NVarChar, 40, "State");
            command.Parameters.Add("@ZipCode", SqlDbType.NVarChar, 40, "ZipCode");
            command.Parameters.Add("@AccountNumber", SqlDbType.NVarChar, 40, "AccountNumber");
            daCustomer.InsertCommand = command;
            // - UPDATE
            command = new SqlCommand("UPDATE Customer SET FirstName = @FirstName, LastName = @LastName, Address = @Address, City = @City, State = @State, ZipCode = @ZipCode, AccountNumber = @AccountNumber WHERE id = @oldid", connection);
            //command.Parameters.Add("@id", SqlDbType.NChar, 5, "id");
            command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 40, "FirstName");
            command.Parameters.Add("@LastName", SqlDbType.NVarChar, 40, "LastName");
            command.Parameters.Add("@Address", SqlDbType.NVarChar, 40, "Address");
            command.Parameters.Add("@City", SqlDbType.NVarChar, 40, "City");
            command.Parameters.Add("@State", SqlDbType.NVarChar, 40, "State");
            command.Parameters.Add("@ZipCode", SqlDbType.NVarChar, 40, "ZipCode");
            command.Parameters.Add("@AccountNumber", SqlDbType.NVarChar, 40, "AccountNumber");
            SqlParameter parameter = command.Parameters.Add("@oldid", SqlDbType.Int, 0, "id");
            parameter.SourceVersion = DataRowVersion.Original;
            daCustomer.UpdateCommand = command;
            // - DELETE
            command = new SqlCommand("DELETE FROM Customer WHERE id = @id", connection);
            // Add the parameters for the DeleteCommand.
            parameter = command.Parameters.Add("@id", SqlDbType.Int, 0, "id");
            parameter.SourceVersion = DataRowVersion.Original;
            daCustomer.DeleteCommand = command;

            dtCustomer = ds.Tables.Add("Customer");
            daCustomer.Fill(dtCustomer);
            
            bsCustomer = new BindingSource();
            bsCustomer.DataSource = dtCustomer;
            //bsCustomer.CurrentChanged += new EventHandler(Current_Changed);

            GridCustomer.AutoSize = false;
            GridCustomer.DataSource = bsCustomer;
            NavigatorCustomer.BindingSource = bsCustomer;

            GridCustomer.Use(p =>
            {
                p.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                p.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                p.ColumnHeadersDefaultCellStyle.BackColor = Color.Yellow;
                p.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                p.EnableHeadersVisualStyles = false;
                p.AutoGenerateColumns = false;
                p.Columns.Clear();
                int iCol;
                iCol = p.Columns.Add("col_FirstName", "Imię");
                p.Columns[iCol].DataPropertyName = "FirstName";
                iCol = p.Columns.Add("col_LastName", "Nazwisko");
                p.Columns[iCol].DataPropertyName = "LastName";
                iCol = p.Columns.Add("col_Address", "Ulica");
                p.Columns[iCol].DataPropertyName = "Address";
                iCol = p.Columns.Add("col_City", "Miejscowość");
                p.Columns[iCol].DataPropertyName = "City";

                //iCol = p.Columns.Add("col_State", "Województwo");
                //p.Columns[iCol].DataPropertyName = "State";

                DataGridViewComboBoxColumn cb = new DataGridViewComboBoxColumn();
                cb.HeaderText = "Województwo";
                cb.DataPropertyName = "State";
                cb.Name = "col_State";
                cb.MaxDropDownItems = 4;
                cb.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                //cb.Items.Add("Śląskie");
                //cb.Items.Add("Małopolskie");
                cb.DataSource = dtState;
                cb.ValueMember = "name";
                cb.DisplayMember = "name";
                p.Columns.Add(cb);

                iCol = p.Columns.Add("col_ZipCode", "Kod pocztowy");
                p.Columns[iCol].DataPropertyName = "ZipCode";
                iCol = p.Columns.Add("col_AccountNumber", "Nr konta");
                p.Columns[iCol].DataPropertyName = "AccountNumber";
                //p.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            });
            
            daOrder = new SqlDataAdapter();
            // - SELECT
            command = new SqlCommand("Select * From Orders", connection);
            daOrder.SelectCommand = command;
            // - INSERT
            command = new SqlCommand("INSERT INTO ORDERS (CustomerId,OrderDate,Invoice,Paymend,Price) VALUES (@CustomerId,@OrderDate,@Invoice,@Paymend,@Price)", connection);
            command.Parameters.Add("@CustomerId", SqlDbType.Int, 0, "CustomerId");
            command.Parameters.Add("@OrderDate", SqlDbType.Date, 0, "OrderDate");
            command.Parameters.Add("@Invoice", SqlDbType.NVarChar, 100, "Invoice");
            command.Parameters.Add("@Paymend", SqlDbType.Int, 0, "Paymend");
            command.Parameters.Add("@Price", SqlDbType.Money, 0, "Price");
            daOrder.InsertCommand = command;
            // - UPDATE
            command = new SqlCommand("UPDATE ORDERS SET OrderDate = @OrderDate, Invoice = @Invoice, Paymend = @Paymend, Price = @Price WHERE id = @oldid", connection);
            command.Parameters.Add("@OrderDate", SqlDbType.Date, 0, "OrderDate");
            command.Parameters.Add("@Invoice", SqlDbType.NVarChar, 100, "Invoice");
            command.Parameters.Add("@Paymend", SqlDbType.Int, 0, "Paymend");
            command.Parameters.Add("@Price", SqlDbType.Money, 0, "Price");
            parameter = command.Parameters.Add("@oldid", SqlDbType.Int, 0, "id");
            parameter.SourceVersion = DataRowVersion.Original;
            daOrder.UpdateCommand = command;
            // - DELETE
            command = new SqlCommand("DELETE FROM ORDERS WHERE id = @id", connection);
            // Add the parameters for the DeleteCommand.
            parameter = command.Parameters.Add("@id", SqlDbType.Int, 0, "id");
            parameter.SourceVersion = DataRowVersion.Original;
            daOrder.DeleteCommand = command;

            dtOrder = ds.Tables.Add("Orders");
            daOrder.Fill(dtOrder);

            DataRelation relCustOrder = new DataRelation("CustomersOrders", dtCustomer.Columns["id"], dtOrder.Columns["customerID"]);
            // Add the relation to the DataSet.
            ds.Relations.Add(relCustOrder);

            bsOrder = new BindingSource();
            bsOrder.DataSource = bsCustomer;
            bsOrder.DataMember = "CustomersOrders";

            // --
            NavigatorOrder.BindingSource = bsOrder;

            GridOrder.Use(p =>
            {
                p.DataSource = bsOrder;
                p.AutoSize = false;
                p.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                p.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                p.ColumnHeadersDefaultCellStyle.BackColor = Color.Yellow;
                p.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                p.EnableHeadersVisualStyles = false;
                p.AutoGenerateColumns = false;
                p.Columns.Clear();
                //p.Columns.Add("OrderDate", "Data zamówienia");
                DataGridViewColumn col1 = new DataGridViewTextBoxColumn();
                col1.DataPropertyName = "Invoice";
                col1.Name = "Invoice";
                col1.HeaderText = "Nr paragonu";
                col1.ValueType = typeof(string);
                p.Columns.Add(col1);
                col1.Dispose();
                //DataGridViewColumn col2 = new DataGridViewTextBoxColumn();
                CalendarColumn col2 = new CalendarColumn();
                col2.DataPropertyName = "OrderDate";
                col2.Name = "OrderDate";
                col2.HeaderText = "Data zamówienia";
                col2.ValueType = typeof(DateTime);
                p.Columns.Add(col2);
                col2.Dispose();
                DataGridViewCheckBoxColumn chbox = new DataGridViewCheckBoxColumn();
                chbox.DataPropertyName = "Paymend";
                chbox.Name = "Paymend";
                chbox.HeaderText = "Czy zapłacone";
                chbox.ValueType = typeof(int);
                p.Columns.Add(chbox);

                DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
                col4.DataPropertyName = "Price";
                col4.Name = "Price";
                col4.HeaderText = "Kwota";
                col4.ValueType = typeof(float);
                col4.DefaultCellStyle.Format = "c";
                p.Columns.Add(col4);

                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img.Name = "Image";
                img.HeaderText = "Ikona";
                img.ValuesAreIcons = true;
                p.Columns.Add(img);

            });
            ControlsStat();
        }

        private object CustomerField(string FieldName)
        {
            DataRowView row = (DataRowView)bsCustomer.Current;
            for (int iii=0; iii< row.Row.Table.Columns.Count; iii++)
                if (row.Row.Table.Columns[iii].ColumnName == FieldName)
                    return row.Row[iii];
            return null;
        }

        private void btn_CustomerAdd_Click(object sender, EventArgs e)
        {
            DataRow RowCustomer = (bsCustomer.AddNew() as DataRowView).Row;
            try
            {
                frm_CustomerNew frm = new frm_CustomerNew(true, ref RowCustomer);
                if (frm.ShowDialog() == DialogResult.OK) {
                    dtCustomer.Rows.Add(RowCustomer);
                    Action_DbSave();
                }
            } catch (System.Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_CustomerMod_Click(object sender, EventArgs e)
        {
            DataRow RowCustomer = ((DataRowView)bsCustomer.Current).Row;
            try {
                frm_CustomerNew frm = new frm_CustomerNew(false, ref RowCustomer);
                if (frm.ShowDialog() == DialogResult.OK) {
                    Action_DbSave();
                }
            } catch (System.Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_CustomerDel_Click(object sender, EventArgs e)
        {
            DataRow RowCustomer = ((DataRowView)bsCustomer.Current).Row;

            DialogResult dialogResult = MessageBox.Show(String.Format("Czy usunąć klienta {0}{1} ? ", RowCustomer.Field<string>("FirstName"), RowCustomer.Field<string>("LastName")), "Pytanie", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                RowCustomer.Delete();
                Action_DbSave();
            }
        }

        private void btn_OrderAdd_Click(object sender, EventArgs e)
        {
            DataRow RowOrder = (bsOrder.AddNew() as DataRowView).Row;

            //DataRow RowCustomer = ((DataRowView)bsCustomer.Current).Row;
            //DataRow RowOrder = dtOrder.NewRow();
            //RowOrder.SetField<int>("CustomerID", RowCustomer.Field<int>("id"));
            try
            {
                frm_OrderNew frm = new frm_OrderNew(true, ref RowOrder);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dtOrder.Rows.Add(RowOrder);
                    Action_DbSave();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_OrderMod_Click(object sender, EventArgs e)
        {
            DataRow RowOrder = ((DataRowView)bsOrder.Current).Row;
            try
            {
                frm_OrderNew frm = new frm_OrderNew(false, ref RowOrder);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Action_DbSave();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_OrderDel_Click(object sender, EventArgs e)
        {
            DataRow RowOrder = ((DataRowView)bsOrder.Current).Row;

            DialogResult dialogResult = MessageBox.Show(String.Format("Czy usunąć zamówienie {0} z dnia {1} ? ", RowOrder.Field<string>("Invoice"), RowOrder.Field<DateTime>("OrderDate").ToString()), "Pytanie", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                RowOrder.Delete();
                Action_DbSave();
            }
        }


        private void But_refresh_Click(object sender, EventArgs e)
        {
            Action_DbRefresh(0);
            GridCustomer.DataSource = bsCustomer;
        }


        private void DataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            Color color;
            if ((e.RowIndex % 2) == 0) {
                color = System.Drawing.ColorTranslator.FromHtml("#c0c0c0");
            } else {
                color = System.Drawing.ColorTranslator.FromHtml("#fffff0");
            }
            // pokoloruj 
            for (int iii = 0; iii < ((DataGridView)sender).Rows[e.RowIndex].Cells.Count; iii++)
            {
                ((DataGridView)sender).Rows[e.RowIndex].Cells[iii].Style.BackColor = color;
            }

        }


        private void btn_Save_Click(object sender, EventArgs e)
        {
            Action_DbSave();
            GridCustomer.Refresh();
            GridOrder.Refresh();
        }

        //
        // --- (B) Metody publiczne
        //

        //
        // --- (B) Metody prywatne
        //

        // - zapisuje zmiany 
        private void Action_DbSave()
        {
            Action_DbSaveTable(ds, dtOrder, daOrder, bsOrder);
            Action_DbSaveTable(ds, dtCustomer, daCustomer, bsCustomer);
        }

        private void Action_DbSaveTable(DataSet ds, DataTable dt, SqlDataAdapter da, BindingSource bs) 
        {
            // określ co zostało wykonane
            Boolean isChange;
            DataTable Added    = dt.GetChanges(DataRowState.Added);
            DataTable Modified = dt.GetChanges(DataRowState.Modified); 
            DataTable Deleted  = dt.GetChanges(DataRowState.Deleted);
            isChange = ((Added != null) || (Modified != null) || (Deleted != null));

            if (isChange)
            try
            {
                bs.EndEdit();
                if (Deleted  != null) da.Update(Deleted);
                if (Modified != null) da.Update(Modified);
                if (Added    != null) da.Update(Added);
                // zatwierdź zmiany
                ds.AcceptChanges();
                if (Added != null)
                {
                    SqlCommand cmd = new SqlCommand("SELECT CAST(@@IDENTITY AS int)", connection);
                    int NewID = (int)cmd.ExecuteScalar();
                    dtOrder.Clear();
                    daOrder.Fill(dtOrder);
                    int foundPosition = bsOrder.Find("id", NewID);
                    if (foundPosition > -1) bsOrder.Position = foundPosition;
                }
                    MessageBox.Show("Zapis zakończony sukcesem " + dt.TableName);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            // zwolnij zasoby
            if (Added    != null) Added.Dispose();
            if (Modified != null) Modified.Dispose();
            if (Deleted  != null) Deleted.Dispose();
        }


        private void Action_DbRefresh(Object oKey)
        {
            int pKey = oKey.ToInt32OrDefault(0);
            if (pKey == 0) 
              pKey = CustomerField("id").ToInt32OrDefault(0);
            
            bsCustomer.ResetBindings(true);
            dtOrder.Clear();
            dtCustomer.Clear();
            daCustomer.Fill(dtCustomer);
            daOrder.Fill(dtOrder);

            if (pKey != 0)
            {
                int foundPosition = bsCustomer.Find("id", pKey);
                if (foundPosition > -1)
                {
                    bsCustomer.Position = foundPosition;
                }
            }
        }

        private void GridCustomer_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            GridCustomer.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void GridOrder_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            GridOrder.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void GridOrder_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Coś nie tak: " + e.ToString());
        }

        private void GridOrder_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (GridOrder.Columns[e.ColumnIndex].Name == "OrderDate") {

                DateTime dt;
                if (! DateTime.TryParse(e.FormattedValue.ToString(), out dt))   {
                    GridOrder.Rows[e.RowIndex].ErrorText ="Wprowadzona wartość '" + e.FormattedValue.ToString() + "' nie jest datą !";
                    e.Cancel = true;
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CalendarColumn col = new CalendarColumn();
            this.GridOrder.Columns.Add(col);
            //this.GridOrder.RowCount = 5;
            foreach (DataGridViewRow row in this.GridOrder.Rows)
            {
                row.Cells[0].Value = DateTime.Now;
            }

        }

        private void GridOrder_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((GridOrder.Columns[e.ColumnIndex].Name == "Image") && (GridOrder.Rows[e.RowIndex].Tag == null))
            {
                Icon ic;
                double Price = GridOrder.Rows[e.RowIndex].Cells["Price"].Value.ToDoubleOrDefault(0);
                int Paymend = GridOrder.Rows[e.RowIndex].Cells["Paymend"].Value.ToInt32OrDefault(0);
                
                if (GridOrder.Rows[e.RowIndex].IsNewRow)
                  ic = TestowaBazaDanych.Properties.Resources.empty;
                else 
                if ((Price > 0) && (Paymend == 1))
                  ic = TestowaBazaDanych.Properties.Resources.pass;
                else
                  ic = TestowaBazaDanych.Properties.Resources.alarm;

                GridOrder.Rows[e.RowIndex].Cells["Image"].Value = ic;
                GridOrder.Rows[e.RowIndex].Tag = 1;
            }
        }

        // Give the button a transparent background.
        private void MakeButtonTransparent(Button btn)
        {
            Bitmap bm = (Bitmap)btn.Image;
            bm.MakeTransparent(bm.GetPixel(0, 0));
        }

        private void GridOrder_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // - sprawdzenie podczas edycji
            e.Control.KeyPress -= new KeyPressEventHandler(colPrice_KeyPress);
            if (GridOrder.Columns[GridOrder.CurrentCell.ColumnIndex].DataPropertyName == "Price")  { 
                e.Control.KeyPress += new KeyPressEventHandler(colPrice_KeyPress);
            }
        }

        //Price Column keypress only accept numbers
        private void colPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
            TextBox txtDec = sender as TextBox;
            if (e.KeyChar == ',' && txtDec.Text.Contains(","))
            {
                e.Handled = true;
            }
        }

        private void ControlsStat()
        {
            Boolean isCoonect = (ds != null);
            Boolean isCustomer = (dtCustomer != null);
            Boolean isOrdder = (dtOrder != null);

            btn_CustomerAdd.Enabled = isCustomer;
            btn_CustomerMod.Enabled = isCustomer;
            btn_CustomerDel.Enabled = isCustomer;

            btn_OrderAdd.Enabled = isOrdder;
            btn_OrderMod.Enabled = isOrdder;
            btn_OrderDel.Enabled = isOrdder;

            btn_Refresh.Enabled = isCustomer && isOrdder;
            btn_Save.Enabled = isCustomer && isOrdder;
        }

    } // -- class

    public static class Moje
    {
        public static void Use<T>(this T item, Action<T> work)
        {
            work(item);
        }

    }

} // - namespace

