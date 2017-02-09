/*
 *File:     NewOrder.cs
 *Project:  examwally
 *By:       David Pitters
 *Date:     December 8, 2016
 *Desc:     This file contains the code for the new order form.
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
    public partial class NewOrder : Form
    {

        public NewOrder()
        {
            InitializeComponent();
        }
        /*
         Method:        newCustBtn_Click
         Parameters:    object sender, EventArgs e
         Returns:       void
         Description:   This event handler
         */
        private void newCustBtn_Click(object sender, EventArgs e)
        {
            //Get the user input
            string fname = firstNameBox.Text;
            string lname = lastNameBox.Text;
            string phone = phoneBox.Text;

            //check that first name last name and phone are valid format
            Regex nameReg = new Regex(@"^[a-zA-Z]+(([\'\,\.\-][a-zA-Z])?[a-zA-Z]*)*$"); //By Hayk A, from http://regexlib.com/Search.aspx?k=first+name&c=-1&m=-1&ps=20
            Match nameMatch = nameReg.Match(fname);
            if (nameMatch.Success) //Check for valid first name
            {
                nameMatch = nameReg.Match(lname);
                if (nameMatch.Success) ///Check for valid last name
                {
                    Regex phoneReg = new Regex(@"^\D?(\d{3})\D?\D?(\d{3})\D?(\d{4})$"); //By Laurence O, from http://regexlib.com/Search.aspx?k=phone&c=-1&m=-1&ps=20
                    Match phoneMatch = phoneReg.Match(phone);
                    if (phoneMatch.Success)
                    {
                        invalidNewCustomerLabel.Text = "";
                        /*Create a new user ID*/

                        //Get current number of customers
                        string query = "SELECT COUNT(CustomerID) from Customer";
                        MySqlCommand comm = new MySqlCommand(query, HomeScreen.connection);
                        string howManyCustomers = "";
                        MySqlDataReader dr = comm.ExecuteReader();
                        try
                        {
                            using (dr)
                            {
                                //Get the single column, single row result (count of CustomerID)
                                dr.Read();
                                howManyCustomers = dr.GetString(0);
                                dr.Close();
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Could not find current number of customers.");
                        }
                        int newID = 0;
                        try
                        {
                            newID = Convert.ToInt32(howManyCustomers) + 1;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Current number of customers was not a number");
                        }
                        //Insert the new customer into the database
                        query = "INSERT INTO Customer(CustomerID, CustomerFirstName, CustomerLastName, CustomerTelephone) VALUES (" + newID.ToString() + ", '" + fname + "', '" + lname + "', '" + phone + "')";
                        comm.CommandText = query;
                        try
                        {
                            using (dr)
                            {
                                comm.ExecuteNonQuery();
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Could not insert new customer into database.");
                        }

                        Checkout newCheckout = new Checkout(newID);
                        newCheckout.Show();
                        this.Close();
                    }
                    else
                    {
                        invalidNewCustomerLabel.Text = "Invalid phone format.";
                    }
                }
                else
                {
                    invalidNewCustomerLabel.Text = "Invalid last name format.";
                }
            }
            else
            {
                invalidNewCustomerLabel.Text = "Invalid first name format.";
            }
        }

        /*
         Method:        existingCustBtn_Click
         Parameters:    object sender, EventArgs e
         Returns:       void
         Description:   This event handler
         */
        private void existingCustBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(custIDBox.Text);
                Checkout newCheckout = new Checkout(id);
                newCheckout.Show();
                this.Close();
            }
            catch (Exception)
            {
                invalidExistingCustomerLabel.Text = "Please enter a number into the box.";
            }
        }

        /*
         Method:        custIDBox_TextChanged
         Parameters:    object sender, EventArgs e
         Returns:       void
         Description:   This event handler checks that the customerID field is filled out
         *              before the shop as existing customer button is activated.
         */
        private void custIDBox_TextChanged(object sender, EventArgs e)
        {
            //If all fields are filled out, enable continue button
            if (custIDBox.Text != "")
            {
                existingCustBtn.Enabled = true;
            }
        }

        /*
         Method:        firstNameBox_TextChanged
         Parameters:    object sender, EventArgs e
         Returns:       void
         Description:   This event handler checks that all customer information fields are filled out
         *              before the shop as new customer button is activated.
         */
        private void firstNameBox_TextChanged(object sender, EventArgs e)
        {
            //If all fields are filled out, enable continue button
            if (firstNameBox.Text != "" && lastNameBox.Text != "" && phoneBox.Text != "")
            {
                newCustBtn.Enabled = true;
            }
            else
            {
                newCustBtn.Enabled = false;
            }
        }

        /*
         Method:        lastNameBox_TextChanged
         Parameters:    object sender, EventArgs e
         Returns:       void
         Description:  This event handler checks that all customer information fields are filled out
         *              before the shop as  new customer button is activated.
         */
        private void lastNameBox_TextChanged(object sender, EventArgs e)
        {
            //If all fields are filled out, enable continue button
            if (firstNameBox.Text != "" && lastNameBox.Text != "" && phoneBox.Text != "")
            {
                newCustBtn.Enabled = true;
            }
            else
            {
                newCustBtn.Enabled = false;
            }
        }

        /*
         Method:        phoneBox_TextChanged
         Parameters:    object sender, EventArgs e
         Returns:       void
         Description:   This event handler checks that all customer information fields are filled out
         *              before the shop as  new customer button is activated.
         */
        private void phoneBox_TextChanged(object sender, EventArgs e)
        {
            //If all fields are filled out, enable continue button
            if (firstNameBox.Text != "" && lastNameBox.Text != "" && phoneBox.Text != "")
            {
                newCustBtn.Enabled = true;
            }
            else
            {
                newCustBtn.Enabled = false;
            }
        }
    }
}
