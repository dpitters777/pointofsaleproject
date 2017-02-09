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
    public partial class SalesRec : Form
    {
        private string branchName { get; set; }
        private string orderDate { get; set; }
        private int orderID { get; set; }
        private List<string> orderedProducts { get; set; }
        private List<int> orderedQuantities { get; set; }
        private List<double> productPrices { get; set; }
        public string orderStatus { get; set; }
        private string customerFname { get; set; }
        private string customerLname { get; set; }
        public string record { get; set; }

        public SalesRec(string branch, string date, int ordID, List<string> products, List<int> quantities, List<double> prices, string status, string fname, string lname)
        {
            InitializeComponent();
            branchName = branch;
            orderDate = date;
            orderID = ordID;
            orderedProducts = products;
            orderedQuantities = quantities;
            productPrices = prices;
            orderStatus = status;
            customerFname = fname;
            customerLname = lname;
        }
        public void createRecord()
        {
            string rec = "Thank you for shopping at Wally's World "
                + branchName + "\nOn " + orderDate + ", " + customerFname + " " + customerLname + "!\n"
                + "Order ID: " + orderID.ToString() + "\n";
            double subtotal = 0;
            for (int i = 0; i < orderedProducts.Count; i++)
            {
                double cost = orderedQuantities[i] * productPrices[i];
                subtotal += cost;
                rec += orderedProducts[i] + " x " + orderedQuantities[i] + " at $" + productPrices[i].ToString("F") + " = $" + cost.ToString("F") + "\n";
            }
            string statusMessage = "Paid - Thank you!";
            if (orderStatus == "PEND")
            {
                statusMessage = "Pending - We'll contact you soon!";
            }
            else if (orderStatus == "CNCL")
            {
                statusMessage = "Cancelled - Please come again!";
            }
            else if (orderStatus == "RFND")
            {
                statusMessage = "Refunded - Please come again!";
            }
            double tax = subtotal * 0.13;
            double total = subtotal + tax;
            rec += "Subtotal: $" + subtotal.ToString("F") + "\n"
                + "HST (13%): $" + tax.ToString("F") + "\n"
                + "Sale Total: $" + total.ToString("F") + "\n\n"
                + statusMessage;
            record = rec;
        }

        public void showRecord()
        {
            salesRecordBox.Text = record;
        }

        private void closeSalesRecBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
