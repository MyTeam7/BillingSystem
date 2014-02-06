using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;          //Add MySql Library
using System.Data;
using System.Windows.Forms;

namespace billing_system.Classes
{
    // Aruna Udayanga--2/5/2014

    /// <summary>
    /// class for dbconnection open, dbconnection close
    /// </summary>
    class ItemDBConnection : DBConnection
    {

        public void Insert(String textboxCode, String txtboxDescription, String txtboxDiscount, String Qty, String txtboxRate, String rate, String txtboxOther)
        {
            string query = "INSERT INTO  (name, age) VALUES('" + textboxCode + "','" + txtboxDescription + "','" + txtboxDiscount + "','" + Qty + "','" + txtboxRate + "','" + rate + "','" + txtboxOther + "')";

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
        public void Update()
        {
            string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

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
        public void Delete()
        {
            string query = "DELETE FROM tableinfo WHERE name='John Smith'";

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
