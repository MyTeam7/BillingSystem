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
    class KeyPress
    {

    //--------------startOfmanualSearchkey Function---------------------------------------------------------------------------------------------------------------------------

        public void startOfmanualSearchkey(string keyCode)
        {
            DBConnection db = new DBConnection();
            try
            {
                string query;

                if (int.Parse(keyCode) > 65 && int.Parse(keyCode) < 105)
                {
                    KeysConverter kc = new KeysConverter();
                    string keyChar = kc.ConvertToString(keyCode);

                    ManualBilling mb = new ManualBilling();
                    
                    if (mb.Visible==false)
                    {
                        mb.Visible = true;
                        mb.Focus();
                    }
                    
                    mb.txtBoxDescription.Text = mb.txtBoxDescription.Text+keyChar;
                    query = "SELECT * From items WHERE Description LIKE CONCAT('" + keyChar + "','%')";


                    
                    if (db.OpenConnection() == true)
                    {
                        MySqlCommand cmd = new MySqlCommand(query, db.connection);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(query, db.connection);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        mb.dataGridView1.DataSource = dt;
                        mb.dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
                        MySqlDataReader mdr = new MySqlDataReader();
                        mdr = cmd.ExecuteReader();

                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("DB Connection Error", "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                        mb.Show();
                        Billingform bf = new Billingform();
                        bf.Focus();
                    }

                }
                else
                {
                    SystemSounds.Hand.Play();
                }
            }

            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show("Error Occured," + exc.Message, "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

            finally
            {
                bool a=db.CloseConnection();  
            }
        }

    //--------------endOfstartOfmanualSearchkey Function---------------------------------------------------------------------------------------------------------------------------
    }
//-------------------endOfKeyPressClass-----------------------------------------------------------------------------------------------------------------------------------------------
}
