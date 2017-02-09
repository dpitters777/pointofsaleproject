namespace examwally
{
    partial class HomeScreen
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
            this.newOrderBtn = new System.Windows.Forms.Button();
            this.manageOrdersBtn = new System.Windows.Forms.Button();
            this.checkInventoryBtn = new System.Windows.Forms.Button();
            this.findSalesRecordBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newOrderBtn
            // 
            this.newOrderBtn.Location = new System.Drawing.Point(12, 41);
            this.newOrderBtn.Name = "newOrderBtn";
            this.newOrderBtn.Size = new System.Drawing.Size(260, 37);
            this.newOrderBtn.TabIndex = 0;
            this.newOrderBtn.Text = "New Order";
            this.newOrderBtn.UseVisualStyleBackColor = true;
            this.newOrderBtn.Click += new System.EventHandler(this.newOrderBtn_Click);
            // 
            // manageOrdersBtn
            // 
            this.manageOrdersBtn.Location = new System.Drawing.Point(12, 104);
            this.manageOrdersBtn.Name = "manageOrdersBtn";
            this.manageOrdersBtn.Size = new System.Drawing.Size(260, 36);
            this.manageOrdersBtn.TabIndex = 1;
            this.manageOrdersBtn.Text = "Manage Orders";
            this.manageOrdersBtn.UseVisualStyleBackColor = true;
            this.manageOrdersBtn.Click += new System.EventHandler(this.manageOrdersBtn_Click);
            // 
            // checkInventoryBtn
            // 
            this.checkInventoryBtn.Location = new System.Drawing.Point(12, 167);
            this.checkInventoryBtn.Name = "checkInventoryBtn";
            this.checkInventoryBtn.Size = new System.Drawing.Size(260, 38);
            this.checkInventoryBtn.TabIndex = 2;
            this.checkInventoryBtn.Text = "Check Inventory";
            this.checkInventoryBtn.UseVisualStyleBackColor = true;
            this.checkInventoryBtn.Click += new System.EventHandler(this.checkInventoryBtn_Click);
            // 
            // findSalesRecordBtn
            // 
            this.findSalesRecordBtn.Location = new System.Drawing.Point(13, 234);
            this.findSalesRecordBtn.Name = "findSalesRecordBtn";
            this.findSalesRecordBtn.Size = new System.Drawing.Size(259, 38);
            this.findSalesRecordBtn.TabIndex = 3;
            this.findSalesRecordBtn.Text = "Find Sales Record";
            this.findSalesRecordBtn.UseVisualStyleBackColor = true;
            this.findSalesRecordBtn.Click += new System.EventHandler(this.findSalesRecordBtn_Click);
            // 
            // HomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 380);
            this.Controls.Add(this.findSalesRecordBtn);
            this.Controls.Add(this.checkInventoryBtn);
            this.Controls.Add(this.manageOrdersBtn);
            this.Controls.Add(this.newOrderBtn);
            this.Name = "HomeScreen";
            this.Text = "Home";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newOrderBtn;
        private System.Windows.Forms.Button manageOrdersBtn;
        private System.Windows.Forms.Button checkInventoryBtn;
        private System.Windows.Forms.Button findSalesRecordBtn;
    }
}

