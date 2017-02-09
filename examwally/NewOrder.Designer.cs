namespace examwally
{
    partial class NewOrder
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
            this.newCustBtn = new System.Windows.Forms.Button();
            this.existingCustBtn = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.telephoneLabel = new System.Windows.Forms.Label();
            this.firstNameBox = new System.Windows.Forms.TextBox();
            this.lastNameBox = new System.Windows.Forms.TextBox();
            this.phoneBox = new System.Windows.Forms.TextBox();
            this.custIDLabel = new System.Windows.Forms.Label();
            this.custIDBox = new System.Windows.Forms.TextBox();
            this.invalidNewCustomerLabel = new System.Windows.Forms.Label();
            this.invalidExistingCustomerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // newCustBtn
            // 
            this.newCustBtn.Enabled = false;
            this.newCustBtn.Location = new System.Drawing.Point(12, 90);
            this.newCustBtn.Name = "newCustBtn";
            this.newCustBtn.Size = new System.Drawing.Size(260, 47);
            this.newCustBtn.TabIndex = 0;
            this.newCustBtn.Text = "Shop as New Customer";
            this.newCustBtn.UseVisualStyleBackColor = true;
            this.newCustBtn.Click += new System.EventHandler(this.newCustBtn_Click);
            // 
            // existingCustBtn
            // 
            this.existingCustBtn.Enabled = false;
            this.existingCustBtn.Location = new System.Drawing.Point(12, 231);
            this.existingCustBtn.Name = "existingCustBtn";
            this.existingCustBtn.Size = new System.Drawing.Size(260, 48);
            this.existingCustBtn.TabIndex = 1;
            this.existingCustBtn.Text = "Shop as Existing Customer";
            this.existingCustBtn.UseVisualStyleBackColor = true;
            this.existingCustBtn.Click += new System.EventHandler(this.existingCustBtn_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(5, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(60, 13);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "First Name:";
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(5, 37);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(61, 13);
            this.lastNameLabel.TabIndex = 3;
            this.lastNameLabel.Text = "Last Name:";
            // 
            // telephoneLabel
            // 
            this.telephoneLabel.AutoSize = true;
            this.telephoneLabel.Location = new System.Drawing.Point(5, 65);
            this.telephoneLabel.Name = "telephoneLabel";
            this.telephoneLabel.Size = new System.Drawing.Size(61, 13);
            this.telephoneLabel.TabIndex = 4;
            this.telephoneLabel.Text = "Telephone:";
            // 
            // firstNameBox
            // 
            this.firstNameBox.Location = new System.Drawing.Point(75, 6);
            this.firstNameBox.Name = "firstNameBox";
            this.firstNameBox.Size = new System.Drawing.Size(100, 20);
            this.firstNameBox.TabIndex = 5;
            this.firstNameBox.TextChanged += new System.EventHandler(this.firstNameBox_TextChanged);
            // 
            // lastNameBox
            // 
            this.lastNameBox.Location = new System.Drawing.Point(75, 34);
            this.lastNameBox.Name = "lastNameBox";
            this.lastNameBox.Size = new System.Drawing.Size(100, 20);
            this.lastNameBox.TabIndex = 6;
            this.lastNameBox.TextChanged += new System.EventHandler(this.lastNameBox_TextChanged);
            // 
            // phoneBox
            // 
            this.phoneBox.Location = new System.Drawing.Point(75, 62);
            this.phoneBox.Name = "phoneBox";
            this.phoneBox.Size = new System.Drawing.Size(100, 20);
            this.phoneBox.TabIndex = 7;
            this.phoneBox.TextChanged += new System.EventHandler(this.phoneBox_TextChanged);
            // 
            // custIDLabel
            // 
            this.custIDLabel.AutoSize = true;
            this.custIDLabel.Location = new System.Drawing.Point(5, 208);
            this.custIDLabel.Name = "custIDLabel";
            this.custIDLabel.Size = new System.Drawing.Size(68, 13);
            this.custIDLabel.TabIndex = 8;
            this.custIDLabel.Text = "Customer ID:";
            // 
            // custIDBox
            // 
            this.custIDBox.Location = new System.Drawing.Point(75, 205);
            this.custIDBox.Name = "custIDBox";
            this.custIDBox.Size = new System.Drawing.Size(100, 20);
            this.custIDBox.TabIndex = 9;
            this.custIDBox.TextChanged += new System.EventHandler(this.custIDBox_TextChanged);
            // 
            // invalidNewCustomerLabel
            // 
            this.invalidNewCustomerLabel.AutoSize = true;
            this.invalidNewCustomerLabel.Location = new System.Drawing.Point(13, 144);
            this.invalidNewCustomerLabel.Name = "invalidNewCustomerLabel";
            this.invalidNewCustomerLabel.Size = new System.Drawing.Size(0, 13);
            this.invalidNewCustomerLabel.TabIndex = 10;
            // 
            // invalidExistingCustomerLabel
            // 
            this.invalidExistingCustomerLabel.AutoSize = true;
            this.invalidExistingCustomerLabel.Location = new System.Drawing.Point(16, 286);
            this.invalidExistingCustomerLabel.Name = "invalidExistingCustomerLabel";
            this.invalidExistingCustomerLabel.Size = new System.Drawing.Size(0, 13);
            this.invalidExistingCustomerLabel.TabIndex = 11;
            // 
            // NewOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 311);
            this.Controls.Add(this.invalidExistingCustomerLabel);
            this.Controls.Add(this.invalidNewCustomerLabel);
            this.Controls.Add(this.custIDBox);
            this.Controls.Add(this.custIDLabel);
            this.Controls.Add(this.phoneBox);
            this.Controls.Add(this.lastNameBox);
            this.Controls.Add(this.firstNameBox);
            this.Controls.Add(this.telephoneLabel);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.existingCustBtn);
            this.Controls.Add(this.newCustBtn);
            this.Name = "NewOrder";
            this.Text = "NewOrder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button newCustBtn;
        private System.Windows.Forms.Button existingCustBtn;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.Label telephoneLabel;
        private System.Windows.Forms.TextBox firstNameBox;
        private System.Windows.Forms.TextBox lastNameBox;
        private System.Windows.Forms.TextBox phoneBox;
        private System.Windows.Forms.Label custIDLabel;
        private System.Windows.Forms.TextBox custIDBox;
        private System.Windows.Forms.Label invalidNewCustomerLabel;
        private System.Windows.Forms.Label invalidExistingCustomerLabel;
    }
}