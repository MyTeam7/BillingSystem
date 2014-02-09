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
        private int keyCount;





        //--------------startOfmanualSearchkey Function---------------------------------------------------------------------------------------------------------------------------

        public string manualSearchkey(string keyCode, string character, string form = "dflt", string focus = "dflt", object obj = null)
        {
            string keyChar = null;

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
                    if (form == "ManualBilling" && focus == "description")
                    {
                        ManualBilling mb = new ManualBilling();
                        mb.dataGridView1.Focus();
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
        public void mbDgvdownArrow()
        {
            ManualBilling mb = new ManualBilling();
            int rows = mb.dataGridView1.RowCount;



            if (keyCount > 1 && mb.RowIndex < rows)
            {
                mb.dataGridView1.Rows[mb.RowIndex].Selected = false;
                mb.dataGridView1.Rows[mb.RowIndex++].Selected = true;
            }

            else
            {
                SystemSounds.Hand.Play();
            }


        }
        //--------------endOfmbDgvdownArrow Function---------------------------------------------------------------------------------------------------------------------------








        //--------------startOfUpArrow Function---------------------------------------------------------------------------------------------------------------------------


        public void mbDgvupArrow()
        {
            ManualBilling mb = new ManualBilling();


            if (mb.RowIndex == 1)
            {
                mb.txtBoxDescription.Focus();
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
        public void enterButton(string form, string focus)
        {
            if (form == "mb" && focus == "dgv")
            {

            }
        }
        //--------------endOfEnter Function---------------------------------------------------------------------------------------------------------------------------







    }
    //-------------------endOfKeyPressClass-----------------------------------------------------------------------------------------------------------------------------------------------
}



