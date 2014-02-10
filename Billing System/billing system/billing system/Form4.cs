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
        public object billingform;


        public ManualBilling()
        {
            InitializeComponent();

        }

        public ManualBilling(object obj)
        {
            InitializeComponent();
            billingform = obj;
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
                if (dataGridView1.RowCount != 0 || dataGridView1.RowCount != 1)
                {
                    KeyPressEvent kpe = new KeyPressEvent();
                    kpe.downArrow("mb", "dgv", this); //mb=ManualBilling, dgv=DataGridView

                }

            }
            else if (int.Parse(keyVal) == 38)
            {
                KeyPressEvent kpe = new KeyPressEvent();
                
                kpe.upArrow("mb", "dgv", this);
            }
            else if (int.Parse(keyVal) == 13)
            {
                KeyPressEvent kpe = new KeyPressEvent();
                kpe.enterButton("mb", "dgv", this,billingform);

            }
            else
            {
                if (int.Parse(keyVal) < 65 && int.Parse(keyVal) > 105 && int.Parse(keyVal) != 32)
                {
                   
                    SystemSounds.Hand.Play();
                }

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
