using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Diagnostics;
using System.Data;
using System.Data.SqlTypes;
using System.Globalization;
using System.Text.RegularExpressions;

namespace dbtest
{
    public enum DataSetState { dsUnknown = 0, dsInsert = 1, dsEdit = 2 };

    // --- Element lista parametrów --------------------------------------
    public class ItemParameter
    {
        public String Symbol;
        public String Value;
    }

    // --- Element lista kolumn --------------------------------------
    public class ItemTableColumn
    {
        public String ColumnName;
        public bool IsPrimaryKey;
        public bool IsForeignKey;
        public bool IsNullAble;
        public DbType DataType;
        public String DefaultValue;
        public int LengthCharacter ;
    }

    // --- Element listy --------------------------------------
    public class ItemOleDbManager
    {
        public delegate void EventRecordChange();
        public event EventRecordChange OnRecordChange = null;
        public delegate void EventEmptyDataSet();
        public event EventEmptyDataSet OnEmptyDataSet = null;

        //
        public OleDbManager ParentMenager = null;
        public OleDbCommand Command = null;
        public OleDbDataAdapter Adapter = null;
        public DataSet Query = null;
        public BindingSource BindSource = null;
        public string TableName = null;
        public string SQLCommandOryginal = null;
        public DataTable Table = null;
        public ItemTableColumn[] PrimaryKeyColumns = new ItemTableColumn[0];
        public List<Binding> ListBinding = new List<Binding> {};
        public List<ItemParameter> ListParameter = new List<ItemParameter> { };
        public List<ItemTableColumn> ListColumn = new List<ItemTableColumn> { };
        public DataRow Row = null;
        public DataSetState State = DataSetState.dsUnknown;
        public ItemOleDbManager Owner = null;

        // - konstruktor
        public ItemOleDbManager(OleDbManager aManager)
        {
            this.ParentMenager = aManager;
        }

        // - kontruktor przeciążony (wskazanie na rodzica)
        public ItemOleDbManager(OleDbManager aManager, ItemOleDbManager aOwner)
        {
            this.ParentMenager = aManager;
            this.Owner = aOwner;
        }

        // - dodaj papametr na podstawie nazwy kolumny
        public void _Command_ParameterAdd(OleDbCommand aCommand, string aColumnName, DbType aDataType, Object aDefaultValue = null)
        {
            OleDbParameter param = this._Command_ParameterFindByColumnName(aCommand,aColumnName);
            if (param == null)
            {
                param = new OleDbParameter();
                param.DbType = aDataType;
                param.ParameterName = string.Format("@{0}", aColumnName);
                param.SourceColumn = aColumnName;
                param.Value = aDefaultValue;
                aCommand.Parameters.Add(param);
            }
        }

        // - pobierz parametr na podsatwie nazwy kolumny
        protected OleDbParameter _Command_ParameterFindByColumnName(OleDbCommand aCommand, string aColumnName)
        {
            OleDbParameter o = null;
            for (int i = 0; i < aCommand.Parameters.Count; i++)
               if (aCommand.Parameters[i].SourceColumn.ToLower() == aColumnName.ToLower())
               {
                  o = aCommand.Parameters[i];
                  break;
               }
            return o;
        }

        // - znajdz parametr lub dodaj nowy
        public ItemParameter _LocateSymbol(string aSymbol)
        {
            foreach (ItemParameter par in ListParameter) {
              if (par.Symbol.ToLower() == aSymbol.ToLower()) return par;
            }
            return null;
        }

        // - dodaj symbol
        public bool AddSymbol(string aSymbol)
        {
            try {
                ItemParameter par = _LocateSymbol(aSymbol);
                if (par == null) {
                    par = new ItemParameter();
                    par.Symbol = aSymbol;
                    par.Value = "";
                    ListParameter.Add(par);
                }
                return true;
            } catch { }
            return false;
        }
      
        // - wstaw wartość do symbolu (gdy go nie ma dodaje symbol)
        public bool ValueSymbol(string aSymbol,string aValue)
        {
            try {
                ItemParameter par = _LocateSymbol(aSymbol);
                if (par == null) {
                    par = new ItemParameter();
                    par.Symbol = aSymbol;
                    ListParameter.Add(par);
                }
                par.Value = aValue;
                return true;
            }
            catch { }
            return false;
        }

