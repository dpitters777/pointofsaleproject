/*
 *File:     Checkout.cs
 *Project:  examwally
 *By:       David Pitters
 *Date:     December 8, 2016
 *Desc:     This file contains the code for the Checkout form.
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
using System.Text.RegularExpressions;
namespace examwally
{
    public partial class Checkout : Form
    {
        MySqlCommand comm;
        MySqlDataReader dr;
        string[] orderQuantities;
        Label[] prodQuantities;
        public static Dictionary<int, SalesRec> records = HomeScreen.records;
        string[] currentCustomer;
        private int custID;
        public const int CustomerCols = 3; //CustomerFirstName, CustomerLastName, CustomerTelephone (excluding ID)
        public const int ProductCols = 4; //ProductName, ProductType, ProductPrice, ProductQuantity (excluding ID)
        public const int BranchCols = 2; //BranchID, BranchName
        public bool noErrors;
        public Checkout(int customerID)
        {
            noErrors = true;
            InitializeComponent();
            custID = customerID;
        }

        private void Checkout_Load(object sender, EventArgs e)
        {
            //Get the customer that will be going through checkout
            string query = "SELECT CustomerFirstName, CustomerLastName, CustomerTelephone FROM Customer WHERE CustomerID=" + custID;

            comm = new MySqlCommand();
            comm.CommandText = query;
            comm.Connection = HomeScreen.connection;

            MySqlDataReader dr = comm.ExecuteReader();

            int i = 0;
            currentCustomer = new string[3]; //to hold first name, last name, phone
            try
            {
                using (dr)
                {
                    for (i = 0; i < CustomerCols; i++ )
                    {
                        //Get 1 row from Customer (the specific customerID used)
                        dr.Read();
                        currentCustomer[i] = dr.GetString(i);
                    }
                        
                    dr.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Could not find customer with customer ID " + custID);
                noErrors = false; //exit the window if the current ID could not be found
            }

            UpdateView();
            
            /*Load all the branches into the combobox*/

            //Get the number of branches
            string numBranches = "";
            query = "SELECT COUNT(BranchID) from Branch";
            comm.CommandText = query;
            int j = 0;
            try
            {
                using (dr = comm.ExecuteReader())
                {
                    //Get the single column, single row result (count of BranchID)
                    dr.Read();
                    numBranches = dr.GetString(0);
                    dr.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Could not find number of branches.");
                noErrors = false;
            }
            int numberOfBranches = Convert.ToInt32(numBranches);

            List<string>[] branches = new List<string>[numberOfBranches];
            for (i = 0; i < numberOfBranches; i++)
            {
                branches[i] = new List<string>();
            }
            query = "SELECT BranchID, BranchName from Branch";
            comm.CommandText = query;
            try
            {
                using (dr = comm.ExecuteReader())
                {
                    j = 0;
                    while (j < numberOfBranches)
                    {
                        dr.Read();
                        for (i = 0; i < BranchCols; i++)
                        {
                            branches[j].Add(dr.GetString(i));
                        }
                        j++;
                    }
                    dr.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Could not find branch information.");
                noErrors = false;
            }

            branchComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            //add the branch names to combo box
            for (i = 0; i < numberOfBranches; i++)
            {
                branchComboBox.Items.Add(branches[i][1]); 
            }

            if (!noErrors)
            {
                this.Close();
            }
        }

        private void submitOrderBtn_Click(object sender, EventArgs e)
        {
            noErrors = true;
            //Insert an order into the database and refresh the checkout listview

            //Get the number of Orders so it can be incremented
            string query = "SELECT COUNT(OrderID) FROM `Order`";

            comm.CommandText = query;

            string numOrders = "";
            try
            {
                using (dr = comm.ExecuteReader())
                {
                    //Get the single column, single row result (count of ProductID)
                    dr.Read();
                    numOrders = dr.GetString(0);
                    dr.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Could not find current number of orders.");
                noErrors = false; //query failed. set flag to error
            }
                
            //Get the orderID
            int newOrderID = Convert.ToInt32(numOrders);
            newOrderID++; //increase by 1 to reflect the new order

            //Get the time
            DateTime rightNow = DateTime.Now;
            //Get the branch
            string selectedBranch = "";
            try
            {
                selectedBranch = branchComboBox.SelectedItem.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("No branch selected.");
                noErrors = false;
            }
            if (noErrors)
            {
                query = "SELECT BranchID FROM Branch WHERE BranchName='" + selectedBranch + "'";
                comm.CommandText = query;
                string str_branchID = "";
                try
                {
                    using (dr = comm.ExecuteReader())
                    {
                        dr.Read();
                        str_branchID = dr.GetString(0);
                        dr.Close();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Could not find Branch with Branch Name" + selectedBranch);
                    noErrors = false; //query failed. set flag to error
                }
                int branchID = Convert.ToInt32(str_branchID);
                

                //Find the Quantity of each Ordered Product
                List<int> quantitiesOrdered = new List<int>();
                List<string> productsOrdered = new List<string>();
                try
                {
                    for (int i = 0; i < prodQuantities.Length; i++)
                    {
                        int quan = Convert.ToInt32(prodQuantities[i].Text);
                        if (quan != 0)
                        {
                            quantitiesOrdered.Add(quan);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Value in quantity box was not a number");
                    noErrors = false;
                }
                if (quantitiesOrdered.Count >= 1)
                {
                    //uncheck the checked items with quantity 0
                    foreach (int checkedIndex in itemListBox.CheckedIndices)
                    {
                        int quan = Convert.ToInt32(prodQuantities[checkedIndex].Text);
                        if (quan == 0)
                        {
                            itemListBox.SetItemCheckState(checkedIndex, CheckState.Unchecked);
                        }
                    }
                    foreach (object checkedProduct in itemListBox.CheckedItems)
                    {
                        productsOrdered.Add(checkedProduct.ToString());
                    }

                    //Determine order status
                    int quantityInStock = 0;
                    List<int> quantitiesInStock = new List<int>();
                    string orderStatus = "";
                    bool willBePending = false;
                    for (int i = 0; i < productsOrdered.Count; i++)
                    {
                        query = "SELECT ProductQuantity FROM Product WHERE ProductName='"+productsOrdered[i]+"'";
                        comm.CommandText = query;
                        string str_quantityInStock = "";
                        try
                        {
                            using (dr = comm.ExecuteReader())
                            {
                                dr.Read();
                                str_quantityInStock = dr.GetString(0);
                                dr.Close();
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Could not find Product Quantity from Product where Product Name is "+productsOrdered[i]);
                            noErrors = false; //query failed. set flag to error
                        }
                        try
                        {
                            quantityInStock = Convert.ToInt32(str_quantityInStock);
                            quantitiesInStock.Add(quantityInStock);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Value in ProductQuantity in database is not a number");
                            noErrors = false; //query failed. set flag to error
                        }
                        int quantityOrdered = quantitiesOrdered[i];
                        if (quantityOrdered > quantityInStock)
                        {
                            //The user ordered more than what was in stock.
                            //If even 1 of the items ordered had less in stock that what was ordered, the orderstatus is pending
                            willBePending = true;
                        }
                    }
                    if (willBePending)
                    {
                        //The user ordered more than what was in stock.
                        //If even 1 of the items ordered had less in stock that what was ordered, the orderstatus is pending
                        orderStatus = "PEND";
                    }
                    else
                    {
                        orderStatus = "PAID";
                    }
                    //Insert the order into the database
                    query = "INSERT INTO `Order` (OrderID, OrderDate, CustomerID, OrderStatus, BranchID) VALUES (" + newOrderID + ", '" + rightNow.ToString("yyyy-MM-dd") + "', " + custID + ", '" + orderStatus + "', " + branchID + ")";
                    comm.CommandText = query;
                    try
                    {
                        comm.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Could not insert new order into database.");
                        noErrors = false;
                    }
                    if (noErrors)
                    {
                        List<string> productIDs = new List<string>();
                        for (int i = 0; i < productsOrdered.Count; i++)
                        {
                            //Insert each orderline into the database
                            query = "SELECT ProductID FROM Product WHERE ProductName='" + productsOrdered[i] + "'";
                            comm.CommandText = query;
                            string prodID = "";
                            try
                            {
                                using (dr = comm.ExecuteReader())
                                {
                                    dr.Read();
                                    prodID = dr.GetString(0);
                                    productIDs.Add(prodID);
                                    dr.Close();
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Could not find Product ID from Product where Product Name is " + productsOrdered[i]);
                                noErrors = false; //query failed. set flag to error
                            }

                            query = "INSERT INTO OrderLine (OrderID, ProductID, OrderQuantity) VALUES (" + newOrderID + ", " + prodID + ", " + quantitiesOrdered[i] + ")";
                            comm.CommandText = query;
                            try
                            {
                                comm.ExecuteNonQuery();
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Could not insert new orderline into database.");
                                noErrors = false;
                            }
                        }

                        //If it is paid,
                        //For each product, 
                        //Deduct the ordered number from number in stock in the database
                        if (orderStatus == "PAID")
                        {
                            for (int i = 0; i < productsOrdered.Count; i++)
                            {
                                int difference = quantitiesInStock[i] - quantitiesOrdered[i];
                                query = "UPDATE Product SET ProductQuantity=" + difference + " WHERE ProductID=" + productIDs[i];
                                comm.CommandText = query;
                                try
                                {
                                    comm.ExecuteNonQuery();
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Could not update new ProductQuantity in database.");
                                    noErrors = false;
                                }
                            }
                        }
                        if (noErrors)
                        {
                            //Notify the user if their order is pending or paid
                            if (orderStatus == "PAID")
                            {
                                MessageBox.Show("Order paid. Press OK for more Information.", "Thank you!");
                            }
                            else
                            {
                                MessageBox.Show("Order pending. Press OK for more Information.", "Thank you!");
                            }

                            //Create a new sales record.
                            string currentBranch = branchComboBox.SelectedItem.ToString();
                            //Get the prices of the items ordered
                            List<double> productPrices = new List<double>();
                            int i = 0;
                            for (i = 0; i < productsOrdered.Count; i++)
                            {
                                query = "SELECT ProductPrice FROM Product WHERE ProductID=" + productIDs[i];
                                comm.CommandText = query;
                                string prodPrice = "";
                                try
                                {
                                    using (dr = comm.ExecuteReader())
                                    {
                                        dr.Read();
                                        prodPrice = dr.GetString(0);
                                        double price = Convert.ToDouble(prodPrice);
                                        productPrices.Add(price);
                                        dr.Close();
                                    }
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Could not find Product ID from Product where Product Name is " + productsOrdered[i]);
                                    noErrors = false; //query failed. set flag to error
                                }

                            }
                            SalesRec newSale = new SalesRec(currentBranch, rightNow.ToString("yyyy/MM/dd"), newOrderID, productsOrdered, quantitiesOrdered, productPrices, orderStatus, currentCustomer[0], currentCustomer[1]);
                            records.Add(newOrderID, newSale); //Keep the record at an index equal to its orderID
                            newSale.createRecord();
                            newSale.showRecord();
                            newSale.ShowDialog();
                            //Clear the items listbox before adding to it
                            itemListBox.Items.Clear();
                            //Clear the listview before adding to it
                            checkoutLV.Clear();
                            //Set order quantities to 0
                            for (i = 0; i < prodQuantities.Length; i++)
                            {
                                prodQuantities[i].Text = "0";
                            }
                            //Refresh the view so that user can see updated quantities
                            UpdateView();
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Quantities were all 0.");
                }
            }
        }

        public void UpdateView()
        {
            /*Update the Listview*/
            //Get the number of products
            string query = "SELECT COUNT(ProductID) FROM Product";
            comm.CommandText = query;
            string numProd = "";
            try
            {
                using (dr = comm.ExecuteReader())
                {
                    //Get the single column, single row result (count of ProductID)
                    dr.Read();
                    numProd = dr.GetString(0);
                    dr.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Could not find current number of products.");
                noErrors = false; //exit the window if the query failed
            }
            int numberOfProducts = Convert.ToInt32(numProd);
            List<string>[] allProducts = new List<string>[numberOfProducts];
            int i = 0;
            int j = 0;
            for (i = 0; i < numberOfProducts; i++)
            {
                allProducts[i] = new List<string>();
            }
            //Get the information for each product
            string[] productNames = new string[numberOfProducts];
            query = "SELECT ProductName, ProductType, ProductPrice, ProductQuantity FROM Product";
            comm.CommandText = query;
            j = 0;
            int counter = 0;
            try
            {
                using (dr = comm.ExecuteReader())
                {
                    j = 0;
                    while (j < numberOfProducts)
                    {
                        dr.Read();
                        for (i = 0; i < ProductCols; i++)
                        {
                            allProducts[j].Add(dr.GetString(i));
                            if (i == 0)
                            {
                                //add the product name to the array
                                productNames[counter] = allProducts[j][i];
                                counter++;
                            }
                        }
                        j++;
                    }
                    dr.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Could not find product information.");
                noErrors = false; //exit the window if the query failed
            }
            prodQuantities = new Label[numberOfProducts];
            //Quantity labels
            int leftShift = 5;
            int downShift = 78;
            for (i = 0; i < productNames.Length; i++)
            {
                Point moveLbl = new Point(leftShift, downShift); //start here
                Label myLabel = new Label();
                myLabel.Name = "myLabel" + i;
                myLabel.Location = moveLbl;
                myLabel.Anchor = AnchorStyles.Top;
                myLabel.Text = "0";
                myLabel.Height = itemListBox.GetItemHeight(0);
                myLabel.Width = 200;
                panel1.Controls.Add(myLabel);
                prodQuantities[i] = myLabel;
                downShift += myLabel.Height;
            }

            //Format the listview with all the products and their information
            checkoutLV.Columns.Add("Product Name", 175);
            checkoutLV.Columns.Add("Product Type", 150);
            checkoutLV.Columns.Add("Product Price", 100);
            checkoutLV.Columns.Add("Product Quantity", 100);
            checkoutLV.View = View.Details;
            for (j = 0; j < numberOfProducts; j++)
            {
                List<string> rowToInsert = new List<string>();
                for (i = 1; i < ProductCols; i++)
                {
                    rowToInsert.Add(allProducts[j][i]);
                }
                i = 0;
                //Add the row to the listview
                string[] rowArray = rowToInsert.ToArray();
                checkoutLV.Items.Add(allProducts[j][i]).SubItems.AddRange(rowArray);
            }
            orderQuantities = new string[numberOfProducts];
            /*Update the checklist box*/
            itemListBox.Items.AddRange(productNames);
            
        }

        private void itemListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int index = e.Index;
            if (e.CurrentValue == CheckState.Unchecked)
            {
                //Get the quantity from the user
                var newQuantity = new Quantity();
                var result = newQuantity.ShowDialog();
                if (result == DialogResult.OK && newQuantity.quantity != 0)
                {
                    //Set the quantity to that amount
                    string quantityToSet = newQuantity.quantity.ToString();
                    
                    prodQuantities[index].Text = quantityToSet;
                }
                else
                {
                    //only allow the box to be checked if the quantity is greater than 0
                    itemListBox.SetItemChecked(index, false); //uncheck the box
                    prodQuantities[index].Text = "0"; //set quantity to 0
                }
            }
            else
            {
                prodQuantities[index].Text = "0";
            }
        }
    }
}
