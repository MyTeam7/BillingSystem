using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Media;


namespace billing_system.Classes
{
    // Aruna Udayanga--2/11/2014

    /// <summary>
    /// class for validation 
    /// </summary>
    class ValidationText
    {

        public void textBoxValidation_KeyPress(object sender, KeyPressEventArgs e) //admin form
        {


            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
                //MessageBox.Show("Latters are NOT valid");
                SystemSounds.Hand.Play();

            }


        }


        public void UserName_KeyPress(object sender, KeyPressEventArgs e) //login form
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 || char.IsNumber(e.KeyChar) ? false : true;
        }


        
    }
}
