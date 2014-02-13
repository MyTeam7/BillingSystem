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

        public string manualSearchkey(string keyCode, string character, string form = "dflt", string focus = "dflt", object obj = null)
        {
            string keyChar = null;
            if (form == "Billingform" && obj != null)
            {

                PrvForm = obj;
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

                    if (form == "admin")
                    {

                        manualBilling("admin", character, obj);

                    }






                }


                else if (int.Parse(keyCode) == 8) //validate BackSpace---------------------------------------------------------------
                {
                    TextBox text = null;
                    string formName = null;

                    if (form == "ManualBillingform" && focus == "des")
                    {
                        ManualBilling mb = (ManualBilling)obj;
                        text = mb.txtBoxDescription;
                        formName = "mb";

                    }

                    if (form == "admin" && focus == "search")
                    {
                        Admin ad = (Admin)obj;
                        text = ad.textBox6;
                        formName = "admin";

                    }






                    if (text.Text.Length > 0) //check is there any text in the textbox
                    {

                        text.Text = text.Text.Substring(0, text.Text.Length - 1); //remove last character from the text of the textbox

                        text.Select(text.Text.Length, 0); //move cursor into the end of text in the textbox


                        character = null;
                        if (text.TextLength == 0)
                        {
                            character = "";

                        }

                        manualBilling(formName, character, obj);
                    }
                    else
                    {

                        SystemSounds.Hand.Play();
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
                    DataGridView dataGridView = null;
                    TextBox textBox = null;


                    if (form == "Billingform" && focus == "des")
                    {
                        Billingform bf = (Billingform)obj;
                        dataGridView = bf.dataGridView1;

                        textBox = bf.txtBoxDescription;
                        bf.ActiveControl = dataGridView;//focus into datagridview
                    }



                    if (form == "ManualBillingform" && focus == "des")
                    {
                        ManualBilling mb = (ManualBilling)obj;
                        dataGridView = mb.dataGridView1;

                        textBox = mb.txtBoxDescription;
                        mb.ActiveControl = dataGridView;//focus into datagridview
                    }


                    dataGridView.BorderStyle = BorderStyle.FixedSingle; //change borderStyle to identify active control
                    textBox.BorderStyle = BorderStyle.Fixed3D; //change borderStyle to identify active control



                }


                else if (int.Parse(keyCode) == 13)//validate enter-------------------------------------------------------------------
                {
                    if (form == "Billingform" && focus == "des")
                    {

                        enterButton("bf", "des", PrvForm);
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






        //--------------startOfdownArrow Function---------------------------------------------------------------------------------------------------------------------------

        public void downArrow(string form, string focus, object obj)
        {
            try
            {
                DataGridView dataGridView = null;

                if (form == "mb" && focus == "dgv") // validate ManualBilling form and DataGridView
                {
                    ManualBilling mb = (ManualBilling)obj;
                    dataGridView = mb.dataGridView1;

                }


                if (form == "bf" && focus == "dgv") // validate ManualBilling form and DataGridView
                {
                    Billingform bf = (Billingform)obj;
                    dataGridView = bf.dataGridView1;
                }



                int rows = dataGridView.RowCount; // no of rows in datagridview
                int rowIndex = dataGridView.CurrentCell.RowIndex; //current row no




                if (rowIndex < (rows - 1) && rowIndex != 0) //validate current selected row is not the last or first row
                {


                    dataGridView.Rows[rowIndex - 1].Selected = false; //deselect current row
                    dataGridView.Rows[rowIndex].Selected = true; // select next row



                }

                else if (rowIndex != 0)
                {

                    SystemSounds.Hand.Play();
                }




            }

            catch (Exception exc)
            {
                MessageBox.Show("Error Occured, Please Try Again, " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
        //--------------endOfdownArrow Function---------------------------------------------------------------------------------------------------------------------------








        //--------------startOfUpArrow Function---------------------------------------------------------------------------------------------------------------------------


        public void upArrow(string form, string focus, object obj)
        {
            try
            {


                DataGridView dataGridView = null;
                TextBox textBox = null;


                if (form == "bf" && focus == "dgv")
                {
                    Billingform bf = (Billingform)obj;
                    dataGridView = bf.dataGridView1;

                    textBox = bf.txtBoxDescription;

                }

                if (form == "mb" && focus == "dgv")
                {
                    ManualBilling mb = (ManualBilling)obj;
                    dataGridView = mb.dataGridView1;

                    textBox = mb.txtBoxDescription;

                }





                int RowIndex = dataGridView.CurrentCell.RowIndex;


                if (RowIndex == 0) //check whether if current selected row is first row or not
                {
                    if (form == "bf" && focus == "dgv")
                    {
                        Billingform bf = (Billingform)obj;
                        bf.ActiveControl = bf.txtBoxDescription;//focus into datagridview
                    }

                    if (form == "mb" && focus == "dgv")
                    {
                        ManualBilling mb = (ManualBilling)obj;
                        mb.ActiveControl = mb.txtBoxDescription;//focus into datagridview
                    }


                    dataGridView.BorderStyle = BorderStyle.Fixed3D; //change borderStyle to identify active control
                    textBox.BorderStyle = BorderStyle.FixedSingle; //change borderStyle to identify active control
                    textBox.Select(textBox.Text.Length, 0);   //move cursor into the end of text in the textbox
                }

                else if (RowIndex > 1)
                {

                    dataGridView.Rows[RowIndex].Selected = false; //deselect current row
                    dataGridView.Rows[RowIndex - 1].Selected = true; //select previous row
                }
                else if (RowIndex == 0)
                {

                    SystemSounds.Hand.Play();
                }


            }



            catch (Exception exc)
            {
                MessageBox.Show("Error Occured, Please Try Again, " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }





        //--------------endOfUpArrow Function---------------------------------------------------------------------------------------------------------------------------










        //--------------startOfEnter Function---------------------------------------------------------------------------------------------------------------------------
        public void enterButton(string form, string focus, object obj, object formobj = null)
        {

            try
            {

                if (form == "mb" && focus == "dgv")
                {
                    ManualBilling mb = (ManualBilling)obj;
                    Billingform bf = (Billingform)formobj;
                    int row = mb.dataGridView1.CurrentCell.RowIndex;


                    if (mb.dataGridView1.RowCount != 0)
                    {

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
                    decimal tot = 0.00m;

                    if (qty == 0)
                    {
                        qty = 1;
                    }

                    if (disc == 0)
                    {

                        tot = (price * qty);

                    }

                    else
                    {
                        decimal newprice;
                        newprice = (price - ((price / 100) * disc));
                        tot = (newprice * qty);
                    }




                    Decimal.TryParse((tot.ToString().Substring(0, tot.ToString().Length)), out tot);

                    Decimal total;
                    Decimal.TryParse(bf.label7.Text, out total);

                    tot = Math.Round(tot, 2);


                    bf.dataGridView1.Rows.Add(bf.dataGridView1.RowCount + 1, code, des, qty, disc, price, tot);

                    BillGeneration bg = new BillGeneration();
                    bg.total(bf);


                }


                if (form == "bf" && focus == "des")
                {
                    Billingform bf = (Billingform)obj;
                    if (bf.dataGridView1.RowCount != 0)
                    {

                        bf.ActiveControl = bf.textBox3;
                    }
                    else
                    {
                        SystemSounds.Hand.Play();
                    }

                }




            }
            catch (Exception exc)
            {
                MessageBox.Show("Error Occured, Please Try Again, " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

            if (form == "admin")
            {
                Admin frm = (Admin)obj;
                textbox = frm.textBox6;
                datagridview = frm.dataGridView1;
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

                if (form == "admin")
                {
                    if (textbox.Text == "")
                    {
                        querystring = "SELECT * From items";
                    }
                    else
                    {
                        querystring = "SELECT * From items WHERE Description LIKE CONCAT('" + textbox.Text + "','%')";
                    }

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



