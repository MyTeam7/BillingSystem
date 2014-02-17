using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;


namespace billing_system.Classes
{
    //-----------------------Dilanka Rathnayaka---------------------2/9/2014--------------------
    /// <summary>
    /// Class for Report Generate
    /// </summary>
    class Reports : DBConnection
    {
        public void FormLoadDateTimePicker(DateTimePicker dPick1, DateTimePicker dPick2)
        {
            //To is set to system date
            dPick2.MaxDate = DateTime.Now;

            //From date set to date of the first record in the item_info table
            OpenConnection();

            string Quary = "SELECT Purchase_Date FROM bills_info ORDER BY Purchase_Date asc limit 1";

            MySqlCommand command = new MySqlCommand(Quary, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //string temp = reader.GetString(0);
                DateTime temp = reader.GetDateTime(0);
                dPick1.MinDate = temp;
            }
            reader.Close();
            dPick1.MaxDate = DateTime.Now;
            CloseConnection();
        }


        //Set Item to Cashier combobox
        public void FormLoadComboBox(ComboBox ComBo1, ComboBox Combo2)
        {
            ComBo1.SelectedIndex = 0;
            Combo2.SelectedIndex = 0;


            OpenConnection();

            string Quary = "SELECT Name FROM users WHERE Catagory = 'user'";
            MySqlCommand command = new MySqlCommand(Quary, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string temp = reader.GetString(0);
                ComBo1.Items.Add(temp);
            }
            reader.Close();
            CloseConnection();
        }

        //Set Items to combobox when type
        public void ComboBoxTextchange(ComboBox cmb, string text)
        {
            OpenConnection();
            string Quary = "SELECT Description FROM items WHERE Description LIKE '" + text + "%'";
            MySqlCommand command = new MySqlCommand(Quary, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string temp = reader.GetString(0);
                cmb.Items.Add(temp);
            }
            reader.Close();
        }

