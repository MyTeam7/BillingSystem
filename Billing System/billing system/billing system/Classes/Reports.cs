using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using MySql.Data.MySqlClient;

namespace billing_system.Classes
{
    //------------------------------Dilanka Rathnayaka-----------------2/9/2012--------------------------
    /// <summary>
    /// Class for Reporting
    /// </summary>
    class Reports : DBConnection
    {
        public void FormLoadDateTimePicker(DateTimePicker dPick2) 
        {
            dPick2.MaxDate = DateTime.Now;
        }

        //Set Item to Cashier combobox
        public void FormLoadComboBox(ComboBox ComBo) 
        {
            OpenConnection();
            
            string Quary = "SELECT Name FROM users";
            MySqlCommand command = new MySqlCommand(Quary, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string temp = reader.GetString(0);
                ComBo.Items.Add(temp);
            }
            reader.Close();
            CloseConnection();
        }
    }            

}
