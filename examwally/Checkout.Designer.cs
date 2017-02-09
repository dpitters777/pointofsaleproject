namespace examwally
{
    partial class Checkout
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
            this.checkoutLV = new System.Windows.Forms.ListView();
            this.itemLabel = new System.Windows.Forms.Label();
            this.submitOrderBtn = new System.Windows.Forms.Button();
            this.branchComboBox = new System.Windows.Forms.ComboBox();
            this.branchLabel = new System.Windows.Forms.Label();
            this.itemListBox = new System.Windows.Forms.CheckedListBox();
            this.invalidQuantityLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.quantitiesHeaderLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkoutLV
            // 
            this.checkoutLV.Location = new System.Drawing.Point(12, 12);
            this.checkoutLV.Name = "checkoutLV";
            this.checkoutLV.Size = new System.Drawing.Size(695, 428);
            this.checkoutLV.TabIndex = 0;
            this.checkoutLV.UseCompatibleStateImageBehavior = false;
            // 
            // itemLabel
            // 
            this.itemLabel.AutoSize = true;
            this.itemLabel.Location = new System.Drawing.Point(850, 48);
            this.itemLabel.Name = "itemLabel";
            this.itemLabel.Size = new System.Drawing.Size(76, 13);
            this.itemLabel.TabIndex = 2;
            this.itemLabel.Text = "Items to Order:";
            // 
            // submitOrderBtn
            // 
            this.submitOrderBtn.Location = new System.Drawing.Point(853, 474);
            this.submitOrderBtn.Name = "submitOrderBtn";
            this.submitOrderBtn.Size = new System.Drawing.Size(184, 52);
            this.submitOrderBtn.TabIndex = 5;
            this.submitOrderBtn.Text = "Submit Order";
            this.submitOrderBtn.UseVisualStyleBackColor = true;
            this.submitOrderBtn.Click += new System.EventHandler(this.submitOrderBtn_Click);
            // 
            // branchComboBox
            // 
            this.branchComboBox.FormattingEnabled = true;
            this.branchComboBox.Location = new System.Drawing.Point(713, 76);
            this.branchComboBox.Name = "branchComboBox";
            this.branchComboBox.Size = new System.Drawing.Size(134, 21);
            this.branchComboBox.TabIndex = 7;
            // 
            // branchLabel
            // 
            this.branchLabel.AutoSize = true;
            this.branchLabel.Location = new System.Drawing.Point(709, 48);
            this.branchLabel.Name = "branchLabel";
            this.branchLabel.Size = new System.Drawing.Size(44, 13);
            this.branchLabel.TabIndex = 8;
            this.branchLabel.Text = "Branch:";
            // 
            // itemListBox
            // 
            this.itemListBox.FormattingEnabled = true;
            this.itemListBox.Location = new System.Drawing.Point(853, 76);
            this.itemListBox.Name = "itemListBox";
            this.itemListBox.Size = new System.Drawing.Size(184, 364);
            this.itemListBox.TabIndex = 9;
            this.itemListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.itemListBox_ItemCheck);
            // 
            // invalidQuantityLabel
            // 
            this.invalidQuantityLabel.AutoSize = true;
            this.invalidQuantityLabel.Location = new System.Drawing.Point(1006, 412);
            this.invalidQuantityLabel.Name = "invalidQuantityLabel";
            this.invalidQuantityLabel.Size = new System.Drawing.Size(0, 13);
            this.invalidQuantityLabel.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.quantitiesHeaderLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1043, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 660);
            this.panel1.TabIndex = 10;
            // 
            // quantitiesHeaderLabel
            // 
            this.quantitiesHeaderLabel.AutoSize = true;
            this.quantitiesHeaderLabel.Location = new System.Drawing.Point(4, 47);
            this.quantitiesHeaderLabel.Name = "quantitiesHeaderLabel";
            this.quantitiesHeaderLabel.Size = new System.Drawing.Size(57, 13);
            this.quantitiesHeaderLabel.TabIndex = 0;
            this.quantitiesHeaderLabel.Text = "Quantities:";
            // 
            // Checkout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 660);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.itemListBox);
            this.Controls.Add(this.branchLabel);
            this.Controls.Add(this.branchComboBox);
            this.Controls.Add(this.invalidQuantityLabel);
            this.Controls.Add(this.submitOrderBtn);
            this.Controls.Add(this.itemLabel);
            this.Controls.Add(this.checkoutLV);
            this.Name = "Checkout";
            this.Text = "Checkout";
            this.Load += new System.EventHandler(this.Checkout_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView checkoutLV;
        private System.Windows.Forms.Label itemLabel;
        private System.Windows.Forms.Button submitOrderBtn;
        private System.Windows.Forms.ComboBox branchComboBox;
        private System.Windows.Forms.Label branchLabel;
        private System.Windows.Forms.CheckedListBox itemListBox;
        private System.Windows.Forms.Label invalidQuantityLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label quantitiesHeaderLabel;
    }
}