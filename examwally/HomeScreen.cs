/*
 *File:     HomeScreen.cs
 *Project:  examwally
 *By:       David Pitters
 *Date:     December 8, 2016
 *Desc:     This file contains the code for the home screen form.
 */
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
    public partial class HomeScreen : Form
    {
        public static Dictionary<int, SalesRec> records = new Dictionary<int, SalesRec>();
        private MySqlCommand comm;
        private MySqlDataReader dr;
        public static MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public HomeScreen()
        {
            InitializeComponent();

            //Connect to the database on startup
            server = "127.0.0.1";
            database = "DPWally";
            uid = "root";
            password = "gmtjb619";
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Connection to " + database + " on " + server + " could not be opened.");
            }

            //Load past orders into sales records

            try
            { 
                //Get the current number of orders
                string query = "SELECT COUNT(OrderID) FROM `Order`";
                comm = new MySqlCommand();
                comm.CommandText = query;
                comm.Connection = connection;
                dr = comm.ExecuteReader();
                int currentNumberOfOrders = 0;
                using (dr)
                {
                    dr.Read();
                    currentNumberOfOrders = Convert.ToInt32(dr.GetString(0));
                    dr.Close();
                }

                //Get the number of rows returned from the big query to be done
                query = "SELECT COUNT(OrderID) FROM ( SELECT Branch.BranchName, `Order`.OrderDate, `Order`.OrderID, Product.ProductName, OrderLine.OrderQuantity, Product.ProductPrice, `Order`.OrderStatus, Customer.CustomerFirstName, Customer.CustomerLastName FROM `Order` INNER JOIN OrderLine ON `Order`.OrderID=OrderLine.OrderID INNER JOIN Product ON OrderLine.ProductID=Product.ProductID INNER JOIN Branch ON `Order`.BranchID=Branch.BranchID INNER JOIN Customer ON `Order`.CustomerID=Customer.CustomerID ) AS dynamicnum";
                comm.CommandText = query;
                int bigQueryRows = 0;
                using (dr = comm.ExecuteReader())
                {
                    dr.Read();
                    bigQueryRows = Convert.ToInt32(dr.GetString(0));
                    dr.Close();
                }
                //Get the OrderID, ProductName, OrderQuantity, Product Price from each orderline
                List<string>[] orderDetails = new List<string>[bigQueryRows];
                int i = 0;
                int j = 0;
                for (i = 0; i < bigQueryRows; i++)
                {
                    orderDetails[i] = new List<string>();
                }
                query = "SELECT Branch.BranchName, `Order`.OrderDate, `Order`.OrderID, Product.ProductName, OrderLine.OrderQuantity, Product.ProductPrice, `Order`.OrderStatus, Customer.CustomerFirstName, Customer.CustomerLastName FROM `Order` INNER JOIN OrderLine ON `Order`.OrderID=OrderLine.OrderID INNER JOIN Product ON OrderLine.ProductID=Product.ProductID INNER JOIN Branch ON `Order`.BranchID=Branch.BranchID INNER JOIN Customer ON `Order`.CustomerID=Customer.CustomerID";
                comm.CommandText = query;
                using (dr = comm.ExecuteReader())
                {
                    for (j = 0; j < bigQueryRows; j++)
                    {
                        dr.Read();
                        for (i = 0; i < 9; i++) //4 columns
                        {
                            orderDetails[j].Add(dr.GetString(i));
                        }
                    }
                    dr.Close();
                }

                List<string>[] prodNames = new List<string>[currentNumberOfOrders];
                j = 0;
                for (i = 0; i < currentNumberOfOrders; i++)
                {
                    prodNames[i] = new List<string>();
                    string currentOrderID = orderDetails[j][2];
                    while ((j < bigQueryRows) && orderDetails[j][2] == currentOrderID)
                    {
                        prodNames[i].Add(orderDetails[j][3]); //Add the product name to the list
                        j++;
                    }
                }

                List<int>[] prodQuan = new List<int>[currentNumberOfOrders];
                j = 0;
                for (i = 0; i < currentNumberOfOrders; i++)
                {
                    prodQuan[i] = new List<int>();
                    string currentOrderID = orderDetails[j][2];
                    while ((j < bigQueryRows) && orderDetails[j][2] == currentOrderID)
                    {
                        prodQuan[i].Add(Convert.ToInt32(orderDetails[j][4])); //Add the quantity to the list
                        j++;
                    }
                }

                List<double>[] prodPrice = new List<double>[currentNumberOfOrders];
                j = 0;
                for (i = 0; i < currentNumberOfOrders; i++)
                {
                    prodPrice[i] = new List<double>();
                    string currentOrderID = orderDetails[j][2];
                    while ((j < bigQueryRows) && orderDetails[j][2] == currentOrderID)
                    {
                        prodPrice[i].Add(Convert.ToDouble(orderDetails[j][5])); //Add the price to the list
                        j++;
                    }
                }

                int theOrderID = 0;
                int offset = 1;
                for (i = 0; offset < bigQueryRows; i++)
                {
                    theOrderID++;
                    SalesRec origRec = new SalesRec(orderDetails[offset][0], orderDetails[offset][1], theOrderID, prodNames[i], prodQuan[i], prodPrice[i], orderDetails[offset][6], orderDetails[offset][7], orderDetails[offset][8]);
                    records.Add(theOrderID, origRec); //Store the record at an index equal to its orderID
                    origRec.createRecord();
                    int beforeoffset = offset;
                    offset += prodNames[i].Count() - 1;
                    if (beforeoffset == offset)
                    {
                        offset++;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Could not create sales records for original orders.");
            }
        }

        /*
         Method:        newOrderBtn_Click
         Parameters:    object sender, EventArgs e
         Returns:       void
         Description:   This event handler creates a new order.
         */
        private void newOrderBtn_Click(object sender, EventArgs e)
        {
            NewOrder newOrd = new NewOrder();
            newOrd.ShowDialog();
        }

        /*
         Method:        manageOrdersBtn_Click
         Parameters:    object sender, EventArgs e
         Returns:       void
         Description:   This event handler lets a user manage orders.
         */
        private void manageOrdersBtn_Click(object sender, EventArgs e)
        {
            OrderManager om = new OrderManager();
            om.ShowDialog();
        }

        /*
         *Method Name:    Window_Closing
         *Parameters:     object sender, CancelEventArgs e
         *Return:         void
         *Description:    This method is used to close the connection 
         *                if the user presses the 'X' button on the window.
         */
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Close the connection with the database
            try
            {
                connection.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Connection to " + server + " could not be closed.");
            }
        }

        /*
         Method:        findSalesRecordBtn_Click
         Parameters:    object sender, EventArgs e
         Returns:       void
         Description:   This event handler lets a user find a sales record.
         */
        private void findSalesRecordBtn_Click(object sender, EventArgs e)
        {
            FindRecord findARecord = new FindRecord();
            findARecord.ShowDialog();
        }

        /*
         Method:        checkInventoryBtn_Click
         Parameters:    object sender, EventArgs e
         Returns:       void
         Description:   This event handler lets a user check current inventory levels.
         */
        private void checkInventoryBtn_Click(object sender, EventArgs e)
        {
            Inventory inven = new Inventory();
            inven.ShowDialog();
        }

    }
}
