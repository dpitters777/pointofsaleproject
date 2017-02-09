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
    public partial class FindRecord : Form
    {
        public int orderID { get; set; }
        public FindRecord()
        {
            InitializeComponent();
        }
        private void findSalesRecordBtn2_Click(object sender, EventArgs e)
        {
            int orderID = 0;
            try
            {
                //Find the sales record with the OrderID provided.
                orderID = Convert.ToInt32(recordOrderIDBox.Text);
                SalesRec checkRec = Checkout.records[orderID];
                checkRec.createRecord();
                checkRec.showRecord();
                checkRec.ShowDialog();
            }
            catch (Exception exc)
            {
                if (exc.Message == "The given key was not present in the dictionary.")
                {
                    findSalesRecordErrorLbl.Text = "The sales record for OrderID " + orderID.ToString() + " does not exist.";
                }
                else
                {
                    findSalesRecordErrorLbl.Text = "Please enter a number in the box.";
                }
            }
        }

        private void closeFindARecordBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
