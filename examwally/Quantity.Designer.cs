namespace examwally
{
    partial class Quantity
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
            this.enterQuantityLabel = new System.Windows.Forms.Label();
            this.setQuantityBox = new System.Windows.Forms.TextBox();
            this.setQuantityBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // enterQuantityLabel
            // 
            this.enterQuantityLabel.AutoSize = true;
            this.enterQuantityLabel.Location = new System.Drawing.Point(95, 81);
            this.enterQuantityLabel.Name = "enterQuantityLabel";
            this.enterQuantityLabel.Size = new System.Drawing.Size(77, 13);
            this.enterQuantityLabel.TabIndex = 0;
            this.enterQuantityLabel.Text = "Enter Quantity:";
            // 
            // setQuantityBox
            // 
            this.setQuantityBox.Location = new System.Drawing.Point(83, 110);
            this.setQuantityBox.Name = "setQuantityBox";
            this.setQuantityBox.Size = new System.Drawing.Size(105, 20);
            this.setQuantityBox.TabIndex = 1;
            // 
            // setQuantityBtn
            // 
            this.setQuantityBtn.Location = new System.Drawing.Point(98, 151);
            this.setQuantityBtn.Name = "setQuantityBtn";
            this.setQuantityBtn.Size = new System.Drawing.Size(75, 48);
            this.setQuantityBtn.TabIndex = 2;
            this.setQuantityBtn.Text = "Set Quantity";
            this.setQuantityBtn.UseVisualStyleBackColor = true;
            this.setQuantityBtn.Click += new System.EventHandler(this.setQuantityBtn_Click);
            // 
            // Quantity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.setQuantityBtn);
            this.Controls.Add(this.setQuantityBox);
            this.Controls.Add(this.enterQuantityLabel);
            this.Name = "Quantity";
            this.Text = "Quantity";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label enterQuantityLabel;
        private System.Windows.Forms.TextBox setQuantityBox;
        private System.Windows.Forms.Button setQuantityBtn;
    }
}