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
    public partial class Billingform : Form
    {
        public int stage;
        object obj;

        public Billingform()
        {
            InitializeComponent();
            stage = 0;
            this.txtBoxDescription.KeyDown += new KeyEventHandler(txtBoxDescription_KeyDown);
            obj = this;
        }








        private void Billingform_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtBoxDescription;
            BillGeneration bf = new BillGeneration();
            textBox1.Text = bf.BillNoGen().ToString();


            timer1 = new Timer();
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();

        }







        public void txtBoxDescription_KeyDown(object sender, KeyEventArgs e)
        {
            string keyVal;
            string keyCd;
            string searchKey;

            ManualBilling mb = new ManualBilling();

            keyVal = e.KeyValue.ToString();
            keyCd = e.KeyCode.ToString();
            string kd = e.KeyData.ToString();
            


            KeyPressEvent kpe = new KeyPressEvent();
            searchKey = kpe.manualSearchkey(keyVal, keyCd, "Billingform", "des",this);
            


            if (searchKey == "exit")
            {
                this.Close();
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BillGeneration bf = new BillGeneration();
            label9.Text = bf.Date().ToString();
        }












    }
}
