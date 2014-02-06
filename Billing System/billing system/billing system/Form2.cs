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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }


        private void button10_Click(object sender, EventArgs e)
        {
                    
            String textboxCode = txtBoxCode.Text;
            String txtboxDescription = txtBoxDescription.Text;
            String txtboxDiscount = txtBoxDiscount.Text;
            String Qty = textBox2.Text;
            String txtboxRate = txtBoxRate.Text;
            String rate = textBox8.Text;
            String txtboxOther = txtBoxOther.Text;

            ItemDBConnection adminDb = new ItemDBConnection();

            adminDb.Insert(textboxCode, txtboxDescription, txtboxDiscount, Qty, txtboxRate, rate, txtboxOther);
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }
    }
}
