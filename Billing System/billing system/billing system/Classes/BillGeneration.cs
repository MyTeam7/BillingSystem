using System;
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
        //function is for generate billno for BillingForm 

        public int BillNoGen(object obj)
        {
            DBConnection db = new DBConnection();
            int billno = 0; //initialize billno variable
            try
            {
                string query = "SELECT COUNT(Quantity) FROM bills";
                int count = 0; //initialize count variable



                if (db.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, db.connection);
                    count = int.Parse(cmd.ExecuteScalar().ToString()); //check for existing bills



                    if (count < 1)
                        billno = 000001;    //first billno
                    else
                    {
                        string queryOne = "SELECT Invoice_No FROM bills ORDER BY Invoice_No DESC LIMIT 1";
                        MySqlCommand cmdOne = new MySqlCommand(queryOne, db.connection);
                        int result = int.Parse(cmdOne.ExecuteScalar().ToString()); //retrieve billno of last bill
                        billno = result + 1; //next billno 

                    }



                }

                else
                {

                    throw new Exception("DB Connection Error");


                }


            }

            catch (Exception ex)
            {
                Billingform bf = (Billingform)obj;

                DialogResult result = MessageBox.Show("Error " + ex.Message + " Do you need to Retry?", "Oops!", System.Windows.Forms.MessageBoxButtons.RetryCancel, System.Windows.Forms.MessageBoxIcon.Question);

                if (result == DialogResult.Retry)
                {
                    bf.reload();


                }
                else
                {

                    bf.Close();
                }
            }


            finally
            {
                bool a = db.CloseConnection();
            }

            return billno;

        }
        //--------------endOfBillNoGen Function--------------------------------------------------------------------------------------------------------------------






        //--------------startOfDateTime Function-------------------------------------------------------------------------------------------------------------------

        public DateTime Date(object obj)
        {
            DateTime value = DateTime.Today; //initialize variable and assign todays's date
            try
            {
                value = DateTime.Now; //assign todays' date and system time              
            }

            catch (Exception e)
            {
                Billingform bf = (Billingform)obj;

                DialogResult result = MessageBox.Show("Error" + e.Message + " Do you need to Retry?", "Oops!", System.Windows.Forms.MessageBoxButtons.RetryCancel, System.Windows.Forms.MessageBoxIcon.Question);

                if (result == DialogResult.Retry)
                {
                    bf.reload();
                }
                else
                {
                    bf.Close();
                }

            }


            return value;
        }

        //--------------endOfDateTime Function---------------------------------------------------------------------------------------------------------------------


        //--------------startOftotal Function---------------------------------------------------------------------------------------------------------------------

        public void total(object obj)
        {
            Billingform bf = (Billingform)obj;
            decimal price;
            decimal disc;
            Decimal.TryParse(bf.textBox8.Text, out price);
            Decimal.TryParse(bf.txtBoxDiscount.Text, out disc);
            decimal totalDisc = 0;
            decimal rate = 0;
            decimal discount = 0;
            decimal qty = 0;
            decimal tot = 0;

            bf.label2.Text = (bf.dataGridView1.RowCount).ToString();

            for (int i = 0; i < bf.dataGridView1.RowCount; i++)
            {

                Decimal.TryParse((bf.dataGridView1.Rows[i].Cells[5].Value).ToString(), out rate);
                Decimal.TryParse((bf.dataGridView1.Rows[i].Cells[4].Value).ToString(), out discount);
                Decimal.TryParse((bf.dataGridView1.Rows[i].Cells[3].Value).ToString(), out qty);



                totalDisc = totalDisc + ((rate / 100) * discount) * qty;

            }


            for (int i = 0; i < bf.dataGridView1.RowCount; i++)
            {
                decimal total = 0.00m;
                Decimal.TryParse(bf.dataGridView1.Rows[i].Cells[6].Value.ToString(), out total);
                tot = tot + total;


            }



            bf.label7.Text = tot.ToString();







            if (totalDisc != 0)
            {
                bf.label4.Text = totalDisc.ToString().Substring(0, totalDisc.ToString().Length - 2);
            }
            else
            {
                bf.label4.Text = "00";
            }

            bf.txtBoxCode.Text = "";
            bf.txtBoxDescription.Text = "";
            bf.textBox8.Text = "";
            bf.textBox2.Text = "";
            bf.txtBoxDiscount.Text = "";
            bf.ActiveControl = bf.txtBoxDescription;


        }

        //--------------endOftotal Function---------------------------------------------------------------------------------------------------------------------



        //--------------startOfbillToDB Function---------------------------------------------------------------------------------------------------------------------

        public void billToDB(object obj)
        {
            Billingform bf = (Billingform)obj;
            DBConnection db = new DBConnection();
            try
            {

                string inv_no = bf.textBox1.Text;
                string user = bf.label16.Text;
                string code = null;
                string qty = null;
                string discount = null;
                string total = null;
                DateTime date = Convert.ToDateTime(bf.label9.Text.Substring(0, bf.label9.Text.Length - 12));

                string time = bf.label9.Text.Substring(10, 11);
                string pay_Type = "ca";




                if (db.OpenConnection() == true)
                {




                    for (int i = 0; i < bf.dataGridView1.RowCount; i++)
                    {
                        code = bf.dataGridView1.Rows[i].Cells[1].Value.ToString();
                        qty = bf.dataGridView1.Rows[i].Cells[3].Value.ToString();
                        discount = bf.dataGridView1.Rows[i].Cells[4].Value.ToString();
                        total = bf.dataGridView1.Rows[i].Cells[6].Value.ToString();


                        string query = "INSERT INTO bills VALUES('" + inv_no + "','" + code + "','" + qty + "','" + total + "','" + discount + "')";
                        MySqlCommand cmd = new MySqlCommand(query, db.connection);
                        cmd.ExecuteNonQuery();

                    }

                    string query2 = "INSERT INTO bills_info VALUES('" + inv_no + "','" + user + "','" + date.Year + "-" + date.Month + "-" + date.Day + "','" + time + "','" + pay_Type + "')";
                    MySqlCommand cmdOne = new MySqlCommand(query2, db.connection);
                    cmdOne.ExecuteNonQuery();

                    bf.reload();


                }

                else
                {

                    throw new Exception("DB Connection Error");


                }




            }

            catch (Exception exc)
            {
                MessageBox.Show("Errror Occured, Please Try Again, " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }




        //--------------endOfbillToDB Function---------------------------------------------------------------------------------------------------------------------








    }
    //-------------------endOfBillGenerationClass------------------------------------------------------------------------------------------------------------------------------------------------
}
