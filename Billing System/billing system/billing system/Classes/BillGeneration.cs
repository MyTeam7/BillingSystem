using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
namespace billing_system.Classes
{
   //-------------------startOfBillGenerationClass-----------------------
    class BillGeneration
    {
        // RavishaHeshan(ravisha_weerasekara@yahoo.com)--2/7/2014
        //class for generate bill in Billing form
        private double cash; //varible for store cash value 
        private int discount; // virable for store discount

        //overloaded constructor 
        public BillGeneration( double cashValue=0.0, int disAmount=0)
        {
            cash = cashValue;
            discount = disAmount;
            
        }

        //--------------startOfBillNoGen Function------------------------
        public int BillNoGen()
        {
            try
            {
                string query = "SELECT COUNT(Quantity) FROM bills";
                int count = 0;
                int billno;

                DBConnection db = new DBConnection();
                db.Initialize();
                if (db.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, db.connection);  //create command and assign the query and connection from the constructor
                    count = cmd.ExecuteNonQuery();

                    if (count < 1)
                        billno = 000001;
                    else
                    {
                        string queryOne = "SELECT InvoiceNo FROM bills ORDER BY id DESC LIMIT 1";
                        MySqlCommand cmdOne = new MySqlCommand(queryOne, db.connection);
                        int result = cmdOne.ExecuteNonQuery();
                        billno = result + 1;

                    }

                    return billno;
                    db.CloseConnection();
                }
                     
                else
                    throw new Exception("DB Connection Error");
                
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error" + ex.Message, "Oops!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                Billingform bf = new Billingform();
                bf.Show();
            }
            finally
            {
                
            }
 
        }
        //--------------startOfBillNoGen Function------------------------

    }
}
