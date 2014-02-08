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
    public partial class Billingform : Form
    {
        public int stage;
        public Billingform()
        {
            InitializeComponent();
            stage = 0;
        }

        private void Billingform_Load(object sender, EventArgs e)
        {
            txtBoxDescription.Focus();
            BillGeneration bf = new BillGeneration();
            bf.BillNoGen();
            bf.Date();
        }

        public void txtBoxDescription_KeyDown(object sender, KeyEventArgs e)
        {
            string keyCd;
            string searchKey;

            ManualBilling mb=new ManualBilling();
            if (mb.Visible == false)
            {
                mb.Show();
                keyCd = e.KeyCode.ToString();
                KeyPressEvent kpe = new KeyPressEvent();
                searchKey=kpe.manualSearchkey(keyCd);

                BillGeneration bg = new BillGeneration();
                bg.manualBilling(searchKey);
            }
        }

        
    }
}
