/*
 *File:     DBConnect.cs
 *Project:  examwally
 *By:       David Pitters
 *Date:     December 8, 2016
 *Desc:     This file contains the class that is used to connect to and make commands with
 *          the database.
 *          Code modified from https://www.codeproject.com/articles/43438/connect-c-to-mysql
 *          and re-used from my Lab 3 and Lab 4.
 */
using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace examwally
{
    /*
     Class Name:    DBConnect
     Description:   This class is used to execute SQL statements. It supports
                    INSERT and SELECT statements.
    */
    public class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }
        //Constructor
        public DBConnect(string serverName, string dbName, string uid, string password)
        {
            Initialize(serverName, dbName, uid, password);
        }

        /*
        Method Name:   Initialize
        Parameters:         None
        Returns:            bool    -whether the connection was closed or not.
        Description:        Used by the default constructor. Connects to localhost by default.
        */
        private void Initialize()
        {
            server = "127.0.0.1";
            database = "world";
            uid = "root";
            password = "gmtbjp619";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        /*
        Method Name:   Initialize
        Parameters:    string   serverName  -the name of the server to connect to
                       string   dbName      -the name of the database to connect to
                       string   user        -the name of the user to use
                       string   pwd         -the password of the user
        Returns:       bool                -whether the connection was closed or not.
        Description:   Used by a second version of the constructor. Takes the server name, database name, user and password to use as an arguments.
        */
        private void Initialize(string serverName, string dbName, string user, string pwd)
        {
            server = serverName;
            database = dbName;
            uid = user;
            password = pwd;
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        /*
        Method Name:    OpenConnection
        Parameters:     None
        Returns:        bool    -whether the connection was opened or not.
        Description:    This method opens the connection to the database.
        */
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        /*
        Method Name:    CloseConnection
        Parameters:     None
        Returns:        bool    -whether the connection was closed or not.
        Description:    This method closes the connection to the database.
        */
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /*
        Method Name:    Insert
        Parameters:     string table    -the name of the table
                        string[] cols   -the columns to insert into
                        string[] vals   -the values to insert
        Returns:        bool success    -indicates whether the insert was successful or not
        Description:    This method executes an INSERT statement on the table specified.
        */
        public bool Insert(string table, string[] cols, string[] vals)
        {
            bool success = true;
            string columns = ColumnsOrValuesToSelectOrInsert(cols);
            string values = ColumnsOrValuesToSelectOrInsert(vals);
            string query = "INSERT INTO " + table + "(" + columns + ")" + " VALUES (" + values + ");";
            //Insert the data using the prefix supplied on the command line and the current iteration number (1-10000)
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = query;
            comm.Connection = connection;
            try
            {
                comm.ExecuteNonQuery(); //Try to execute the query
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                success = false; //Something went wrong, return false
            }
            return success;
        }

        /*
        Method Name:    Select
        Parameters:     string      table       -The name of the table
                        string[]    columns     -All the columns that will be looked up
                        string      condition   -The WHERE x=y condition string
                        bool        usingPK     -Whether the condition uses the Primary Key or not
                        out bool    errFlag     -Bool that is set to TRUE if an exception was caught
        Returns:        List<string>[] cols     -An array of lists of strings. Each list of strings contains 1 column of the table.
        Description:    This method executes a SELECT query on the columns in the table specified, based on the condition given.
                        It returns all columns in separate lists of strings.
        */
        public List<string>[] Select(string table, string[] columns, string condition, bool usingPK, out bool errFlag)
        {
            errFlag = false;
            int numberOfColsToQuery = columns.Length;
            int rowCount = SelectCount(table, columns[0], null);
            List<string>[] cols = new List<string>[numberOfColsToQuery]; //used to store the results
            for (int c = 0; c < numberOfColsToQuery; c++)
            {
                cols[c] = new List<string>();
            }
            string theColumns = ColumnsOrValuesToSelectOrInsert(columns);
            string query = "SELECT " + theColumns + " from " + table; //query the database with a SELECT all statement
            if (condition != null)
            {
                //Add the WHERE condition on to the query
                query += " " + condition;
            }
            MySqlCommand command = new MySqlCommand();
            command.CommandText = query;
            command.Connection = connection;
            try
            {
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    int i = 0;
                    if (usingPK && condition != null)
                    {
                        //return only 1 row since they are using a WHERE on primary key (only 1 will return from query)
                        while (i < numberOfColsToQuery)
                        {
                            dr.Read();
                            cols[i].Add(dr.GetString(i)); //Populate the list of strings with the information from the column
                            i++;
                        }
                    }
                    else
                    {
                        //return multiple rows
                        int j = 0;
                        while (j < rowCount)
                        {
                            dr.Read();
                            for (i = 0; i < numberOfColsToQuery; i++)
                            {
                                cols[i].Add(dr.GetString(i)); //Populate the list of strings with the information from the column
                            }
                            //move to the next row
                            j++;
                        }
                    }
                    dr.Close();
                }
            }
            catch (Exception)
            {
                errFlag = true;
            }
            return cols;
        }


        public List<string>[] SelectCustom(string entireQuery, string table, string anyRow, string cond, out bool errFlag, out int numberOfOrders)
        {
            errFlag = false;
            string[] parser = entireQuery.Split(','); //get number of columns based on how many commas
            int rowCount = SelectCount(table, anyRow, cond);
            numberOfOrders = rowCount;
            int numberOfColsToQuery = parser.Length + 1; //5, the 6th is generated on front end (total: quantity * price)
            List<string>[] cols = new List<string>[numberOfColsToQuery]; //used to store the results
            for (int c = 0; c < numberOfColsToQuery; c++)
            {
                cols[c] = new List<string>();
            }

            string query = entireQuery;
            MySqlCommand command = new MySqlCommand();
            command.CommandText = query;
            command.Connection = connection;
            try
            {
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    int i = 0;
                    //return multiple rows
                    int j = 0;
                    while (j < rowCount)
                    {
                        dr.Read();
                        for (i = 0; i < numberOfColsToQuery; i++)
                        {
                            if (i == numberOfColsToQuery - 1)
                            {
                                cols[i].Add("");
                            }
                            else
                            {
                                cols[i].Add(dr.GetString(i)); //Populate the list of strings with the information from the column
                            }
                        }
                        //move to the next row
                        j++;
                    }
                    dr.Close();
                }
            }
            catch (Exception)
            {
                errFlag = true;
            }
            return cols;
        }

        public List<string>[] SelectCustom(string entireQuery, string table, string anyRow, out bool errFlag)
        {
            errFlag = false;
            string[] parser = entireQuery.Split(','); //get number of columns based on how many commas
            int numberOfColsToQuery = parser.Length;
            if (parser.Length > 1)
            {
                numberOfColsToQuery = parser.Length + 1;
            }
            int rowCount = SelectCount(table, anyRow, null);
            List<string>[] cols = new List<string>[numberOfColsToQuery]; //used to store the results
            for (int c = 0; c < numberOfColsToQuery; c++)
            {
                cols[c] = new List<string>();
            }

            string query = entireQuery;
            MySqlCommand command = new MySqlCommand();
            command.CommandText = query;
            command.Connection = connection;
            try
            {
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    int i = 0;
                    //return multiple rows
                    int j = 0;
                    while (j < rowCount)
                    {
                        dr.Read();
                        for (i = 0; i < numberOfColsToQuery; i++)
                        {
                            cols[i].Add(dr.GetString(i)); //Populate the list of strings with the information from the column
                        }
                        //move to the next row
                        j++;
                    }
                    dr.Close();
                }
            }
            catch (Exception)
            {
                errFlag = true;
            }
            return cols;
        }

        /*
        Method Name:    SelectCount
        Parameters:     string table    -the name of the table
                        string column   -the column of the table
        Returns:        int count       -the number of entries in the column.
        Description:    This method executes a SELECT COUNT query on the specified table and column
                        and returns the current number of entries in that column.
        */
        public int SelectCount(string table, string column, string condition)
        {
            int count = 0; //used to store the number of entries in the column

            string query = "SELECT COUNT(" + column + ") from " + table; //query the database with a SELECT count statement
            if (condition != null)
            {
                query += " " + condition;
            }
            MySqlCommand command = new MySqlCommand();
            command.CommandText = query;
            command.Connection = connection;
            try
            {
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    dr.Read();
                    count = dr.GetInt32(0);
                    dr.Close();
                }
            }
            catch (Exception)
            {
                //column did not exist, return -1 to indicate error
                count = -1;
            }
            return count;
        }

        /*
        Method Name:    Remove
        Parameters:     string table    -the name of the table
                        string prefix   -the sample data
                        int iteration   -the id
        Returns:        bool success    -indicates whether the deletion was successful or not
        Description:    This method executes a REMOVE statement on the table specified.
        */
        public bool Delete(string table, string[] cols, string[] vals, string condition)
        {
            bool success = false;
            string columns = ColumnsToModify(cols, vals);
            //Put together the delete command string with the values set by the user
            string query = "DELETE from " + table;
            if (condition != null)
            {
                //Add the WHERE condition on to the query
                query += " " + condition;
            }
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = query;
            comm.Connection = connection;
            try
            {
                comm.ExecuteNonQuery(); //Try to execute the query
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                success = false; //Something went wrong, return false
            }
            return success;
        }
        /*
        Method Name:    Update
        Parameters:     string table    -the name of the table
                        string prefix   -the sample data
                        int iteration   -the id
        Returns:        bool success    -indicates whether the update was successful or not
        Description:    This method executes an UPDATE statement on the table specified.
        */
        public bool Update(string table, string[] cols, string[] vals, string condition)
        {
            bool success = true;
            string columns = ColumnsToModify(cols, vals);
            //Put together the update command string with the values set by the user
            string query = "UPDATE " + table + " SET " + columns;
            if (condition != null)
            {
                //Add the WHERE condition on to the query
                query += " " + condition;
            }
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = query;
            comm.Connection = connection;
            try
            {
                comm.ExecuteNonQuery(); //Try to execute the query
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                success = false; //Something went wrong, return false
            }
            return success;
        }

        /*
       Method Name:    ColumnsToModify
       Parameters:     string[] cols   -the columns to update
                       string[] vals   -the values to updates the columns with
       Returns:        bool success    -indicates whether the update was successful or not
       Description:    This method formats columns and values for UPDATE and REMOVE.
       */
        public string ColumnsToModify(string[] cols, string[] vals)
        {
            string columns = "";
            int i = 0;
            for (i = 0; i < cols.Length; i++)
            {
                columns += cols[i] + "=" + vals[i];
                if (i != (cols.Length - 1))
                {
                    columns += ", "; //Only add a comma if its not the last column
                };
            }
            return columns;
        }

        public string ColumnsOrValuesToSelectOrInsert(string[] colsOrVals)
        {
            string columnsOrValues = "";
            int i = 0;
            for (i = 0; i < colsOrVals.Length; i++)
            {
                columnsOrValues += colsOrVals[i];
                if (i != (colsOrVals.Length - 1))
                {
                    columnsOrValues += ", "; //Only add a comma if its not the last column
                };
            }
            return columnsOrValues;
        }
    }
    
}
