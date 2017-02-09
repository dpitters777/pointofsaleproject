using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace examwally
{
    public partial class OrderManager : Form
    {
        private int orderID { get; set; }
        private int numOrderLines { get; set; }
        MySqlCommand comm;
        MySqlDataReader dr;

        public OrderManager()
        {
            InitializeComponent();
            comm = new MySqlCommand();
            comm.Connection = HomeScreen.connection;
        }

        private void findOrderBtn_Click(object sender, EventArgs e)
        {
            UpdateManageView();
        }

        public void UpdateManageView()
        {
            //Clear the listview
            manageLV.Clear();

            string query = "";
            try
            {
                orderID = Convert.ToInt32(findOrderIDBox.Text);
                query = "SELECT COUNT(OrderID) from OrderLine WHERE OrderID=" + orderID;
                comm.CommandText = query;
                try
                {
                    using (dr = comm.ExecuteReader())
                    {
                        //Get the single column, single row result (count of OrderID in Orderline)
                        dr.Read();
                        numOrderLines = Convert.ToInt32(dr.GetString(0));
                        dr.Close();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Could not find number of orders", "Error");
                }

                query = "SELECT `Order`.OrderID, Product.ProductName, Product.ProductType, Product.ProductPrice, OrderLine.OrderQuantity, `Order`.OrderDate, `Order`.OrderStatus From `Order` INNER JOIN OrderLine ON `Order`.OrderID = OrderLine.OrderID INNER JOIN Customer ON `Order`.CustomerID = Customer.CustomerID INNER JOIN Product ON OrderLine.ProductID = Product.ProductID WHERE `Order`.OrderID = " + orderID;
                int numberOfCols = 7;
                comm.CommandText = query;

                //Put together key information from each Order and OrderLine in the database.
                List<string>[] orderLines = new List<string>[numOrderLines];
                int i = 0;
                int j = 0;
                for (i = 0; i < numOrderLines; i++)
                {
                    orderLines[i] = new List<string>();
                }
                bool paid = true;
                bool pending = false;
                bool cancelled = false;
                bool refunded = false;
                try
                {
                    using (dr = comm.ExecuteReader())
                    {
                        j = 0;
                        while (j < numOrderLines)
                        {
                            dr.Read();
                            for (i = 0; i < numberOfCols; i++)
                            {
                                orderLines[j].Add(dr.GetString(i));
                                if (i == (numberOfCols-1))
                                {
                                    if (orderLines[j][i] == "PEND")
                                    {
                                        pending = true;
                                        paid = false;
                                        cancelled = false;
                                        refunded = false;
                                    }
                                    else if (orderLines[j][i] == "CNCL")
                                    {
                                        cancelled = true;
                                        pending = false;
                                        paid = false;
                                        refunded = false;
                                    }
                                    else if (orderLines[j][i] == "RFND")
                                    {
                                        refunded = true;
                                        cancelled = false;
                                        pending = false;
                                        paid = false;

                                    }
                                }
                            }
                            j++;
                        }
                        dr.Close();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Could not find Order information", "Error");
                }
                if (pending)
                {
                    //If an order is pending, the user can Cancel or Complete the order
                    cancelOrderBtn.Enabled = true;
                    completeOrderBtn.Enabled = true;
                    refundOrderBtn.Enabled = false;
                }
                else if (paid)
                {
                    //If an order is paid, the user can Refund the order
                    refundOrderBtn.Enabled = true;
                    cancelOrderBtn.Enabled = false;
                    completeOrderBtn.Enabled = false;
                }
                else if (cancelled || refunded || numOrderLines == 0)
                {
                    //If an order is cancelled, refunded, or if no order is found, the user can do nothing to the order
                    refundOrderBtn.Enabled = false;
                    cancelOrderBtn.Enabled = false;
                    completeOrderBtn.Enabled = false;
                }
                //Put the info for each order line into the listview
                //Format the listview with all the products and their information
                manageLV.Columns.Add("Order ID", 100);
                manageLV.Columns.Add("Product Name", 150);
                manageLV.Columns.Add("Product Type", 100);
                manageLV.Columns.Add("Product Price", 100);
                manageLV.Columns.Add("Order Quantity", 100);
                manageLV.Columns.Add("Total", 100);
                manageLV.Columns.Add("Order Date", 175);
                manageLV.Columns.Add("Order Status", 100);
                manageLV.View = View.Details;
                for (j = 0; j < numOrderLines; j++)
                {
                    List<string> rowToInsert = new List<string>();
                    for (i = 1; i < numberOfCols; i++)
                    {
                        if (i == 5)//calculate and insert the total into the listview
                        {
                            double price = Convert.ToDouble(orderLines[j][3]);
                            double quantity = Convert.ToDouble(orderLines[j][4]);
                            double total = price * quantity;
                            rowToInsert.Add("$"+total.ToString("F"));
                            
                        }
                        rowToInsert.Add(orderLines[j][i]);
                        
                    }
                    i = 0;
                    //Add the row to the listview
                    string[] rowArray = rowToInsert.ToArray();
                    manageLV.Items.Add(orderLines[j][i]).SubItems.AddRange(rowArray);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Could not find Order", "Error");
            }
        }

        private void cancelOrderBtn_Click(object sender, EventArgs e)
        {
            //Set the order status to cancelled for the order being managed
            string query = "UPDATE `Order` SET OrderStatus='CNCL' WHERE OrderID=" + orderID;
            comm.CommandText = query;
            try
            {
                comm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Could not update Orderstatus in database.", "Error");
            }
            try
            { 
                //Update the final message in the sales record
                Checkout.records[orderID].orderStatus = "CNCL";
            }
            catch (Exception)
            {
                MessageBox.Show("Could not change order status to CNCL.");
            }

            //Reflect changes in the list view
            UpdateManageView();
        }

        private void refundOrderBtn_Click(object sender, EventArgs e)
        {
            //For each orderline in the order, 
            //Set the product quantity back to what it was before
            List<string> productIDs = new List<string>();
            string query = "SELECT ProductID from OrderLine WHERE OrderID=" + orderID;
            comm.CommandText = query;
            int i = 0;
            int j = 0;
            try
            {
                using (dr = comm.ExecuteReader())
                {
                    j = 0;
                    while (j < numOrderLines)
                    {
                        for (i = 0; i < 1; i++)//Get x rows from 1 column
                        {
                            dr.Read();
                            productIDs.Add(dr.GetString(i));
                        }
                        j++;
                     }
                    dr.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Could not find ProductID from OrderLine Where OrderID is " + orderID, "Error");
            }

            //Get the current product quantities
            List<string> productQuantities = new List<string>();
            try
            {
                using (dr)
                {
                    j = 0;
                    while (j < numOrderLines)
                    {
                        query = "SELECT ProductQuantity FROM Product WHERE ProductID=" + productIDs[j];
                        comm.CommandText = query;
                        dr = comm.ExecuteReader();
                        for (i = 0; i < 1; i++)//Get x rows from 1 column
                        {
                            dr.Read();
                            productQuantities.Add(dr.GetString(i));
                        }
                        dr.Close();
                        j++;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Could not find ProductQuantity from Product Where Product ID is "+productIDs[j], "Error");
            }

            //Get the ordered product quantities
            //Get the current product quantities
            List<string> orderQuantities = new List<string>();

            query = "SELECT OrderQuantity FROM OrderLine WHERE OrderID=" + orderID;
            comm.CommandText = query;
            try
            {
                using (dr = comm.ExecuteReader())
                {
                    j = 0;
                    while (j < numOrderLines)
                    {
                        for (i = 0; i < 1; i++)//Get x rows from 1 column
                        {
                            dr.Read();
                            orderQuantities.Add(dr.GetString(i));
                        }
                        j++;
                    }
                    dr.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Could not find OrderQuantity from OrderLine Where Order ID is " + orderID, "Error");
            }

            List<int> sums = new List<int>();
            for (i = 0; i < numOrderLines; i++)
            {
                int ordered = Convert.ToInt32(orderQuantities[i]);
                int stock = Convert.ToInt32(productQuantities[i]);
                sums.Add(ordered + stock);
            }

            //Add the refunded products back into stock
            for (i = 0; i < numOrderLines; i++)
            {
                query = "UPDATE Product SET ProductQuantity="+sums[i]+" WHERE ProductID=" + productIDs[i];
                comm.CommandText = query;
                try
                {
                    comm.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Could not update ProductQuantity in database.", "Error");
                }

            }

            //Set the order status to refunded for the order being managed
            query = "UPDATE `Order` SET OrderStatus='RFND' WHERE OrderID=" + orderID;
            comm.CommandText = query;
            try
            {
                comm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Could not update Orderstatus in database.", "Error");
            }

            //Set the quantity ordered to 0 for the OrderLines
            query = "UPDATE OrderLine SET OrderQuantity=0 WHERE OrderID=" + orderID;
            comm.CommandText = query;
            try
            {
                comm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Could not update Orderstatus in database.", "Error");
            }

            try
            {
                //Update the final message in the sales record
                Checkout.records[orderID].orderStatus = "RFND";
            }
            catch (Exception)
            {
                MessageBox.Show("Could not change order status to RFND.");
            }
            //Reflect changes in the list view
            UpdateManageView();
        }

        private void completeOrderBtn_Click(object sender, EventArgs e)
        {
            //Set the order status to paid for the order being managed
            string query = "UPDATE `Order` SET OrderStatus='PAID' WHERE OrderID=" + orderID;
            comm.CommandText = query;
            try
            {
                comm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Could not update Orderstatus in database.", "Error");
            }
            try
            {
                //Update the final message in the sales record
                Checkout.records[orderID].orderStatus = "PAID";
            }
            catch (Exception)
            {
                MessageBox.Show("Could not change order status to PAID.");
            }

            //Reflect changes in the list view
            UpdateManageView();
        }
    }
}
