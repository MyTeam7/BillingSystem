using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;          //Add MySql Library
using System.Data;
using System.Windows.Forms;

namespace billing_system.Classes
{
    // Aruna Udayanga--2/7/2014

    /// <summary>
    /// class for dbconnection open, dbconnection close
    /// </summary>
    class UserDbConnection : DBConnection
    {
        public void Insert(String textboxCode, String txtboxDescription, String txtboxDiscount, String lowestPrice, String price, String txtboxOther)
        {
            string query = "INSERT INTO  (Item_Code,Description,Discount,Lowest_Price,Others) VALUES('" + textboxCode + "','" + txtboxDescription + "','" + txtboxDiscount + "','" + lowestPrice + "','" + price + "','" + txtboxOther + "')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        public void Update(String textboxCode, String txtboxDescription, String txtboxDiscount, String lowestPrice, String price, String txtboxOther)
        {
            string query = "UPDATE items SET Item_Code='" + textboxCode + "', Description='" + txtboxDescription + "',Discount='" + txtboxDiscount + "',Lowest_Price='" + lowestPrice + "',price='" + price + "',Others='" + txtboxOther + "' WHERE Item_Code= '" + textboxCode + "'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete(String textboxCode)
        {
            string query = "Delete from items where Item_Code = '" + textboxCode + "'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
        //search statement
        public void Search()
        {

            string query = "DELETE FROM tableinfo WHERE name='John Smith'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable table = new DataTable();
                adapter.Fill(table);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = table;
                //dataGridView1.DataSource = table;
                adapter.Update(table);
                this.CloseConnection();
            }
        }


    }
}
