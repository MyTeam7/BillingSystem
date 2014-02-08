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
            string keyVal;
            string keyCd;
            string searchKey;

            RowIndex = dataGridView1.CurrentCell.RowIndex;

            ManualBilling mb = new ManualBilling();
            keyVal = e.KeyValue.ToString();
            KeyPressEvent kpe = new KeyPressEvent();
            keyCd = e.KeyCode.ToString();
            searchKey = kpe.manualSearchkey(keyVal,keyCd, "ManualBilling", "description");

            BillGeneration bg = new BillGeneration();
            bg.manualBilling(searchKey);
        }


        public void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            string keyVal;
            

            RowIndex = dataGridView1.CurrentCell.RowIndex;
            keyVal = e.KeyCode.ToString();

            if (int.Parse(keyVal) == 40)
            {
                KeyPressEvent kpe = new KeyPressEvent();
                kpe.mbDgvdownArrow();
            }
            else if (int.Parse(keyVal) == 38)
            {
                KeyPressEvent kpe = new KeyPressEvent();
                kpe.mbDgvupArrow();
            }
            else if (int.Parse(keyVal) == 13)
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
            
            this.ActiveControl = txtBoxDescription;
        }
    }
}
