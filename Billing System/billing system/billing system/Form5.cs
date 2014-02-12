using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using billing_system.Classes;

namespace billing_system
{
    public partial class DiscFrom : Form
    {
        public DiscFrom()
        {
            InitializeComponent();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxCode_KeyPress(object sender, KeyPressEventArgs e)
        {

            ValidationText tx = new ValidationText();
            tx.textBoxValidation_KeyPress(sender, e);
        }
    }
}
