namespace examwally
{
    partial class Inventory
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
            this.inventoryLV = new System.Windows.Forms.ListView();
            this.closeInventoryBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inventoryLV
            // 
            this.inventoryLV.Location = new System.Drawing.Point(13, 13);
            this.inventoryLV.Name = "inventoryLV";
            this.inventoryLV.Size = new System.Drawing.Size(598, 420);
            this.inventoryLV.TabIndex = 0;
            this.inventoryLV.UseCompatibleStateImageBehavior = false;
            // 
            // closeInventoryBtn
            // 
            this.closeInventoryBtn.Location = new System.Drawing.Point(280, 448);
            this.closeInventoryBtn.Name = "closeInventoryBtn";
            this.closeInventoryBtn.Size = new System.Drawing.Size(100, 44);
            this.closeInventoryBtn.TabIndex = 1;
            this.closeInventoryBtn.Text = "Close";
            this.closeInventoryBtn.UseVisualStyleBackColor = true;
            this.closeInventoryBtn.Click += new System.EventHandler(this.closeInventoryBtn_Click);
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 514);
            this.Controls.Add(this.closeInventoryBtn);
            this.Controls.Add(this.inventoryLV);
            this.Name = "Inventory";
            this.Text = "Inventory";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView inventoryLV;
        private System.Windows.Forms.Button closeInventoryBtn;
    }
}