        //DONE Button click event
        public void DoneButtonClick(ComboBox cmb1, ComboBox cmb2, ComboBox cmb3, DateTimePicker dPick1, DateTimePicker dPick2, DataGridView gDView)
        {
            gDView.DataSource = null;

            DateTime dt1 = dPick1.Value.Date;
            DateTime dt2 = dPick2.Value.Date;
            string a = dt1.ToString("yyyy/MM/dd");
            string b = dt2.ToString("yyyy/MM/dd");
            string c = cmb2.SelectedItem.ToString();
            string d = cmb1.SelectedItem.ToString();
            string uNameTemp = null;


            int switchCase = 0;
            string quary;

            if (cmb1.SelectedIndex == 1 && cmb2.SelectedIndex == 0)
            {
                switchCase = 2;
            }
            else if (cmb1.SelectedIndex == 1 && cmb2.SelectedIndex == 1)
            {
                switchCase = 1;
            }
            else if (cmb1.SelectedIndex == 1 && cmb2.SelectedIndex == 2)
            {
                switchCase = 1;
            }
            else if (cmb1.SelectedIndex >= 1 && cmb2.SelectedIndex == 0)
            {
                switchCase = 4;
            }
            else if (cmb1.SelectedIndex >= 1 && cmb2.SelectedIndex > 0)
            {
                switchCase = 3;
            }
            else
            {
                switchCase = 5;
            }

            Decimal sum = 0;

            switch (switchCase)
            {
                case 1:

                    quary = "SELECT b.Invoice_No, SUM(b.Price) AS TOTAL FROM bills b, bills_info bf WHERE b.Invoice_No = bf.Invoice_No AND bf.Paying_Type = '" + c + "' AND bf.Purchase_Date >= '" + a + "' AND bf.Purchase_Date <= '" + b + "' GROUP BY b.Invoice_No";
                    OpenConnection();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(quary, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);    
            
                    foreach (DataRow row in table.Rows)
                    {
                    sum += Convert.ToDecimal(row[1]);
                    }
             
                    DataRow dr1 = table.NewRow();
                    dr1[1] = sum;
                    table.Rows.Add(dr1);

                    gDView.DataSource = table;
                    CloseConnection();
                    break;

                case 2:

                    quary = "SELECT b.Invoice_No, SUM(b.Price) AS TOTAL FROM bills b, bills_info bf WHERE b.Invoice_No = bf.Invoice_No AND bf.Purchase_Date >= '" + a + "' AND bf.Purchase_Date <= '" + b + "' GROUP BY b.Invoice_No";
                    OpenConnection();
                    adapter = new MySqlDataAdapter(quary, connection);
                    DataTable table3 = new DataTable();
                    adapter.Fill(table3);

                    sum = 0;
            
                    foreach (DataRow row in table3.Rows)
                    {
                    sum += Convert.ToDecimal(row[1]);
                    }
             
                    dr1 = table3.NewRow();
                    dr1[1] = sum;
                    table3.Rows.Add(dr1);


                    gDView.DataSource = table3;
                    CloseConnection();

                   
                    break;

                case 3:

                    quary = "SELECT User_Name FROM users WHERE Name = '" + cmb1.SelectedItem.ToString() + "'";

                    OpenConnection();

                    MySqlCommand command = new MySqlCommand(quary, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        uNameTemp = reader.GetString(0);
                    }
                    reader.Close();


                    quary = "SELECT b.Invoice_No, SUM(b.Price) AS TOTAL FROM bills b, bills_info bf WHERE b.Invoice_No = bf.Invoice_No AND bf.Paying_Type = '" + c + "' AND bf.User_Name = '" + uNameTemp + "' AND bf.Purchase_Date >= '" + a + "' AND bf.Purchase_Date <= '" + b + "' GROUP BY b.Invoice_No";

                    adapter = new MySqlDataAdapter(quary, connection);
                    DataTable table1 = new DataTable();
                    adapter.Fill(table1);

                    sum = 0;
            
                    foreach (DataRow row in table1.Rows)
                    {
                    sum += Convert.ToDecimal(row[1]);
                    }
             
                    dr1 = table1.NewRow();
                    dr1[1] = sum;
                    table1.Rows.Add(dr1);

                    gDView.DataSource = table1;
                    CloseConnection();
                    break;

                case 4:

                    quary = "SELECT User_Name FROM users WHERE Name = '" + d + "'";

                    OpenConnection();

                    command = new MySqlCommand(quary, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        uNameTemp = reader.GetString(0);
                    }
                    reader.Close();


                    quary = "SELECT b.Invoice_No, SUM(b.Price) AS TOTAL FROM bills b, bills_info bf WHERE b.Invoice_No = bf.Invoice_No AND bf.User_Name = '" + uNameTemp + "' AND bf.Purchase_Date >= '" + a + "' AND bf.Purchase_Date <= '" + b + "' GROUP BY b.Invoice_No";

                    adapter = new MySqlDataAdapter(quary, connection);
                    DataTable table2 = new DataTable();
                    adapter.Fill(table2);

                    sum = 0;
            
                    foreach (DataRow row in table2.Rows)
                    {
                    sum += Convert.ToDecimal(row[1]);
                    }
             
                    dr1 = table2.NewRow();
                    dr1[1] = sum;
                    table2.Rows.Add(dr1);

                    gDView.DataSource = table2;
                    CloseConnection();
                    break;

                case 5:

                    quary = "SELECT Item_Code FROM items WHERE Description = '" + cmb3.SelectedItem.ToString() + "'";
                    int iCode = 0;

                    OpenConnection();

                    command = new MySqlCommand(quary, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        iCode = reader.GetInt32(0);
                    }
                    reader.Close();

                    sum = 0;

                    quary = "SELECT b.Invoice_No, b.Quantity AS QUANTITY FROM bills b, bills_info bf WHERE b.Invoice_No = bf.Invoice_No AND b.Item_Code = '" + iCode + "' AND bf.Purchase_Date >= '" + a + "' AND bf.Purchase_Date <= '" + b + "' GROUP BY b.Invoice_No";

                    adapter = new MySqlDataAdapter(quary, connection);
                    DataTable table4 = new DataTable();
                    adapter.Fill(table4);

                    foreach (DataRow row in table4.Rows)
                    {
                    sum += Convert.ToDecimal(row[1]);
                    }
             
                    dr1 = table4.NewRow();
                    dr1[1] = sum;
                    table4.Rows.Add(dr1);

                    gDView.DataSource = table4;
                    CloseConnection();
                    break;

                default:
                    break;
            }
        }

        private void elseif(bool p)
        {
            throw new NotImplementedException();
        }

        private void elseif()
        {
            throw new NotImplementedException();
        }
    }
}

