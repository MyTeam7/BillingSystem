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
<<<<<<< HEAD

            String lowestPrice = textBox2.Text;
            String price = textBox8.Text;

            String Qty = textBox2.Text;
            String rate = textBox8.Text;

=======
            String lowestPrice = textBox2.Text;
            String price = textBox8.Text;
>>>>>>> origin/Aruna
            String txtboxOther = txtBoxOther.Text;

            ItemDBConnection adminDb = new ItemDBConnection();

<<<<<<< HEAD

            adminDb.Insert(textboxCode,txtboxDescription, txtboxDiscount,lowestPrice,price,txtboxOther);

            

=======
            adminDb.Insert(textboxCode,txtboxDescription, txtboxDiscount,lowestPrice,price,txtboxOther);
>>>>>>> origin/Aruna
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

            String textboxCode = txtBoxCode.Text;
            String txtboxDescription = txtBoxDescription.Text;
            String txtboxDiscount = txtBoxDiscount.Text;
            String lowestPrice = textBox2.Text;
            String price = textBox8.Text;
            String txtboxOther = txtBoxOther.Text;

            ItemDBConnection itemupda = new ItemDBConnection();

            itemupda.Update(textboxCode, txtboxDescription, txtboxDiscount, lowestPrice, price, txtboxOther);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            String textboxCode = txtBoxCode.Text;

            ItemDBConnection itemdel = new ItemDBConnection();

            itemdel.Delete(textboxCode);
        }
<<<<<<< HEAD

        private void button9_Click(object sender, EventArgs e)
        {

        }
=======
>>>>>>> origin/Aruna
    }
}
