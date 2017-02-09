using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace examwally
{
    public partial class Quantity : Form
    {
        public int quantity { get; set; }
        public Quantity()
        {
            InitializeComponent();
        }

        private void setQuantityBtn_Click(object sender, EventArgs e)
        {
            quantity = 0;
            try
            {
                quantity = Convert.ToInt32(setQuantityBox.Text);
            }
            catch (Exception)
            {
                quantity = 0;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
