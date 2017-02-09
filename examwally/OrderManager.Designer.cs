namespace examwally
{
    partial class OrderManager
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
            this.findOrderIDLabel = new System.Windows.Forms.Label();
            this.findOrderIDBox = new System.Windows.Forms.TextBox();
            this.findOrderBtn = new System.Windows.Forms.Button();
            this.cancelOrderBtn = new System.Windows.Forms.Button();
            this.refundOrderBtn = new System.Windows.Forms.Button();
            this.completeOrderBtn = new System.Windows.Forms.Button();
            this.manageLV = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // findOrderIDLabel
            // 
            this.findOrderIDLabel.AutoSize = true;
            this.findOrderIDLabel.Location = new System.Drawing.Point(13, 13);
            this.findOrderIDLabel.Name = "findOrderIDLabel";
            this.findOrderIDLabel.Size = new System.Drawing.Size(50, 13);
            this.findOrderIDLabel.TabIndex = 0;
            this.findOrderIDLabel.Text = "Order ID:";
            // 
            // findOrderIDBox
            // 
            this.findOrderIDBox.Location = new System.Drawing.Point(69, 10);
            this.findOrderIDBox.Name = "findOrderIDBox";
            this.findOrderIDBox.Size = new System.Drawing.Size(100, 20);
            this.findOrderIDBox.TabIndex = 1;
            // 
            // findOrderBtn
            // 
            this.findOrderBtn.Location = new System.Drawing.Point(191, 10);
            this.findOrderBtn.Name = "findOrderBtn";
            this.findOrderBtn.Size = new System.Drawing.Size(75, 23);
            this.findOrderBtn.TabIndex = 2;
            this.findOrderBtn.Text = "Find Order";
            this.findOrderBtn.UseVisualStyleBackColor = true;
            this.findOrderBtn.Click += new System.EventHandler(this.findOrderBtn_Click);
            // 
            // cancelOrderBtn
            // 
            this.cancelOrderBtn.Enabled = false;
            this.cancelOrderBtn.Location = new System.Drawing.Point(325, 10);
            this.cancelOrderBtn.Name = "cancelOrderBtn";
            this.cancelOrderBtn.Size = new System.Drawing.Size(93, 23);
            this.cancelOrderBtn.TabIndex = 3;
            this.cancelOrderBtn.Text = "Cancel Order";
            this.cancelOrderBtn.UseVisualStyleBackColor = true;
            this.cancelOrderBtn.Click += new System.EventHandler(this.cancelOrderBtn_Click);
            // 
            // refundOrderBtn
            // 
            this.refundOrderBtn.Enabled = false;
            this.refundOrderBtn.Location = new System.Drawing.Point(438, 10);
            this.refundOrderBtn.Name = "refundOrderBtn";
            this.refundOrderBtn.Size = new System.Drawing.Size(87, 23);
            this.refundOrderBtn.TabIndex = 4;
            this.refundOrderBtn.Text = "Refund Order";
            this.refundOrderBtn.UseVisualStyleBackColor = true;
            this.refundOrderBtn.Click += new System.EventHandler(this.refundOrderBtn_Click);
            // 
            // completeOrderBtn
            // 
            this.completeOrderBtn.Enabled = false;
            this.completeOrderBtn.Location = new System.Drawing.Point(568, 10);
            this.completeOrderBtn.Name = "completeOrderBtn";
            this.completeOrderBtn.Size = new System.Drawing.Size(98, 23);
            this.completeOrderBtn.TabIndex = 5;
            this.completeOrderBtn.Text = "Complete Order";
            this.completeOrderBtn.UseVisualStyleBackColor = true;
            this.completeOrderBtn.Click += new System.EventHandler(this.completeOrderBtn_Click);
            // 
            // manageLV
            // 
            this.manageLV.Location = new System.Drawing.Point(16, 46);
            this.manageLV.Name = "manageLV";
            this.manageLV.Size = new System.Drawing.Size(1084, 452);
            this.manageLV.TabIndex = 6;
            this.manageLV.UseCompatibleStateImageBehavior = false;
            // 
            // OrderManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 510);
            this.Controls.Add(this.manageLV);
            this.Controls.Add(this.completeOrderBtn);
            this.Controls.Add(this.refundOrderBtn);
            this.Controls.Add(this.cancelOrderBtn);
            this.Controls.Add(this.findOrderBtn);
            this.Controls.Add(this.findOrderIDBox);
            this.Controls.Add(this.findOrderIDLabel);
            this.Name = "OrderManager";
            this.Text = "OrderManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label findOrderIDLabel;
        private System.Windows.Forms.TextBox findOrderIDBox;
        private System.Windows.Forms.Button findOrderBtn;
        private System.Windows.Forms.Button cancelOrderBtn;
        private System.Windows.Forms.Button refundOrderBtn;
        private System.Windows.Forms.Button completeOrderBtn;
        private System.Windows.Forms.ListView manageLV;
    }
}