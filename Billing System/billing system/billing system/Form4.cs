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



            keyVal = e.KeyValue.ToString();
            keyCd = e.KeyCode.ToString().ToLower();
            RowIndex = 0;

            KeyPressEvent kpe = new KeyPressEvent();

            searchKey = kpe.manualSearchkey(keyVal, keyCd, "ManualBillingform", "des", this);



            if (searchKey == "exit")
            {
                this.Close();
            }


        }


        public void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            string keyVal;




            keyVal = e.KeyValue.ToString();

            if (int.Parse(keyVal) == 40)
            {
                KeyPressEvent kpe = new KeyPressEvent();
                kpe.mbDgvdownArrow(this);

            }
            else if (int.Parse(keyVal) == 38)
            {
                KeyPressEvent kpe = new KeyPressEvent();
                RowIndex = dataGridView1.CurrentCell.RowIndex;
                
                kpe.mbDgvUpArrow(RowIndex, this);
            }
            else if (int.Parse(keyVal) == 13)
            {
                KeyPressEvent kpe = new KeyPressEvent();
                kpe.enterButton("ManualBillingform", "dgv",this);
                
            }
            else
            {

                SystemSounds.Hand.Play();

            }


        }








        private void ManualBilling_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(txtBoxDescription_KeyDown);
            this.KeyDown += new KeyEventHandler(dataGridView1_KeyDown);

        }


    }
}