        // - przygotuj zapytanie zamieniając symbole na wartości
        public string PrepareSQLCommand()
        {
            string sql = this.SQLCommandOryginal;
            foreach (ItemParameter par in ListParameter)
            {
                sql = Regex.Replace(sql, par.Symbol, par.Value, RegexOptions.IgnoreCase);
            }
            return sql;
        }

        // - konwersja na DbType
        public bool IntToDbType(int CodeType, ref DbType DataType)
        {
            switch (CodeType) {
                case 2: 
                    DataType = DbType.Int16;
                    return true;
                case 3 :
                    DataType = DbType.Int32;
                    return true;
                case 4:
                    DataType = DbType.Single;
                    return true;
                case 5:
                    DataType = DbType.Double;
                    return true;
                case 6:
                    DataType = DbType.Currency;
                    return true;
                case 7:
                    DataType = DbType.Date;
                    return true;
                case 9:
                case 12:
                case 13:
                    DataType = DbType.Object;
                    return true;
                case 11:
                    DataType = DbType.Boolean;
                    return true;
                case 14:
                case 131:
                case 139:
                    DataType = DbType.Decimal;
                    return true;
                case 16:
                    DataType = DbType.SByte;
                    return true;
                case 17:
                case 204:
                case 205:
                    DataType = DbType.Byte;
                    return true;
                case 18:
                    DataType = DbType.UInt16;
                    return true;
                case 20:
                    DataType = DbType.UInt32;
                    return true;
                case 21:
                    DataType = DbType.UInt64;
                    return true;
                case 64:
                case 133:
                case 135:
                    DataType = DbType.DateTime;
                    return true;
                case 72:
                    DataType = DbType.Guid;
                    return true;
                case 128:
                    DataType = DbType.Binary;
                    return true;
                case 8:
                case 129:
                case 130:
                case 200:
                case 201:
                case 202:
                case 203:
                    DataType = DbType.String;
                    return true;
            }
            return false;
        }

        // - otwórz zapytanie
        public bool GetStructure(string aTableName)
        {
            if (this.ParentMenager.IsConnected)
            try
            {
                DataTable columnsTable = this.ParentMenager.Connection.GetSchema("Columns", new String[] { null, null, aTableName, null });
                columnsTable.DefaultView.Sort = "ORDINAL_POSITION ASC";
                columnsTable = columnsTable.DefaultView.ToTable();
                if ((columnsTable != null) && (columnsTable.Rows.Count > 0))
                {
                    ListColumn.Clear();
                    foreach (DataRow RowItem in columnsTable.Rows)
                    {
                        int CodeType = Convert.ToInt32(RowItem["DATA_TYPE"].ToString().Trim());
                        DbType FieldDataType = DbType.Object;

                        // - jeżeli powiedzie się konwersja
                        if (IntToDbType(CodeType, ref FieldDataType))
                        {
                            ItemTableColumn column = new ItemTableColumn();
                            column.ColumnName = RowItem["COLUMN_NAME"].ToString().Trim();
                            column.DefaultValue = RowItem["COLUMN_DEFAULT"].ToString().Trim();
                            column.IsNullAble = (RowItem["IS_NULLABLE"].ToString().Trim().ToLower() == "false");
                            column.DataType = FieldDataType;
                            column.IsPrimaryKey = false;
                            column.IsForeignKey = false;
                            column.LengthCharacter = this.StrtoInt32Def(RowItem["CHARACTER_MAXIMUM_LENGTH"].ToString().Trim(), 0);
                            ListColumn.Add(column);
                        }
                        else
                            MessageBox.Show("Error convert type field data base");
                    }
                }

                // - oznacz klucze
                DataTable columnsIndexes = this.ParentMenager.Connection.GetSchema("Indexes", new String[] { null, null, null, null, aTableName });
                columnsIndexes.DefaultView.Sort = "ORDINAL_POSITION ASC";
                columnsIndexes = columnsIndexes.DefaultView.ToTable();

                if ((columnsIndexes != null) && (columnsIndexes.Rows.Count > 0))
                {
                    foreach (DataRow RowItem in columnsIndexes.Rows)
                    {

                        if ((RowItem["INDEX_NAME"].ToString().Trim().ToLower() == "primarykey") && (RowItem["PRIMARY_KEY"].ToString().Trim().ToLower() == "true"))
                        {
                              foreach (ItemTableColumn column in this.ListColumn)
                              {
                                string ColumnName = RowItem["COLUMN_NAME"].ToString().Trim().ToLower();
                                if (column.ColumnName.ToLower().Equals(ColumnName)) column.IsPrimaryKey = true;
                              }
                          }
                    }
                }

                // - dopisz klucze główne do innej tabeli
                foreach (ItemTableColumn Item in this.ListColumn)
                    if (Item.IsPrimaryKey)
                    {
                        int index = this.PrimaryKeyColumns.Length;
                        this.PrimaryKeyColumns = new ItemTableColumn[index + 1];
                        //this.PrimaryKeyColumns[index] = new ItemTableColumn();
                        this.PrimaryKeyColumns[index] = Item;
                    }
                return true;
            }
            catch (Exception ex) {
                MessageBox.Show("Error:" + Environment.NewLine + ex.ToString(), "exception class" + this.ToString());
            }
            return false;
        }

