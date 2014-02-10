using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using billing_system.Classes;
using System.Media;


//Edited by
//RavishaHeshan(ravisha_weerasekara@yahoo.com)--2/10/2014

namespace billing_system
{
    public partial class Billingform : Form
    {

        object obj; //variable for hold currnt form instance

        public Billingform()
        {
            InitializeComponent();
            this.txtBoxDescription.KeyDown += new KeyEventHandler(txtBoxDescription_KeyDown);
            obj = this;
        }








        private void Billingform_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtBoxDescription; //focus on Description textbox
            BillGeneration bf = new BillGeneration();
            textBox1.Text = bf.BillNoGen(this).ToString(); //call to BillNoGen function


            timer1 = new Timer();
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start(); //initialize timer

        }







        public void txtBoxDescription_KeyDown(object sender, KeyEventArgs e)
        {
            string keyVal;
            string keyCd;
            string searchKey;

            ManualBilling mb = new ManualBilling();

            keyVal = e.KeyValue.ToString(); //convert and assign pressed keyValue 
            keyCd = e.KeyCode.ToString();   //convert and assign pressed keystring




            KeyPressEvent kpe = new KeyPressEvent();
            searchKey = kpe.manualSearchkey(keyVal, keyCd, "Billingform", "des", this); //call manualSearchkey function



            if (searchKey == "exit")
            {
                this.Close();
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BillGeneration bf = new BillGeneration();
            label9.Text = bf.Date(this).ToString(); //call to Date function
        }












    }
}
