using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.Media;

// RavishaHeshan(ravisha_weerasekara@yahoo.com)--2/8/2014

namespace billing_system.Classes
{

    //-------------------startOfKeyPressClass---------------------------------------------------------------------------------------------------------------------------------------------
    //this class is for manage keypress events
    class KeyPressEvent
    {

        public object PrvForm;  //variable for hold previous function called form instance




        //--------------startOfmanualSearchkey Function---------------------------------------------------------------------------------------------------------------------------

        public string manualSearchkey(string keyCode, string character, string form = "dflt", string focus = "dflt", object obj=null)
        {
            string keyChar = null;
            if (form == "Billingform" && obj!=null)
            {
               
                PrvForm =obj;
            }





            try
            {



                if (int.Parse(keyCode) > 64 && int.Parse(keyCode) < 106 || int.Parse(keyCode) == 32) //validate Alphanumeric characters-------------------------
                {

                    if (int.Parse(keyCode) > 95 && int.Parse(keyCode) < 106) //validate numberpad inputs to "NumPad" part
                    {
                        character = character.Substring(6, character.Length - 6);
                    }

                    if (int.Parse(keyCode) == 32)
                    {
                        character = " ";
                    }



                    keyChar = character;





                    if (form == "Billingform" || form == "ManualBillingform")
                    {

                        if (form == "Billingform") //idetify function triggered form
                        {
                            ManualBilling mb = new ManualBilling(PrvForm);
                            if (mb.Visible == false) //check whether ManualBilling Form is already initialized or not
                            {
                                mb.Show();
                                mb.Focus();

                            }

                            manualBilling("mb", character, mb); // call manualBilling function 
                        }
                        else
                        {


                            manualBilling("mb", character, obj);
                        }
                    }







                }


                else if (int.Parse(keyCode) == 8) //validate BackSpace---------------------------------------------------------------
                {
                    if (form == "ManualBillingform" && focus == "des")
                    {
                        ManualBilling mb = (ManualBilling)obj;
                        if (mb.txtBoxDescription.Text.Length > 0) //check is there any text in the textbox
                        {
                            string text = mb.txtBoxDescription.Text;
                            text = text.Substring(0, text.Length - 1); //remove last character from the text of the textbox
                            mb.txtBoxDescription.Text = text;
                            mb.txtBoxDescription.Select(mb.txtBoxDescription.Text.Length, 0); //move cursor into the end of text in the textbox
                            
                
                            character = null;
                            if (mb.txtBoxDescription.TextLength == 0)
                            {
                                character = "";
                                
                            }

                            manualBilling("mb", character, obj);
                        }
                        else
                        {
                           
                            SystemSounds.Hand.Play();
                        }
                    }

                }


                else if (int.Parse(keyCode) == 27)  //validate Esc key---------------------------------------------------------------
                {
                    if (form == "Billingform" && focus == "des")
                    {
                        if (MessageBox.Show("Are you sure you want to exit?", "Confirm exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            keyChar = "exit";
                        }
                    }

                    else
                    {

                        SystemSounds.Hand.Play();

                    }

                }

                else if (int.Parse(keyCode) == 40) //validate Down Arrow---------------------------------------------------------------
                {

                    if (form == "ManualBillingform" && focus == "des")
                    {
                        ManualBilling mb = (ManualBilling)obj;
                        mb.ActiveControl = mb.dataGridView1; //focus into datagridview
                        mb.dataGridView1.BorderStyle = BorderStyle.FixedSingle; //change borderStyle to identify active control
                        mb.txtBoxDescription.BorderStyle = BorderStyle.Fixed3D; //change borderStyle to identify active control
                    }
                }
                else if (int.Parse(keyCode) == 38) //validate up Arrow---------------------------------------------------------------
                {
                    if (form == "ManualBillingform" && focus == "des")
                    {

                    }

                }


                else
                {
                    
                       
                        SystemSounds.Hand.Play();
                    

                }


            }


            catch (Exception exc)
            {
                MessageBox.Show("Error Occured, Please Try Again, " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return keyChar; //return "exit" string


        }

        //--------------endOfstartOfmanualSearchkey Function---------------------------------------------------------------------------------------------------------------------------






        //--------------startOfmbDgvdownArrow Function---------------------------------------------------------------------------------------------------------------------------

        public void downArrow(string form, string focus, object obj)
        {

            if (form == "mb" && focus == "dgv") // validate ManualBilling form and DataGridView
            {
                ManualBilling mb = (ManualBilling)obj;
                int rows = mb.dataGridView1.RowCount; // no of rows in datagridview
                int rowIndex = mb.dataGridView1.CurrentCell.RowIndex; //current row no




                if (rowIndex < (rows - 1) && rowIndex != 0) //validate current selected row is not the last or first row
                {

                    
                    mb.dataGridView1.Rows[rowIndex].Selected = false; //deselect current row
                    mb.dataGridView1.Rows[rowIndex + 1].Selected = true; // select next row


                }

                else if(rowIndex != 0)
                {
                    
                    SystemSounds.Hand.Play();
                }
            }


        }
        //--------------endOfmbDgvdownArrow Function---------------------------------------------------------------------------------------------------------------------------








        //--------------startOfUpArrow Function---------------------------------------------------------------------------------------------------------------------------


        public void upArrow(string form, string focus, object obj)
        {
            ManualBilling mb = (ManualBilling)obj;
            int RowIndex = mb.dataGridView1.CurrentCell.RowIndex;
            if (form == "mb" && focus == "dgv") // validate ManualBilling form and DataGridView
            {
                

                

                if (RowIndex == 0) //check whether if current selected row is first row or not
                {

                    mb.ActiveControl = mb.txtBoxDescription; // focus on Description textbox
                    mb.dataGridView1.BorderStyle = BorderStyle.Fixed3D; //change borderStyle to identify active control
                    mb.txtBoxDescription.BorderStyle = BorderStyle.FixedSingle; //change borderStyle to identify active control
                    mb.txtBoxDescription.Select(mb.txtBoxDescription.Text.Length, 0);   //move cursor into the end of text in the textbox
                }

                else if (RowIndex > 1)
                {
                    mb.dataGridView1.Rows[mb.RowIndex].Selected = false; //deselect current row
                    mb.dataGridView1.Rows[mb.RowIndex--].Selected = true; //select previous row
                }
                else if(RowIndex == 0)
                {
                   
                    SystemSounds.Hand.Play();
                }
            }


        }
        //--------------endOfUpArrow Function---------------------------------------------------------------------------------------------------------------------------










        //--------------startOfEnter Function---------------------------------------------------------------------------------------------------------------------------
        public void enterButton(string form, string focus, object obj, object formobj=null)
        {
            if (form == "mb" && focus == "dgv")
            {
                ManualBilling mb = (ManualBilling)obj;
                Billingform bf = (Billingform)formobj;
                int row = mb.dataGridView1.CurrentCell.RowIndex;

                int code = (int)mb.dataGridView1.Rows[row].Cells[0].Value;
                string des = mb.dataGridView1.Rows[row].Cells[1].Value.ToString();
                decimal price = (decimal)mb.dataGridView1.Rows[row].Cells[2].Value;
                decimal l_price = (decimal)mb.dataGridView1.Rows[row].Cells[3].Value;
                decimal disc = (decimal)mb.dataGridView1.Rows[row].Cells[4].Value; ;
                string other = mb.dataGridView1.Rows[row].Cells[5].Value.ToString();

               

                bf.txtBoxCode.Text = code.ToString();
                bf.txtBoxDescription.Text = des;
                bf.textBox8.Text = price.ToString();
                bf.txtBoxDiscount.Text = disc.ToString();
                mb.Close();
                bf.ActiveControl = bf.textBox2;
                                
            }

            if (form == "bf" && focus == "qty")
            {
                Billingform bf = (Billingform)obj;

                string code = bf.txtBoxCode.Text;
                string des = bf.txtBoxDescription.Text;
                decimal price;
                Decimal.TryParse(bf.textBox8.Text, out price);
                decimal disc;
                Decimal.TryParse(bf.txtBoxDiscount.Text, out disc);
                decimal qty;
                Decimal.TryParse(bf.textBox2.Text, out qty);
                decimal tot=0;

                if (qty == 0)
                {
                    qty = 1;
                }
               
                if(disc==0)
                {
                    
                    tot= (price*qty);
                }

                else
                {
                    decimal newprice;
                    newprice = (price - ((price / 100) * disc));
                    tot = (newprice * qty);
                }

                

                bf.dataGridView1.Rows.Add(bf.dataGridView1.RowCount+1, code,des,qty,disc,price,tot);
                bf.txtBoxCode.Text = "";
                bf.txtBoxDescription.Text = "";
                bf.textBox8.Text = "";
                bf.textBox2.Text = "";
                bf.txtBoxDiscount.Text = "";
                bf.ActiveControl = bf.txtBoxDescription;

            }





        }
        //--------------endOfEnter Function---------------------------------------------------------------------------------------------------------------------------






        //--------------startOfManualBilling Function-------------------------------------------------------------------------------------------------------------------

        public void manualBilling(string form, string searchKey, object obj = null)
        {
            DBConnection db = new DBConnection();
            TextBox textbox = null;
            DataGridView datagridview = null;
            string querystring = null;




            //for ManualBilling form
            if (form == "mb")
            {
                ManualBilling mb = (ManualBilling)obj;
                textbox = mb.txtBoxDescription;
                datagridview = mb.dataGridView1;

            }



            try
            {
                string query = null;






                textbox.ReadOnly = false;
                textbox.Text = textbox.Text + searchKey; //assign character of the pressed key into the end of the textbox
                textbox.Select(textbox.Text.Length, 0); //move cursor into the end of text in the textbox
                textbox.ReadOnly = true;



                if (form == "mb")//for ManualBilling form
                {
                    querystring = "SELECT * From items WHERE Description LIKE CONCAT('" + textbox.Text + "','%')";
                }





                query = querystring;




                if (db.OpenConnection() == true)
                {
                    //populate data gridview from result
                    MySqlCommand cmd = new MySqlCommand(query, db.connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    BindingSource bs = new BindingSource();
                    bs.DataSource = table;
                    datagridview.DataSource = bs;
                    datagridview.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);


                    if (datagridview.RowCount > 0)
                    {

                        datagridview.Rows[0].Selected = true; //auto select first record of datagridview if there is any record
                    }



                }
                else
                {
                    MessageBox.Show("DB Connection Error, Please Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }

            catch (Exception exc)
            {
                MessageBox.Show("Error Occured, Please Try Again" + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


            finally
            {
                bool a = db.CloseConnection();

            }

        }



        //--------------endOfManualBilling Function-------------


















    }
    //-------------------endOfKeyPressClass-----------------------------------------------------------------------------------------------------------------------------------------------
}