        // - zapytanie dopisania 
        public string BuildSQLWhere(OleDbCommand command)
        {
            string sql = null;
            int count = 0;
            foreach (ItemTableColumn Item in this.ListColumn)
            {
                if (Item.IsPrimaryKey)
                {
                    if (count > 0) sql += " AND ";
                    sql += string.Format(" {0}=@{1}", Item.ColumnName, Item.ColumnName);
                    // - dodaj parametr
                    OleDbParameter param = new OleDbParameter();
                    param.DbType = Item.DataType;
                    param.ParameterName = string.Format("@{0}", Item.ColumnName);
                    param.SourceColumn = Item.ColumnName;
                    param.Value = null;
                    command.Parameters.Add(param);
                    count++;
                }
            }
            if (sql != null) sql = string.Format("({0})", sql);
            return sql;
        }

        // - zapytanie dopisania 
        public OleDbCommand BuildSQLInsert()
        {
            try {
                OleDbCommand command = new OleDbCommand();
                command.Connection = this.ParentMenager.Connection;
                command.CommandText = null;
                //
                string sqlField = null;
                string sqlValue = null;
                int count = 0;
                foreach (ItemTableColumn Item in ListColumn)
                {
                    if ((!Item.IsPrimaryKey))
                    {
                        if (count > 0) {
                            sqlField += ", ";
                            sqlValue += ", ";
                        }
                        sqlField += string.Format("{0}",Item.ColumnName);
                        sqlValue += string.Format("@{0}", Item.ColumnName);
                        // - dodaj parametr
                        OleDbParameter param = new OleDbParameter();
                        param.DbType = Item.DataType;
                        param.ParameterName = string.Format("@{0}", Item.ColumnName);
                        param.SourceColumn = Item.ColumnName;
                        param.Value = null;
                        command.Parameters.Add(param);
                        //
                        count++;
                    }
                }
                command.CommandText = string.Format("INSERT INTO {0} ({1}) VALUES({2})", this.TableName, sqlField, sqlValue);
                return command;
            } catch (Exception ex) {
                MessageBox.Show("Error:" + Environment.NewLine + ex.ToString(), "exception class" + this.ToString());
            }
            return null;
        }

        // - zapytanie modyfikacji
        public OleDbCommand BuildSQLUpdate()
        {
            try {
                OleDbCommand command = new OleDbCommand();
                command.Connection = this.ParentMenager.Connection;
                command.CommandText = null;

                string sql = null;
                int count = 0;
                foreach (ItemTableColumn Item in ListColumn)
                {
                    if ((! Item.IsPrimaryKey) && (! Item.IsForeignKey))
                    {
                        if (count > 0) sql += ", ";
                        sql += string.Format(" {0}=@{1}", Item.ColumnName, Item.ColumnName);
                        // - dodaj parametr
                        OleDbParameter param = new OleDbParameter();
                        param.DbType = Item.DataType;
                        param.ParameterName = string.Format("@{0}", Item.ColumnName);
                        param.SourceColumn = Item.ColumnName;
                        param.Value = null;
                        command.Parameters.Add(param);
                        //
                        count++;
                    }
                }
                command.CommandText = string.Format("UPDATE {0} SET {1} WHERE {2}", this.TableName, sql, this.BuildSQLWhere(command));
                return command;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + Environment.NewLine + ex.ToString(), "exception class" + this.ToString());
            }
            return null;
        }

