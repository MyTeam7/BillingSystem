using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;          //Add MySql Library
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace billing_system.Classes
{
    // Aruna Udayanga--2/7/2014

    /// <summary>
    /// class for insert/update/delete
    /// </summary>
    class UserDbConnection : DBConnection
    {

        public void Insert(int User_ID, string Name, string Address, int Phone, string User_Name, string Password,String Catagory,String Others)
        {
            string query = "INSERT INTO users(User_ID,Name,Address,Phone,User_Name,Password,Catagory,Others) VALUES('" + User_ID + "','" + Name + "','" + Address + "','" + Phone + "','" + User_Name + "','" + Password + "','" + Catagory + "','" + Others + "')";
            try
            {
                //open connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("you create a new " + Catagory + " : " + User_Name + "");
                    //close connection
                    this.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured," + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Update statement
        public void Update(int User_ID, string Name, string Address, int Phone, string User_Name, string Password, string Catagory, string Others)
        {
            //Regex rx = new Regex("^[+94]")
           
            string query = "UPDATE users SET User_ID='" + User_ID + "', Name='" + Name + "',Address='" + Address + "',Phone='" + Phone + "',User_Name='" + User_Name + "',Password='" + Password + "',Catagory='" + Catagory + "',Others='" + Others + "' WHERE User_ID= '" + User_ID + "'";

            DialogResult dialogResult = MessageBox.Show("Are you sure want to Update?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {

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
                catch (Exception ex)
                {
                    MessageBox.Show("Error Occured," + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        //Delete statement
        public void Delete(int User_ID)
        {
            string query = "Delete from users where User_ID = '" + User_ID + "'";

            DialogResult dialogResult = MessageBox.Show("Are you sure want to Delete?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                try
                {
                    if (this.OpenConnection() == true)
                    {
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.ExecuteNonQuery();

                        this.CloseConnection();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Occured," + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }


    }
}
