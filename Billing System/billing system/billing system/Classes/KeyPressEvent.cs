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

    //--------------startOfmanualSearchkey Function---------------------------------------------------------------------------------------------------------------------------

        public string manualSearchkey(string keyCode)
        {
            DBConnection db = new DBConnection();
            string keyChar=null;
            try
            {
               

                if (int.Parse(keyCode) > 65 && int.Parse(keyCode) < 105)
                {
                    KeysConverter kc = new KeysConverter();
                    keyChar = kc.ConvertToString(keyCode); 

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
            return keyChar;
        }

    //--------------endOfstartOfmanualSearchkey Function---------------------------------------------------------------------------------------------------------------------------
    }
//-------------------endOfKeyPressClass-----------------------------------------------------------------------------------------------------------------------------------------------
}
