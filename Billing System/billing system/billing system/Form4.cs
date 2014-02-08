using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using billing_system.Classes;
using System.Media;

namespace billing_system
{
    public partial class ManualBilling : Form
    {
        public int RowIndex;

        public ManualBilling()
        {
            InitializeComponent();
        }

        private void A_I_Code_Click(object sender, EventArgs e)
        {

        }

        

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void txtBoxDescription_KeyDown(object sender, KeyEventArgs e)
        {
            string keyCd;
            string searchKey;

            RowIndex = dataGridView1.CurrentCell.RowIndex;

            ManualBilling mb = new ManualBilling();
            keyCd = e.KeyCode.ToString();
            KeyPressEvent kpe = new KeyPressEvent();
            searchKey = kpe.manualSearchkey(keyCd, "ManualBilling", "description");

            BillGeneration bg = new BillGeneration();
            bg.manualBilling(searchKey);
        }


        public void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            string keyCd;
            

            RowIndex = dataGridView1.CurrentCell.RowIndex;
            keyCd = e.KeyCode.ToString();

            if (int.Parse(keyCd) == 40)
            {
                KeyPressEvent kpe = new KeyPressEvent();
                kpe.mbDgvdownArrow();
            }
            else if (int.Parse(keyCd) == 38)
            {
                KeyPressEvent kpe = new KeyPressEvent();
                kpe.mbDgvupArrow();
            }
            else if (int.Parse(keyCd) == 13)
            {
                KeyPressEvent kpe = new KeyPressEvent();
                kpe.enterButton("mb", "dgv");
            }
            else
            {
                SystemSounds.Hand.Play();
            }

           
        }








        private void ManualBilling_Load(object sender, EventArgs e)
        {
            txtBoxDescription.Focus();
        }
    }
}
