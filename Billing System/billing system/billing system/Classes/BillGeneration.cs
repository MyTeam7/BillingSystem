﻿using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

using System.Data;

// RavishaHeshan(ravisha_weerasekara@yahoo.com)--2/7/2014

namespace billing_system.Classes
{
    //-------------------startOfBillGenerationClass---------------------------------------------------------------------------------------------------------------------------------------------
    class BillGeneration
    {

        //class for generate bill in Billing form
        private double cash; //varible for store cash value 
        private int discount; // virable for store discount

        //overloaded constructor 
        public BillGeneration(double cashValue = 0.0, int disAmount = 0)
        {
            cash = cashValue;
            discount = disAmount;

        }

        //--------------startOfBillNoGen Function---------------------------------------------------------------------------------------------------------------------------
        public int BillNoGen()
        {
            DBConnection db = new DBConnection();
            int billno = 0;
            try
            {
                string query = "SELECT COUNT(Quantity) FROM bills";
                int count = 0;



                if (db.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, db.connection);  //create command and assign the query and connection from the constructor
                    count = cmd.ExecuteNonQuery();

                    if (count < 1)
                        billno = 000001;
                    else
                    {
                        string queryOne = "SELECT InvoiceNo FROM bills ORDER BY InvoiceNo DESC LIMIT 1";
                        MySqlCommand cmdOne = new MySqlCommand(queryOne, db.connection);
                        int result = cmdOne.ExecuteNonQuery();
                        billno = result + 1;

                    }



                }

                else

                    throw new Exception("DB Connection Error");




            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Oops!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                Billingform bf = new Billingform();
                bf.Show();
            }

            finally
            {
                bool a = db.CloseConnection();
            }

            return billno;

        }
        //--------------endOfBillNoGen Function--------------------------------------------------------------------------------------------------------------------






        //--------------startOfDateTime Function-------------------------------------------------------------------------------------------------------------------

        public DateTime Date()
        {
            return DateTime.Now;
        }

        //--------------endOfDateTime Function---------------------------------------------------------------------------------------------------------------------



        //--------------startOfManualBilling Function-------------------------------------------------------------------------------------------------------------------

        public void manualBilling(string searchKey, object obj = null)
        {
            DBConnection db = new DBConnection();
            

            try
            {
                string query;




                ManualBilling mb = (ManualBilling)obj;

                mb.txtBoxDescription.ReadOnly = false;
                mb.txtBoxDescription.Text = mb.txtBoxDescription.Text + searchKey;
                mb.txtBoxDescription.Select(mb.txtBoxDescription.Text.Length, 0);
                mb.txtBoxDescription.ReadOnly = true;



                
                query = "SELECT * From items WHERE Description LIKE CONCAT('" + mb.txtBoxDescription.Text + "','%')";



                if (db.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, db.connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    BindingSource bs = new BindingSource();
                    bs.DataSource = table;
                    mb.dataGridView1.DataSource = bs;
                    mb.dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
                    
                    
                    if (mb.dataGridView1.RowCount > 0)
                    {
                        
                        mb.dataGridView1.Rows[0].Selected = true;
                    }

                    

                }
                else
                {
                    MessageBox.Show("DB Connection Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mb.Close();



                }


            }

            catch (Exception exc)
            {
                MessageBox.Show("Error Occured," + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

            finally
            {
                bool a = db.CloseConnection();


            }

        }



        //--------------endOfManualBilling Function-------------











    }
    //-------------------endOfBillGenerationClass------------------------------------------------------------------------------------------------------------------------------------------------
}
