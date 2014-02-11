using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace billing_system.Classes
{
    class ValidationText
    {

        public void textBoxValidation_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
                MessageBox.Show("Latters are NOT valid");
            }


        }
    }
}
