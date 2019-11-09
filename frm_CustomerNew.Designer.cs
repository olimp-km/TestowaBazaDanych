namespace TestowaBazaDanych
{
    partial class frm_CustomerNew
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdReject = new System.Windows.Forms.Button();
            this.cmdAccept = new System.Windows.Forms.Button();
            this.labZipCode = new System.Windows.Forms.Label();
            this.txtZipCode = new System.Windows.Forms.TextBox();
            this.cboStates = new System.Windows.Forms.ComboBox();
            this.labState = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.labCity = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.labAddress = new System.Windows.Forms.Label();
            this.txtAccountNumber = new System.Windows.Forms.TextBox();
            this.labAccountNumber = new System.Windows.Forms.Label();
            this.txtSecondName = new System.Windows.Forms.TextBox();
            this.labSecondName = new System.Windows.Forms.Label();
            this.labFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmdReject
            // 
            this.cmdReject.Location = new System.Drawing.Point(227, 180);
            this.cmdReject.Name = "cmdReject";
            this.cmdReject.Size = new System.Drawing.Size(87, 26);
            this.cmdReject.TabIndex = 39;
            this.cmdReject.Text = "Rezygnacja";
            this.cmdReject.UseVisualStyleBackColor = true;
            this.cmdReject.Click += new System.EventHandler(this.cmdReject_Click);
            // 
            // cmdAccept
            // 
            this.cmdAccept.Location = new System.Drawing.Point(150, 180);
            this.cmdAccept.Name = "cmdAccept";
            this.cmdAccept.Size = new System.Drawing.Size(71, 26);
            this.cmdAccept.TabIndex = 38;
            this.cmdAccept.Text = "OK";
            this.cmdAccept.UseVisualStyleBackColor = true;
            this.cmdAccept.Click += new System.EventHandler(this.CmdAccept_Click);
            // 
            // labZipCode
            // 
            this.labZipCode.AutoSize = true;
            this.labZipCode.Location = new System.Drawing.Point(34, 135);
            this.labZipCode.Name = "labZipCode";
            this.labZipCode.Size = new System.Drawing.Size(74, 13);
            this.labZipCode.TabIndex = 41;
            this.labZipCode.Text = "Kod pocztowy";
            // 
            // txtZipCode
            // 
            this.txtZipCode.Location = new System.Drawing.Point(121, 132);
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(100, 20);
            this.txtZipCode.TabIndex = 5;
            // 
            // cboStates
            // 
            this.cboStates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStates.FormattingEnabled = true;
            this.cboStates.Location = new System.Drawing.Point(121, 108);
            this.cboStates.Name = "cboStates";
            this.cboStates.Size = new System.Drawing.Size(197, 21);
            this.cboStates.TabIndex = 4;
            // 
            // labState
            // 
            this.labState.AutoSize = true;
            this.labState.Location = new System.Drawing.Point(34, 111);
            this.labState.Name = "labState";
            this.labState.Size = new System.Drawing.Size(32, 13);
            this.labState.TabIndex = 36;
            this.labState.Text = "State";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(121, 84);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(197, 20);
            this.txtCity.TabIndex = 3;
            // 
            // labCity
            // 
            this.labCity.AutoSize = true;
            this.labCity.Location = new System.Drawing.Point(34, 87);
            this.labCity.Name = "labCity";
            this.labCity.Size = new System.Drawing.Size(68, 13);
            this.labCity.TabIndex = 34;
            this.labCity.Text = "Miejscowość";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(121, 62);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(197, 20);
            this.txtAddress.TabIndex = 2;
            // 
            // labAddress
            // 
            this.labAddress.AutoSize = true;
            this.labAddress.Location = new System.Drawing.Point(34, 65);
            this.labAddress.Name = "labAddress";
            this.labAddress.Size = new System.Drawing.Size(31, 13);
            this.labAddress.TabIndex = 32;
            this.labAddress.Text = "Ulica";
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.Location = new System.Drawing.Point(121, 154);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Size = new System.Drawing.Size(197, 20);
            this.txtAccountNumber.TabIndex = 6;
            // 
            // labAccountNumber
            // 
            this.labAccountNumber.AutoSize = true;
            this.labAccountNumber.Location = new System.Drawing.Point(34, 157);
            this.labAccountNumber.Name = "labAccountNumber";
            this.labAccountNumber.Size = new System.Drawing.Size(48, 13);
            this.labAccountNumber.TabIndex = 30;
            this.labAccountNumber.Text = "Nr konta";
            // 
            // txtSecondName
            // 
            this.txtSecondName.Location = new System.Drawing.Point(121, 40);
            this.txtSecondName.Name = "txtSecondName";
            this.txtSecondName.Size = new System.Drawing.Size(197, 20);
            this.txtSecondName.TabIndex = 1;
            // 
            // labSecondName
            // 
            this.labSecondName.AutoSize = true;
            this.labSecondName.Location = new System.Drawing.Point(34, 43);
            this.labSecondName.Name = "labSecondName";
            this.labSecondName.Size = new System.Drawing.Size(53, 13);
            this.labSecondName.TabIndex = 28;
            this.labSecondName.Text = "Nazwisko";
            // 
            // labFirstName
            // 
            this.labFirstName.AutoSize = true;
            this.labFirstName.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.labFirstName.Location = new System.Drawing.Point(34, 20);
            this.labFirstName.Name = "labFirstName";
            this.labFirstName.Size = new System.Drawing.Size(26, 13);
            this.labFirstName.TabIndex = 42;
            this.labFirstName.Text = "Imię";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(121, 17);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(197, 20);
            this.txtFirstName.TabIndex = 0;
            // 
            // frm_CustomerNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 259);
            this.Controls.Add(this.cmdAccept);
            this.Controls.Add(this.cmdReject);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.labFirstName);
            this.Controls.Add(this.labZipCode);
            this.Controls.Add(this.txtZipCode);
            this.Controls.Add(this.cboStates);
            this.Controls.Add(this.labState);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.labCity);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.labAddress);
            this.Controls.Add(this.txtAccountNumber);
            this.Controls.Add(this.labAccountNumber);
            this.Controls.Add(this.txtSecondName);
            this.Controls.Add(this.labSecondName);
            this.Name = "frm_CustomerNew";
            this.Text = "Nowy pracownik";
            this.Load += new System.EventHandler(this.Frm_CustomerNew_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label labZipCode;
        public System.Windows.Forms.TextBox txtZipCode;
        internal System.Windows.Forms.Button cmdReject;
        internal System.Windows.Forms.Button cmdAccept;
        public System.Windows.Forms.ComboBox cboStates;
        internal System.Windows.Forms.Label labState;
        public System.Windows.Forms.TextBox txtCity;
        internal System.Windows.Forms.Label labCity;
        public System.Windows.Forms.TextBox txtAddress;
        internal System.Windows.Forms.Label labAddress;
        public System.Windows.Forms.TextBox txtAccountNumber;
        internal System.Windows.Forms.Label labAccountNumber;
        public System.Windows.Forms.TextBox txtSecondName;
        internal System.Windows.Forms.Label labSecondName;
        internal System.Windows.Forms.Label labFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
    }
}