        // - zapytanie usuwające
        public OleDbCommand BuildSQLDelete()
        {
            try {
                OleDbCommand command = new OleDbCommand();
                command.Connection = this.ParentMenager.Connection;
                command.CommandText = null;
                command.CommandText = string.Format("DELETE FROM {0} WHERE {1}", this.TableName, this.BuildSQLWhere(command));
                return command;
            } catch (Exception ex) {
                MessageBox.Show("Error:" + Environment.NewLine + ex.ToString(), "exception class" + this.ToString());
            }
            return null;
        }

        // - otwórz zapytanie
        public bool Open()
        {
            if (this.BindSource.DataSource == null)
            try {
                Cursor.Current = Cursors.WaitCursor;
                // - wypełnij danymi
                this.Adapter.SelectCommand.CommandText = PrepareSQLCommand();
                this.Adapter.Fill(this.Query, this.TableName);
                this.Table = this.Query.Tables[this.TableName];
                this.BindSource.DataSource = this.Table;
                this.BindSource.PositionChanged += event_PositionChanged;
                Cursor.Current = Cursors.Default;
                // - pobierz bieżący rekord i wywołaj zdzarzenie
                if (OnRecordChange != null) OnRecordChange();
                return true;
            }
            catch (Exception ex) {
                MessageBox.Show("Error:" + Environment.NewLine + ex.ToString(), "exception class" + this.ToString());
            }
            return false;
        }

        // - pobierz bieżący rekord
        public DataRow GetDataRow()
        {
            try  {
                this.Row = (this.BindSource.Current as DataRowView).Row;
                return this.Row;
            } catch { }
            return null;
        }

