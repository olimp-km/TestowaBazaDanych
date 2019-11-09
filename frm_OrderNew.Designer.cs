namespace TestowaBazaDanych
{
    partial class frm_OrderNew
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
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.labPrice = new System.Windows.Forms.Label();
            this.txtInvoice = new System.Windows.Forms.TextBox();
            this.labInvoice = new System.Windows.Forms.Label();
            this.labdtOrderDate = new System.Windows.Forms.Label();
            this.dtOrderDate = new System.Windows.Forms.DateTimePicker();
            this.chkPaymend = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cmdReject
            // 
            this.cmdReject.Location = new System.Drawing.Point(231, 110);
            this.cmdReject.Name = "cmdReject";
            this.cmdReject.Size = new System.Drawing.Size(87, 26);
            this.cmdReject.TabIndex = 39;
            this.cmdReject.Text = "Rezygnacja";
            this.cmdReject.UseVisualStyleBackColor = true;
            this.cmdReject.Click += new System.EventHandler(this.cmdReject_Click);
            // 
            // cmdAccept
            // 
            this.cmdAccept.Location = new System.Drawing.Point(154, 110);
            this.cmdAccept.Name = "cmdAccept";
            this.cmdAccept.Size = new System.Drawing.Size(71, 26);
            this.cmdAccept.TabIndex = 38;
            this.cmdAccept.Text = "OK";
            this.cmdAccept.UseVisualStyleBackColor = true;
            this.cmdAccept.Click += new System.EventHandler(this.CmdAccept_Click);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(121, 84);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(197, 20);
            this.txtPrice.TabIndex = 3;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Price_KeyPress);
            // 
            // labPrice
            // 
            this.labPrice.AutoSize = true;
            this.labPrice.Location = new System.Drawing.Point(34, 87);
            this.labPrice.Name = "labPrice";
            this.labPrice.Size = new System.Drawing.Size(84, 13);
            this.labPrice.TabIndex = 34;
            this.labPrice.Text = "Kwota płatności";
            // 
            // txtInvoice
            // 
            this.txtInvoice.Location = new System.Drawing.Point(121, 40);
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.Size = new System.Drawing.Size(197, 20);
            this.txtInvoice.TabIndex = 1;
            // 
            // labInvoice
            // 
            this.labInvoice.AutoSize = true;
            this.labInvoice.Location = new System.Drawing.Point(34, 43);
            this.labInvoice.Name = "labInvoice";
            this.labInvoice.Size = new System.Drawing.Size(76, 13);
            this.labInvoice.TabIndex = 28;
            this.labInvoice.Text = "Nr zamówienia";
            // 
            // labdtOrderDate
            // 
            this.labdtOrderDate.AutoSize = true;
            this.labdtOrderDate.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.labdtOrderDate.Location = new System.Drawing.Point(34, 20);
            this.labdtOrderDate.Name = "labdtOrderDate";
            this.labdtOrderDate.Size = new System.Drawing.Size(88, 13);
            this.labdtOrderDate.TabIndex = 42;
            this.labdtOrderDate.Text = "Data zamówienia";
            // 
            // dtOrderDate
            // 
            this.dtOrderDate.Location = new System.Drawing.Point(121, 16);
            this.dtOrderDate.Margin = new System.Windows.Forms.Padding(1);
            this.dtOrderDate.Name = "dtOrderDate";
            this.dtOrderDate.Size = new System.Drawing.Size(197, 20);
            this.dtOrderDate.TabIndex = 43;
            // 
            // chkPaymend
            // 
            this.chkPaymend.AutoSize = true;
            this.chkPaymend.Location = new System.Drawing.Point(121, 66);
            this.chkPaymend.Name = "chkPaymend";
            this.chkPaymend.Size = new System.Drawing.Size(97, 17);
            this.chkPaymend.TabIndex = 44;
            this.chkPaymend.Text = "Czy zapłacono";
            this.chkPaymend.UseVisualStyleBackColor = true;
            // 
            // frm_OrderNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 157);
            this.Controls.Add(this.chkPaymend);
            this.Controls.Add(this.dtOrderDate);
            this.Controls.Add(this.labdtOrderDate);
            this.Controls.Add(this.cmdReject);
            this.Controls.Add(this.cmdAccept);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.labPrice);
            this.Controls.Add(this.txtInvoice);
            this.Controls.Add(this.labInvoice);
            this.Name = "frm_OrderNew";
            this.Text = "Nowe zamówienie";
            this.Load += new System.EventHandler(this.Frm_CustomerNew_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Button cmdReject;
        internal System.Windows.Forms.Button cmdAccept;
        public System.Windows.Forms.TextBox txtPrice;
        internal System.Windows.Forms.Label labPrice;
        public System.Windows.Forms.TextBox txtInvoice;
        internal System.Windows.Forms.Label labInvoice;
        internal System.Windows.Forms.Label labdtOrderDate;
        private System.Windows.Forms.DateTimePicker dtOrderDate;
        private System.Windows.Forms.CheckBox chkPaymend;
    }
}