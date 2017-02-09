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
    public partial class Inventory : Form
    {
        MySqlCommand comm;
        MySqlDataReader dr;
        public const int ProductCols = Checkout.ProductCols;
        public Inventory()
        {
            InitializeComponent();
            comm = new MySqlCommand();
            comm.Connection = HomeScreen.connection;
            loadInventory();
        }

        public void loadInventory()
        {
            //Reuse the code from Checkout.cs

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
            }

            //Format the listview with all the products and their information
            inventoryLV.Columns.Add("Product Name", 175);
            inventoryLV.Columns.Add("Product Type", 150);
            inventoryLV.Columns.Add("Product Price", 100);
            inventoryLV.Columns.Add("Product Quantity", 100);
            inventoryLV.View = View.Details;
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
                inventoryLV.Items.Add(allProducts[j][i]).SubItems.AddRange(rowArray);
            }
        }

        private void closeInventoryBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
