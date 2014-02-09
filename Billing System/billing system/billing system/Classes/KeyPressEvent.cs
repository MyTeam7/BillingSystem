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

        public object PrvForm;




        //--------------startOfmanualSearchkey Function---------------------------------------------------------------------------------------------------------------------------

        public string manualSearchkey(string keyCode, string character, string form = "dflt", string focus = "dflt", object obj = null)
        {
            string keyChar = null;
            PrvForm = obj;
            
            
            
            
            
            try
            {



                if (int.Parse(keyCode) > 64 && int.Parse(keyCode) < 106) //validate Alphanumeric characters-------------------------
                {
                    //KeysConverter kc = new KeysConverter();
                    keyChar = character;

                    if (form == "Billingform")
                    {
                        ManualBilling mb = new ManualBilling();
                        if (mb.Visible == false)
                        {
                            mb.Show();
                            mb.Focus();

                        }
                        BillGeneration bf = new BillGeneration();
                        bf.manualBilling(character, mb);
                    }
                    else
                    {
                        BillGeneration bf = new BillGeneration();

                        bf.manualBilling(character, obj);
                    }


                }


                else if (int.Parse(keyCode) == 8)
                {
                    if (form == "ManualBillingform" && focus == "des")
                    {
                        ManualBilling mb = (ManualBilling)obj;
                        if (mb.txtBoxDescription.Text.Length > 0)
                        {
                            string text = mb.txtBoxDescription.Text;
                            text = text.Substring(0, text.Length - 1);
                            mb.txtBoxDescription.Text = text;
                            mb.txtBoxDescription.Select(mb.txtBoxDescription.Text.Length, 0);
                            BillGeneration bf = new BillGeneration();
                            character = null;
                            
                            bf.manualBilling(character,obj);
                        }
                        else
                        {
                            SystemSounds.Hand.Play();
                        }
                    }

                }


                else if (int.Parse(keyCode) == 27)
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
                        mb.ActiveControl = mb.dataGridView1;
                        mb.dataGridView1.BorderStyle = BorderStyle.FixedSingle;
                        mb.txtBoxDescription.BorderStyle = BorderStyle.Fixed3D;
                    }
                }


                else
                {

                    SystemSounds.Hand.Play();

                }


            }


            catch (Exception exc)
            {
                MessageBox.Show("Error Occured," + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return keyChar;


        }

        //--------------endOfstartOfmanualSearchkey Function---------------------------------------------------------------------------------------------------------------------------






        //--------------startOfmbDgvdownArrow Function---------------------------------------------------------------------------------------------------------------------------
        public void mbDgvdownArrow(object obj)
        {

            ManualBilling mb = (ManualBilling)obj;
            int rows = mb.dataGridView1.RowCount;



            if (mb.RowIndex < rows)
            {

                mb.RowIndex = mb.RowIndex + 1;
                //mb.dataGridView1.Rows[mb.RowIndex - 1].Selected = false;
                mb.dataGridView1.CurrentCell = mb.dataGridView1[mb.RowIndex, 0];
                

            }

            else
            {
                SystemSounds.Hand.Play();
            }


        }
        //--------------endOfmbDgvdownArrow Function---------------------------------------------------------------------------------------------------------------------------








        //--------------startOfUpArrow Function---------------------------------------------------------------------------------------------------------------------------


        public void mbDgvUpArrow(int RowIndex, object obj)
        {
            ManualBilling mb = (ManualBilling)obj;



            if (RowIndex == 0)
            {
                
                mb.ActiveControl = mb.txtBoxDescription;
                mb.dataGridView1.BorderStyle = BorderStyle.Fixed3D;
                mb.txtBoxDescription.BorderStyle = BorderStyle.FixedSingle;
            }

            else if (mb.RowIndex > 1)
            {
                mb.dataGridView1.Rows[mb.RowIndex].Selected = false;
                mb.dataGridView1.Rows[mb.RowIndex--].Selected = true;
            }
            else
            {
                
                SystemSounds.Hand.Play();
            }


        }
        //--------------endOfUpArrow Function---------------------------------------------------------------------------------------------------------------------------










        //--------------startOfEnter Function---------------------------------------------------------------------------------------------------------------------------
        public void enterButton(string form, string focus,object obj)
        {
            if (form == "ManualBillingform" && focus == "dgv")
            {
                ManualBilling mb = (ManualBilling)obj;
                Billingform bf = (Billingform)PrvForm;
                int row=mb.dataGridView1.CurrentCell.RowIndex;
                
                int code=(int)mb.dataGridView1.Rows[row].Cells[0].Value;
                string des=mb.dataGridView1.Rows[row].Cells[1].Value.ToString();
                decimal price=(decimal)mb.dataGridView1.Rows[row].Cells[2].Value;
                decimal l_price=(decimal)mb.dataGridView1.Rows[row].Cells[3].Value;
                decimal disc=(decimal)mb.dataGridView1.Rows[row].Cells[4].Value;;
                string other=mb.dataGridView1.Rows[row].Cells[5].Value.ToString();

               

                bf.dataGridView1.Rows.Insert(bf.dataGridView1.RowCount,code,des,price,l_price,disc,other);


               

            }
        }
        //--------------endOfEnter Function---------------------------------------------------------------------------------------------------------------------------







    }
    //-------------------endOfKeyPressClass-----------------------------------------------------------------------------------------------------------------------------------------------
}



