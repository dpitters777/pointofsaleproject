namespace examwally
{
    partial class FindRecord
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
            this.findSalesRecordBtn2 = new System.Windows.Forms.Button();
            this.findSalesRecordErrorLbl = new System.Windows.Forms.Label();
            this.recordOrderIDLabel = new System.Windows.Forms.Label();
            this.recordOrderIDBox = new System.Windows.Forms.TextBox();
            this.closeFindARecordBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // findSalesRecordBtn2
            // 
            this.findSalesRecordBtn2.Location = new System.Drawing.Point(89, 123);
            this.findSalesRecordBtn2.Name = "findSalesRecordBtn2";
            this.findSalesRecordBtn2.Size = new System.Drawing.Size(97, 33);
            this.findSalesRecordBtn2.TabIndex = 0;
            this.findSalesRecordBtn2.Text = "Find Record";
            this.findSalesRecordBtn2.UseVisualStyleBackColor = true;
            this.findSalesRecordBtn2.Click += new System.EventHandler(this.findSalesRecordBtn2_Click);
            // 
            // findSalesRecordErrorLbl
            // 
            this.findSalesRecordErrorLbl.AutoSize = true;
            this.findSalesRecordErrorLbl.Location = new System.Drawing.Point(12, 230);
            this.findSalesRecordErrorLbl.Name = "findSalesRecordErrorLbl";
            this.findSalesRecordErrorLbl.Size = new System.Drawing.Size(0, 13);
            this.findSalesRecordErrorLbl.TabIndex = 1;
            // 
            // recordOrderIDLabel
            // 
            this.recordOrderIDLabel.AutoSize = true;
            this.recordOrderIDLabel.Location = new System.Drawing.Point(51, 75);
            this.recordOrderIDLabel.Name = "recordOrderIDLabel";
            this.recordOrderIDLabel.Size = new System.Drawing.Size(53, 13);
            this.recordOrderIDLabel.TabIndex = 2;
            this.recordOrderIDLabel.Text = "Order ID: ";
            // 
            // recordOrderIDBox
            // 
            this.recordOrderIDBox.Location = new System.Drawing.Point(110, 72);
            this.recordOrderIDBox.Name = "recordOrderIDBox";
            this.recordOrderIDBox.Size = new System.Drawing.Size(100, 20);
            this.recordOrderIDBox.TabIndex = 3;
            // 
            // closeFindARecordBtn
            // 
            this.closeFindARecordBtn.Location = new System.Drawing.Point(100, 184);
            this.closeFindARecordBtn.Name = "closeFindARecordBtn";
            this.closeFindARecordBtn.Size = new System.Drawing.Size(75, 23);
            this.closeFindARecordBtn.TabIndex = 4;
            this.closeFindARecordBtn.Text = "Close";
            this.closeFindARecordBtn.UseVisualStyleBackColor = true;
            this.closeFindARecordBtn.Click += new System.EventHandler(this.closeFindARecordBtn_Click);
            // 
            // FindRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.closeFindARecordBtn);
            this.Controls.Add(this.recordOrderIDBox);
            this.Controls.Add(this.recordOrderIDLabel);
            this.Controls.Add(this.findSalesRecordErrorLbl);
            this.Controls.Add(this.findSalesRecordBtn2);
            this.Name = "FindRecord";
            this.Text = "FindRecord";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button findSalesRecordBtn2;
        private System.Windows.Forms.Label findSalesRecordErrorLbl;
        private System.Windows.Forms.Label recordOrderIDLabel;
        private System.Windows.Forms.TextBox recordOrderIDBox;
        private System.Windows.Forms.Button closeFindARecordBtn;
    }
}