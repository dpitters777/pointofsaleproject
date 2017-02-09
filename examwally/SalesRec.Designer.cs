namespace examwally
{
    partial class SalesRec
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
            this.salesRecordBox = new System.Windows.Forms.RichTextBox();
            this.closeSalesRecBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // salesRecordBox
            // 
            this.salesRecordBox.Location = new System.Drawing.Point(12, 12);
            this.salesRecordBox.Name = "salesRecordBox";
            this.salesRecordBox.ReadOnly = true;
            this.salesRecordBox.Size = new System.Drawing.Size(383, 321);
            this.salesRecordBox.TabIndex = 0;
            this.salesRecordBox.Text = "";
            // 
            // closeSalesRecBtn
            // 
            this.closeSalesRecBtn.Location = new System.Drawing.Point(157, 352);
            this.closeSalesRecBtn.Name = "closeSalesRecBtn";
            this.closeSalesRecBtn.Size = new System.Drawing.Size(97, 37);
            this.closeSalesRecBtn.TabIndex = 1;
            this.closeSalesRecBtn.Text = "Close";
            this.closeSalesRecBtn.UseVisualStyleBackColor = true;
            this.closeSalesRecBtn.Click += new System.EventHandler(this.closeSalesRecBtn_Click);
            // 
            // SalesRec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 401);
            this.Controls.Add(this.closeSalesRecBtn);
            this.Controls.Add(this.salesRecordBox);
            this.Name = "SalesRec";
            this.Text = "SalesRec";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox salesRecordBox;
        private System.Windows.Forms.Button closeSalesRecBtn;
    }
}