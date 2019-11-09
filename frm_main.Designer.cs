namespace TestowaBazaDanych
{
    partial class frm_main
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_main));
            this.but_connect = new System.Windows.Forms.Button();
            this.btn_CustomerMod = new System.Windows.Forms.Button();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.btn_CustomerDel = new System.Windows.Forms.Button();
            this.btn_CustomerAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_OrderDel = new System.Windows.Forms.Button();
            this.btn_OrderAdd = new System.Windows.Forms.Button();
            this.btn_OrderMod = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.NavigatorOrder = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem1 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.GridOrder = new System.Windows.Forms.DataGridView();
            this.NavigatorCustomer = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.GridCustomer = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NavigatorOrder)).BeginInit();
            this.NavigatorOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NavigatorCustomer)).BeginInit();
            this.NavigatorCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // but_connect
            // 
            this.but_connect.Location = new System.Drawing.Point(9, 12);
            this.but_connect.Name = "but_connect";
            this.but_connect.Size = new System.Drawing.Size(107, 23);
            this.but_connect.TabIndex = 0;
            this.but_connect.Text = "Połącz się z bazą danych";
            this.but_connect.UseVisualStyleBackColor = true;
            this.but_connect.Click += new System.EventHandler(this.But_connect_Click);
            // 
            // btn_CustomerMod
            // 
            this.btn_CustomerMod.Enabled = false;
            this.btn_CustomerMod.Image = ((System.Drawing.Image)(resources.GetObject("btn_CustomerMod.Image")));
            this.btn_CustomerMod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CustomerMod.Location = new System.Drawing.Point(12, 65);
            this.btn_CustomerMod.Margin = new System.Windows.Forms.Padding(1);
            this.btn_CustomerMod.Name = "btn_CustomerMod";
            this.btn_CustomerMod.Size = new System.Drawing.Size(104, 23);
            this.btn_CustomerMod.TabIndex = 3;
            this.btn_CustomerMod.Text = "Popraw";
            this.btn_CustomerMod.UseVisualStyleBackColor = true;
            this.btn_CustomerMod.Click += new System.EventHandler(this.btn_CustomerMod_Click);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Refresh.Enabled = false;
            this.btn_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("btn_Refresh.Image")));
            this.btn_Refresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Refresh.Location = new System.Drawing.Point(15, 418);
            this.btn_Refresh.Margin = new System.Windows.Forms.Padding(1);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(101, 26);
            this.btn_Refresh.TabIndex = 4;
            this.btn_Refresh.Text = "Odśwież";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.But_refresh_Click);
            // 
            // btn_CustomerDel
            // 
            this.btn_CustomerDel.Enabled = false;
            this.btn_CustomerDel.Image = ((System.Drawing.Image)(resources.GetObject("btn_CustomerDel.Image")));
            this.btn_CustomerDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CustomerDel.Location = new System.Drawing.Point(12, 90);
            this.btn_CustomerDel.Margin = new System.Windows.Forms.Padding(1);
            this.btn_CustomerDel.Name = "btn_CustomerDel";
            this.btn_CustomerDel.Size = new System.Drawing.Size(104, 23);
            this.btn_CustomerDel.TabIndex = 5;
            this.btn_CustomerDel.Text = "Usuń";
            this.btn_CustomerDel.UseVisualStyleBackColor = true;
            this.btn_CustomerDel.Click += new System.EventHandler(this.btn_CustomerDel_Click);
            // 
            // btn_CustomerAdd
            // 
            this.btn_CustomerAdd.Enabled = false;
            this.btn_CustomerAdd.Image = ((System.Drawing.Image)(resources.GetObject("btn_CustomerAdd.Image")));
            this.btn_CustomerAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CustomerAdd.Location = new System.Drawing.Point(12, 41);
            this.btn_CustomerAdd.Margin = new System.Windows.Forms.Padding(1);
            this.btn_CustomerAdd.Name = "btn_CustomerAdd";
            this.btn_CustomerAdd.Size = new System.Drawing.Size(104, 23);
            this.btn_CustomerAdd.TabIndex = 6;
            this.btn_CustomerAdd.Text = "Dodaj";
            this.btn_CustomerAdd.UseVisualStyleBackColor = true;
            this.btn_CustomerAdd.Click += new System.EventHandler(this.btn_CustomerAdd_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_OrderDel);
            this.panel1.Controls.Add(this.btn_OrderAdd);
            this.panel1.Controls.Add(this.btn_OrderMod);
            this.panel1.Controls.Add(this.btn_Save);
            this.panel1.Controls.Add(this.but_connect);
            this.panel1.Controls.Add(this.btn_Refresh);
            this.panel1.Controls.Add(this.btn_CustomerDel);
            this.panel1.Controls.Add(this.btn_CustomerAdd);
            this.panel1.Controls.Add(this.btn_CustomerMod);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(129, 481);
            this.panel1.TabIndex = 7;
            // 
            // btn_OrderDel
            // 
            this.btn_OrderDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_OrderDel.Enabled = false;
            this.btn_OrderDel.Image = ((System.Drawing.Image)(resources.GetObject("btn_OrderDel.Image")));
            this.btn_OrderDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_OrderDel.Location = new System.Drawing.Point(15, 325);
            this.btn_OrderDel.Margin = new System.Windows.Forms.Padding(1);
            this.btn_OrderDel.Name = "btn_OrderDel";
            this.btn_OrderDel.Size = new System.Drawing.Size(104, 23);
            this.btn_OrderDel.TabIndex = 13;
            this.btn_OrderDel.Text = "Usuń";
            this.btn_OrderDel.UseVisualStyleBackColor = true;
            this.btn_OrderDel.Click += new System.EventHandler(this.btn_OrderDel_Click);
            // 
            // btn_OrderAdd
            // 
            this.btn_OrderAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_OrderAdd.Enabled = false;
            this.btn_OrderAdd.Image = ((System.Drawing.Image)(resources.GetObject("btn_OrderAdd.Image")));
            this.btn_OrderAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_OrderAdd.Location = new System.Drawing.Point(15, 276);
            this.btn_OrderAdd.Margin = new System.Windows.Forms.Padding(1);
            this.btn_OrderAdd.Name = "btn_OrderAdd";
            this.btn_OrderAdd.Size = new System.Drawing.Size(104, 23);
            this.btn_OrderAdd.TabIndex = 14;
            this.btn_OrderAdd.Text = "Dodaj";
            this.btn_OrderAdd.UseVisualStyleBackColor = true;
            this.btn_OrderAdd.Click += new System.EventHandler(this.btn_OrderAdd_Click);
            // 
            // btn_OrderMod
            // 
            this.btn_OrderMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_OrderMod.Enabled = false;
            this.btn_OrderMod.Image = ((System.Drawing.Image)(resources.GetObject("btn_OrderMod.Image")));
            this.btn_OrderMod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_OrderMod.Location = new System.Drawing.Point(15, 300);
            this.btn_OrderMod.Margin = new System.Windows.Forms.Padding(1);
            this.btn_OrderMod.Name = "btn_OrderMod";
            this.btn_OrderMod.Size = new System.Drawing.Size(104, 23);
            this.btn_OrderMod.TabIndex = 12;
            this.btn_OrderMod.Text = "Popraw";
            this.btn_OrderMod.UseVisualStyleBackColor = true;
            this.btn_OrderMod.Click += new System.EventHandler(this.btn_OrderMod_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Save.Enabled = false;
            this.btn_Save.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.Image")));
            this.btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Save.Location = new System.Drawing.Point(15, 446);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(1);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(101, 27);
            this.btn_Save.TabIndex = 11;
            this.btn_Save.Text = " Zapisz";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.NavigatorCustomer);
            this.panel2.Controls.Add(this.GridCustomer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(129, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 481);
            this.panel2.TabIndex = 8;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 243);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(784, 3);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.NavigatorOrder);
            this.panel3.Controls.Add(this.GridOrder);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 246);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(784, 235);
            this.panel3.TabIndex = 5;
            // 
            // NavigatorOrder
            // 
            this.NavigatorOrder.AddNewItem = this.bindingNavigatorAddNewItem1;
            this.NavigatorOrder.CountItem = this.bindingNavigatorCountItem1;
            this.NavigatorOrder.DeleteItem = this.bindingNavigatorDeleteItem1;
            this.NavigatorOrder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem1,
            this.bindingNavigatorMovePreviousItem1,
            this.bindingNavigatorSeparator3,
            this.bindingNavigatorPositionItem1,
            this.bindingNavigatorCountItem1,
            this.bindingNavigatorSeparator4,
            this.bindingNavigatorMoveNextItem1,
            this.bindingNavigatorMoveLastItem1,
            this.bindingNavigatorSeparator5,
            this.bindingNavigatorAddNewItem1,
            this.bindingNavigatorDeleteItem1});
            this.NavigatorOrder.Location = new System.Drawing.Point(0, 0);
            this.NavigatorOrder.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
            this.NavigatorOrder.MoveLastItem = this.bindingNavigatorMoveLastItem1;
            this.NavigatorOrder.MoveNextItem = this.bindingNavigatorMoveNextItem1;
            this.NavigatorOrder.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
            this.NavigatorOrder.Name = "NavigatorOrder";
            this.NavigatorOrder.PositionItem = this.bindingNavigatorPositionItem1;
            this.NavigatorOrder.Size = new System.Drawing.Size(784, 25);
            this.NavigatorOrder.TabIndex = 6;
            this.NavigatorOrder.Text = "bindingNavigator2";
            // 
            // bindingNavigatorAddNewItem1
            // 
            this.bindingNavigatorAddNewItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem1.Image")));
            this.bindingNavigatorAddNewItem1.Name = "bindingNavigatorAddNewItem1";
            this.bindingNavigatorAddNewItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem1.Text = "Dodaj nowy";
            // 
            // bindingNavigatorCountItem1
            // 
            this.bindingNavigatorCountItem1.Name = "bindingNavigatorCountItem1";
            this.bindingNavigatorCountItem1.Size = new System.Drawing.Size(29, 22);
            this.bindingNavigatorCountItem1.Text = "z {0}";
            this.bindingNavigatorCountItem1.ToolTipText = "Suma elementów";
            // 
            // bindingNavigatorDeleteItem1
            // 
            this.bindingNavigatorDeleteItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem1.Image")));
            this.bindingNavigatorDeleteItem1.Name = "bindingNavigatorDeleteItem1";
            this.bindingNavigatorDeleteItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem1.Text = "Usuń";
            // 
            // bindingNavigatorMoveFirstItem1
            // 
            this.bindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem1.Image")));
            this.bindingNavigatorMoveFirstItem1.Name = "bindingNavigatorMoveFirstItem1";
            this.bindingNavigatorMoveFirstItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem1.Text = "Przenieś pierwszy";
            // 
            // bindingNavigatorMovePreviousItem1
            // 
            this.bindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem1.Image")));
            this.bindingNavigatorMovePreviousItem1.Name = "bindingNavigatorMovePreviousItem1";
            this.bindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem1.Text = "Przenieś poprzedni";
            // 
            // bindingNavigatorSeparator3
            // 
            this.bindingNavigatorSeparator3.Name = "bindingNavigatorSeparator3";
            this.bindingNavigatorSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem1
            // 
            this.bindingNavigatorPositionItem1.AccessibleName = "Pozycja";
            this.bindingNavigatorPositionItem1.AutoSize = false;
            this.bindingNavigatorPositionItem1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem1.Name = "bindingNavigatorPositionItem1";
            this.bindingNavigatorPositionItem1.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem1.Text = "0";
            this.bindingNavigatorPositionItem1.ToolTipText = "Bieżąca pozycja";
            // 
            // bindingNavigatorSeparator4
            // 
            this.bindingNavigatorSeparator4.Name = "bindingNavigatorSeparator4";
            this.bindingNavigatorSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem1
            // 
            this.bindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem1.Image")));
            this.bindingNavigatorMoveNextItem1.Name = "bindingNavigatorMoveNextItem1";
            this.bindingNavigatorMoveNextItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem1.Text = "Przenieś następny";
            // 
            // bindingNavigatorMoveLastItem1
            // 
            this.bindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem1.Image")));
            this.bindingNavigatorMoveLastItem1.Name = "bindingNavigatorMoveLastItem1";
            this.bindingNavigatorMoveLastItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem1.Text = "Przenieś ostatni";
            // 
            // bindingNavigatorSeparator5
            // 
            this.bindingNavigatorSeparator5.Name = "bindingNavigatorSeparator5";
            this.bindingNavigatorSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // GridOrder
            // 
            this.GridOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridOrder.Location = new System.Drawing.Point(0, 28);
            this.GridOrder.Name = "GridOrder";
            this.GridOrder.Size = new System.Drawing.Size(784, 207);
            this.GridOrder.TabIndex = 5;
            this.GridOrder.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GridOrder_CellFormatting);
            this.GridOrder.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.GridOrder_CellValidating);
            this.GridOrder.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridOrder_CellValueChanged);
            this.GridOrder.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.GridOrder_DataError);
            this.GridOrder.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.GridOrder_EditingControlShowing);
            this.GridOrder.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.DataGridView_RowPrePaint);
            // 
            // NavigatorCustomer
            // 
            this.NavigatorCustomer.AddNewItem = this.bindingNavigatorAddNewItem;
            this.NavigatorCustomer.CountItem = this.bindingNavigatorCountItem;
            this.NavigatorCustomer.DeleteItem = this.bindingNavigatorDeleteItem;
            this.NavigatorCustomer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.NavigatorCustomer.Location = new System.Drawing.Point(0, 0);
            this.NavigatorCustomer.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.NavigatorCustomer.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.NavigatorCustomer.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.NavigatorCustomer.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.NavigatorCustomer.Name = "NavigatorCustomer";
            this.NavigatorCustomer.PositionItem = this.bindingNavigatorPositionItem;
            this.NavigatorCustomer.Size = new System.Drawing.Size(784, 25);
            this.NavigatorCustomer.TabIndex = 3;
            this.NavigatorCustomer.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Dodaj nowy";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(29, 22);
            this.bindingNavigatorCountItem.Text = "z {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Suma elementów";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Usuń";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Przenieś pierwszy";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Przenieś poprzedni";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Pozycja";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Bieżąca pozycja";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Przenieś następny";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Przenieś ostatni";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // GridCustomer
            // 
            this.GridCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridCustomer.Location = new System.Drawing.Point(0, 28);
            this.GridCustomer.Name = "GridCustomer";
            this.GridCustomer.Size = new System.Drawing.Size(781, 215);
            this.GridCustomer.TabIndex = 2;
            this.GridCustomer.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridCustomer_CellValueChanged);
            this.GridCustomer.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.DataGridView_RowPrePaint);
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 481);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frm_main";
            this.Text = "Przykładowa baza danych";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NavigatorOrder)).EndInit();
            this.NavigatorOrder.ResumeLayout(false);
            this.NavigatorOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NavigatorCustomer)).EndInit();
            this.NavigatorCustomer.ResumeLayout(false);
            this.NavigatorCustomer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridCustomer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button but_connect;
        private System.Windows.Forms.Button btn_CustomerMod;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.Button btn_CustomerDel;
        private System.Windows.Forms.Button btn_CustomerAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.BindingNavigator NavigatorOrder;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator3;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator4;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator5;
        private System.Windows.Forms.DataGridView GridOrder;
        private System.Windows.Forms.BindingNavigator NavigatorCustomer;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.DataGridView GridCustomer;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_OrderDel;
        private System.Windows.Forms.Button btn_OrderAdd;
        private System.Windows.Forms.Button btn_OrderMod;
    }
}