        // - początek dopisania
        public DataRow BeginInsert()
        {
            if ((this.ParentMenager.IsConnected) && (this.Table != null))
                try
                {
                    this.Row = this.Table.NewRow();
                    // przypisz wartości domyślne
                    foreach (ItemTableColumn Item in this.ListColumn)
                    {
                        // jeżeli bieżąca tabela zawiera dane pole przypisz jego wartość domyślną
                        if (this.Row.Table.Columns.Contains(Item.ColumnName))
                        {
                            try
                            {
                                switch (Item.DataType)
                                {
                                    case DbType.String:
                                        this.Row[Item.ColumnName] = Item.DefaultValue.Trim('"');
                                        break;
                                    case DbType.UInt16:
                                    case DbType.Int16:
                                        this.Row[Item.ColumnName] = Convert.ToInt16(Item.DefaultValue);
                                        break;
                                    case DbType.UInt32:
                                    case DbType.Int32:
                                        this.Row[Item.ColumnName] = Convert.ToInt32(Item.DefaultValue);
                                        break;
                                    case DbType.Single:
                                    case DbType.Double:
                                    case DbType.Currency:
                                    case DbType.Decimal:
                                        this.Row[Item.ColumnName] = decimal.Parse(Item.DefaultValue.Trim().Replace(".", this.ParentMenager.NumberDecimalSeparator));
                                        break;
                                    case DbType.Date:
                                    case DbType.DateTime:
                                        if (Item.DefaultValue.Trim().ToLower().Equals("=now()"))
                                        {
                                            this.Row[Item.ColumnName] = DateTime.Now;
                                        }
                                        else
                                        {
                                            this.Row[Item.ColumnName] = Convert.ToDateTime(Item.DefaultValue);
                                        }
                                        break;
                                    case DbType.Boolean:
                                        this.Row[Item.ColumnName] = Convert.ToBoolean(Item.DefaultValue);
                                        break;
                                }
                            }
                            catch { }
                        }
                    }

                    // - przypisz klucz rodzica jeżeli takie powiązanie istnieje
                    if ((this.Owner != null) && (this.Owner.PrimaryKeyColumns != null))
                        foreach (ItemTableColumn col in this.Owner.PrimaryKeyColumns)
                            try
                            {
                                this.Owner.GetDataRow();
                                this.Row[col.ColumnName] = this.Owner.Row[col.ColumnName];
                            }
                            catch { }
                    this.State = DataSetState.dsInsert;
                    return this.Row;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + Environment.NewLine + ex.ToString(), "exception class" + this.ToString());
                }
            return null;
        }

        // - koniec dopisywania
        public bool PostInsert()
        {
            bool res = false;
            if ((this.State == DataSetState.dsInsert) && (this.Row != null))
                try
                {
                    // - uzupełnij parametry
                    if (this.Adapter.InsertCommand != null)
                    {
                        foreach (OleDbParameter param in this.Adapter.InsertCommand.Parameters)
                            param.Value = this.Row[param.SourceColumn];
                        //
                        res = (this.Adapter.InsertCommand.ExecuteNonQuery() == 1);
                        if (res) this.Refresh();
                        this.Cancel();

                    }
                    this.State = DataSetState.dsUnknown;
                    // - znajdz
                    if (this.PrimaryKeyColumns != null) this.LocateLastId();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + Environment.NewLine + ex.ToString(), "exception class" + this.ToString());
                }
            return res;
        }

        // - początek edycji
        public DataRow BeginEdit()
        {
            // duplikat wiersza
            this.Row = this.Table.NewRow();
            this.Row.ItemArray = this.GetDataRow().ItemArray.Clone() as object[];

            if (this.Row !=null)
            try  {
                this.Row.BeginEdit();
                this.State = DataSetState.dsEdit;
                return this.Row;
            } catch (Exception ex) {
                MessageBox.Show("Error:" + Environment.NewLine + ex.ToString(), "exception class" + this.ToString());
            }
            return null;
        }

        // - koniec edycji
        public bool PostEdit()
        {
            bool res = false;
            if ((this.State == DataSetState.dsEdit) && (this.Row != null))
            try {
                // - uzupełnij parametry
                if (this.Adapter.UpdateCommand != null)
                {
                   foreach (OleDbParameter param in this.Adapter.UpdateCommand.Parameters)
                      param.Value = this.Row[param.SourceColumn];
                   //
                   res = (this.Adapter.UpdateCommand.ExecuteNonQuery() == 1);
                   if (res) this.Refresh();
                }
                this.State = DataSetState.dsUnknown;
            } catch (Exception ex) {
                MessageBox.Show("Error:" + Environment.NewLine + ex.ToString(), "exception class" + this.ToString());
            }
            return res;
        }


        // - usuń bieżący rekord
        public bool Delete()
        {
            bool res = false;
            DataRow row = this.GetDataRow();
            if (row != null)
                try
                {
                    // - uzupełnij parametry
                    if (this.Adapter.DeleteCommand != null)
                    {
                        foreach (OleDbParameter param in this.Adapter.DeleteCommand.Parameters)
                        {
                            param.Value = row[param.SourceColumn];
                        }
                        res = (this.Adapter.DeleteCommand.ExecuteNonQuery() == 1);
                        if (res)
                        {
                            this.Query.Clear();
                            this.Refresh();
                            if ((this.BindSource.Count == 0) && (OnEmptyDataSet != null)) OnEmptyDataSet();
                        }
                    }
                    this.State = DataSetState.dsUnknown;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + Environment.NewLine + ex.ToString(), "exception class" + this.ToString());
                }
            return res;
        }

        // - odśwież dane
        public bool Refresh()
        {
            if (this.ParentMenager.IsConnected)
            try
            {
                this.Adapter.SelectCommand.CommandText = PrepareSQLCommand();
                // - przypisz klucz obcy jeżeli jest na liście parametrów
                if (this.Owner != null)
                {
                    DataRow row = this.Owner.GetDataRow();
                    if (row != null)
                    {
                        try
                        {
                            foreach (OleDbParameter param in this.Adapter.SelectCommand.Parameters)
                                param.Value = row[param.SourceColumn];
                        }
                        catch { }
                    }
                }
                if (this.PrimaryKeyColumns.Length == 0) this.Query.Clear();
                if (this.Table != null)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    this.Query.RejectChanges();
                    this.Adapter.Fill(this.Query, this.TableName);
                    this.State = DataSetState.dsUnknown;
                    Cursor.Current = Cursors.Default;
                    return true;
                }
                else
                    return this.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + Environment.NewLine + ex.ToString(), "exception class" + this.ToString());
            }
            return false;
        }

        // - zatwierdz dane
        public bool Post()
        {
            try
            {
                // - zatwierdz zmiany
                switch (this.State)
                {
                    case DataSetState.dsUnknown:
                        this.Adapter.Update(this.Query.Tables[this.TableName]);
                        this.State = DataSetState.dsUnknown;
                        break;

                    case DataSetState.dsInsert:
                        this.PostInsert();
                        break;

                    case DataSetState.dsEdit:
                        this.PostEdit();
                        break;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + Environment.NewLine + ex.ToString(), "exception class" + this.ToString());
            }
            return false;
        }

        // - anuluj zmiany
        public bool Cancel()
        {
            try
            {
                this.Query.RejectChanges();
                this.State = DataSetState.dsUnknown;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + Environment.NewLine + ex.ToString(), "exception class" + this.ToString());
            }
            return false;
        }

        // - pobierz ostatni dopisany rekord
        public int LocateLastId()
        {
            if ((this.PrimaryKeyColumns != null) && (this.PrimaryKeyColumns.Length == 1))
            try {
                int newId = this.ParentMenager.GetLastId();
                if (newId > 0)
                {
                    int p = this.BindSource.Find(this.PrimaryKeyColumns[0].ColumnName, newId);
                    if (p >= 0) this.BindSource.Position = p;
                }
            } catch (Exception ex) {
                MessageBox.Show("Error:" + Environment.NewLine + ex.ToString(), "exception class" + this.ToString());
            }
            return 0;
        }

        // - ustaw filtrację danych
        public void Filter(string aSQLFilter)
        {
            this.BindSource.Filter = aSQLFilter;
        }

        // - połącz z kontrolną (nazwa własności kontrolki np. text, nazwa pola)
        public Binding AddBinding(string aPropertyName, string aDataMember)
        {
            try {
                Binding b = new Binding(aPropertyName, this.BindSource, aDataMember);
                this.ListBinding.Add(b);
                return b;
            } catch (Exception ex) {
                MessageBox.Show("Error:" + Environment.NewLine + ex.ToString(), "exception class" + this.ToString());
            }
            return null;  
        }

        // - zwolnij połączenia z kontrolkami
        public void RemoveBindings()
        {
            Binding b = null;
            for (int i=0; i<ListBinding.Count; i++)
            {
                b = ListBinding[i];
                b.Control.Text = "";
                b.BindableComponent.DataBindings.Remove(b);
            }
            ListBinding.Clear();
        }

        // - ilość rekordów
        public long RecordCount()   {
           return this.BindSource.Count;
        }

        // - numer aktualnego rekordu
        public long RecordPosition()
        {
            return this.BindSource.Position;
        }


        // - czy są dane
        public bool isData()
        {
            return this.BindSource.Count > 0;
        }

        // - czy jest zainicjowane zapytanie
        public bool isActivate()
        {
            return (this.Table != null);
        }

        // - pierwszy rekord
        public bool First()
        {
            this.BindSource.MoveFirst();
            return false;
        }

        // - poprzedni rekord
        public bool Prev()
        {
            this.BindSource.MovePrevious();
            return false;
        }

        // - następny rekord
        public bool Next()
        {
            this.BindSource.MoveNext();
            return false;
        }

        // - ostatni rekord
        public bool Last()
        {
            this.BindSource.MoveLast();
            return false;
        }

        // - zmiana bieżącego rekordu
        private void event_PositionChanged(object sender, EventArgs e)
        {
            if (this.OnRecordChange != null) this.OnRecordChange();
        }

        // --- METODY PRYWATNE

        // - konwersja łańcucha na liczbę integer (w przypadku błędu konwersji przyjmuje wartość domyślną)
        private int StrtoInt32Def(string StrNumber, int DefaultValue)
        {
            try
            {
                return Convert.ToInt32(StrNumber);
            }
            catch { }
            return DefaultValue;
        }
    }

    // --- Zarządca listy --------------------------------------
    public class OleDbManager
    {
        private OleDbConnection _Connection;
        private bool _IsConnected = false;
        private String _ConnectingString;
        public List<ItemOleDbManager> cItems = new List<ItemOleDbManager> { };
        public string NumberDecimalSeparator = null;

        // - konstruktor
        public OleDbManager()
        {
            var si = System.Threading.Thread.CurrentThread.CurrentCulture;
            NumberDecimalSeparator = si.NumberFormat.NumberDecimalSeparator;
        }

        // --- METODY PUBLICZNE

        // - połącz się z bazą ACCESS
        public bool ConnectAccess(String aFileName, String aUser, String aPass)
        {
            if (this._Connection == null)
            {
                string ext = Path.GetExtension(aFileName).ToLower();
                if (ext == ".mdb") {
                    this._ConnectingString = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Persist Security Info=True", aFileName);
                } else if (ext == ".accdb") {
                    this._ConnectingString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Persist Security Info=True", aFileName);
                }
                this._Connection = new OleDbConnection(this._ConnectingString);
                try {
                    this._Connection.Open();
                    _IsConnected = true;
                    return true;
                } catch (Exception ex) {
                    _IsConnected = false;
                    MessageBox.Show("Error:" + Environment.NewLine + ex.ToString(), "exception class" + this.ToString());
                }
            } else MessageBox.Show("Error: still connected");
            return false;
        }

        // - połącz się z bazą MSSQL
        public bool ConnectMsSQL(String Host, String DatabaseName, String User, String Pass)
        {
            if (this._Connection == null)
            {
                this._ConnectingString = string.Format("Provider=SQLOLEDB;Data Source={0};Initial Catalog={1};User ID = {2}; Password={3}", Host, DatabaseName, User, Pass);
                this._Connection = new OleDbConnection(this._ConnectingString);
                try  {
                    this._Connection.Open();
                    _IsConnected = true;
                    return true;
                } catch (Exception ex) {
                    _IsConnected = false;
                    MessageBox.Show("Error:" + Environment.NewLine + ex.ToString(), "exception class" + this.ToString());
                }
            } else MessageBox.Show("Error: still connected");
            return false;
        }

        // - połącz się z bazą MSSQL
        public bool ConnectMsSQL(String Host, String DatabaseName)
        {
            if (this._Connection == null)
            {
                this._ConnectingString = string.Format("Provider=SQLOLEDB;Data Source={0};Initial Catalog={1};Integrated Security = SSPI", Host, DatabaseName);
                this._Connection = new OleDbConnection(this._ConnectingString);
                try
                {
                    this._Connection.Open();
                    _IsConnected = true;
                    return true;
                }
                catch (Exception ex)
                {
                    _IsConnected = false;
                    MessageBox.Show("Error:" + Environment.NewLine + ex.ToString(), "exception class" + this.ToString());
                }
            }
            else MessageBox.Show("Error: still connected");
            return false;
        }

        // - połącz się z XLS
        public bool ConnectExcel(String aFileName)
        {
            if (this._Connection == null)
            {
                string ext = Path.GetExtension(aFileName).ToLower();
                if (ext == ".xls") {
                  this._ConnectingString = string.Format("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = {0}; Extended Properties = \"Excel 8.0; HDR = Yes; IMEX = 1\";", aFileName);
                } else if (ext == ".xlsx") {
                    this._ConnectingString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; Extended Properties = \"Excel 12.0 Xml;HDR=YES\"; ", aFileName);
                }
                this._Connection = new OleDbConnection(this._ConnectingString);
                try
                {
                    this._Connection.Open();
                    _IsConnected = true;
                    return true;
                }
                catch (Exception ex)
                {
                    _IsConnected = false;
                    MessageBox.Show("Error:" + Environment.NewLine + ex.ToString(), "exception class" + this.ToString());
                }
            }
            else MessageBox.Show("Error: still connected");
            return false;
        }

        // - zamknij i zwolnij połączenie
        public bool Disconnect()
        {
            if (this._Connection != null)
            try {
                for (int i = cItems.Count; i > 0; i--) this.itemDel(i);
                this.Connection.Close();
                this.Connection.Dispose();
                this._IsConnected = false;
                this._Connection = null;
                // 
                return true;
            }  catch (Exception ex) {
                MessageBox.Show("Error:" + Environment.NewLine + ex.ToString(), "exception class" + this.ToString());
            } else  MessageBox.Show("Error: no connected");
            return false;
        }

        // - zwróć uchwyt do aktywnego połączenia
        public OleDbConnection Connection
        {
            get { return _Connection;  }
        }

        // - semafor czy połączony
        public bool IsConnected
        {
            get { return _IsConnected; }
        }

        // - łańcuch połączeniowy
        public String ConnectingString
        {
            get { return _ConnectingString; }
        }

        // - pobierz ostatni dopisany rekord
        public int GetLastId()
        {
            if (this._Connection != null)
            try
            {
              using (OleDbCommand cmd = new OleDbCommand("SELECT @@IDENTITY", this._Connection))
              {
                  return (Int32)cmd.ExecuteScalar();
              }
            } catch (Exception ex) {
                MessageBox.Show("Error:" + Environment.NewLine + ex.ToString(), "exception class" + this.ToString());
            } else  MessageBox.Show("Error: no connected");
            return 0;
        }

        // - dodaj element
        public int itemAdd(String aSelectCommand, String aTableName)
        {
            if (this._Connection != null)
            try
            {
                ItemOleDbManager o = new ItemOleDbManager(this);
                o.SQLCommandOryginal = aSelectCommand;
                o.Adapter = new OleDbDataAdapter("",this.Connection);
                o.Adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                o.Query = new DataSet();
                o.BindSource = new BindingSource();
                o.TableName = aTableName;
                // pobierz strukturę
                o.GetStructure(o.TableName);
                // - insert, update, delete
                o.Adapter.InsertCommand = o.BuildSQLInsert();
                o.Adapter.UpdateCommand = o.BuildSQLUpdate();
                o.Adapter.DeleteCommand = o.BuildSQLDelete();
                cItems.Add(o);
                return cItems.Count;
            } catch (Exception ex) {
                MessageBox.Show("Error:" + Environment.NewLine + ex.ToString(), "exception class" + this.ToString());
            }  else MessageBox.Show("Error: no connected");
            return 0;
        }

        // - przeciążona metoda
        public int itemAdd(String aSelectCommand, String aTableName, ItemOleDbManager aOwner)
        {
            if (this._Connection != null)
            try
            {
               int index = this.itemAdd(aSelectCommand, aTableName);
               ItemOleDbManager o = cItems[index - 1];
               o.Owner = aOwner;
               // - dodaj parametry do zapytania
               foreach (ItemTableColumn Item in o.Owner.PrimaryKeyColumns)
               {
                  o._Command_ParameterAdd(o.Adapter.SelectCommand, Item.ColumnName, Item.DataType, 0);
               }
               return index;
            }  catch (Exception ex) {
               MessageBox.Show("Error:" + Environment.NewLine + ex.ToString(), "exception class" + this.ToString());
            } else MessageBox.Show("Error: no connected");
            return 0;
        }

        // - usuń element
        public bool itemDel(int index)
        {
            if (index > 0)
            try {
                ItemOleDbManager o = cItems[index - 1];
                // zwolnij połączenia
                o.RemoveBindings();
                // wyczyść zapytanie
                o.Query.Clear();
                o.RemoveBindings();
                o.BindSource.DataSource = null;
                // zwolnij obiekty
                o.Adapter.Dispose();
                o.BindSource.Dispose();
                o.Table = null;
                // usuń element
                cItems.Remove(o);
                o = null;
                return true;
            } catch (Exception ex) {
                MessageBox.Show("Error:" + Environment.NewLine + ex.ToString(), "exception class" + this.ToString());
            }
            return false;
        }

        // - pobierz element
        public ItemOleDbManager itemGet(int index)
        {
            try {
                ItemOleDbManager c = cItems[index - 1];
                return c;
            } catch (Exception ex) {
                MessageBox.Show("Error:" + Environment.NewLine + ex.ToString(), "exception class" + this.ToString());
            }
            return null;
        }

        // - wykonaj zapytanie SQL (select)
        public OleDbDataReader SQLSelect(String aSelectCommand)
        {
            if (this._Connection != null)
            try {
                OleDbCommand cmd = new OleDbCommand(aSelectCommand, this._Connection);
                return cmd.ExecuteReader();
            } catch (Exception ex) {
                MessageBox.Show("Error:" + Environment.NewLine + ex.ToString(), "exception class" + this.ToString());
            }  else MessageBox.Show("Error: no connected");
            return null;
        }

        // - wykonaj polecenie SQL (insert,, update, delete)
        public bool SQLExecute(String aExecuteCommand, ref int aResult)
        {
            if (this._Connection != null)
            try {
                OleDbCommand cmd = new OleDbCommand(aExecuteCommand, this._Connection);
                aResult =  cmd.ExecuteNonQuery();
                return true; 
            } catch (Exception ex)  {
                MessageBox.Show("Error:" + Environment.NewLine + ex.ToString(), "exception class" + this.ToString());
            } else  MessageBox.Show("Error: no connected");
            return false;
        }


        // --- METODY PRYWATNE
    }
    // - Koniec 
}
