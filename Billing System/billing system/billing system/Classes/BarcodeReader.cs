using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;


// RavishaHeshan(ravisha_weerasekara@yahoo.com)--2/11/2014



namespace billing_system.Classes
{
    class BarcodeReader
    {
        private int barCode;

        public BarcodeReader(int code)
        {
            barCode = code;
        }


        public void reader(object obj)
        {
            DBConnection db = new DBConnection();
            try
            {
                string query = "SELECT * FROM items WHERE Item_Code='"+barCode+"'";




                if (db.OpenConnection() == true)
                {
                    //populate data gridview from result
                    MySqlCommand cmd = new MySqlCommand(query, db.connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    
                    if(table.Rows.Count==0)
                    {
                        MessageBox.Show("Invalid BarCode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Billingform bf=(Billingform)obj;
                        bf.txtBoxDescription.Text=table.Rows[0].ItemArray[1].ToString();
                        bf.txtBoxDiscount.Text=table.Rows[0].ItemArray[4].ToString();
                        bf.textBox8.Text=table.Rows[0].ItemArray[2].ToString();
                        bf.txtBoxCode.ReadOnly = true;
                        bf.ActiveControl = bf.textBox2;
                    }

                    



                }
                else
                {
                    MessageBox.Show("DB Connection Error, Please Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("Error Occured, Please Try Again, " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                bool a = db.CloseConnection();
            }
        }



    }
}
