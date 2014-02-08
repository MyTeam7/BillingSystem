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
    public partial class ManualBilling : Form
    {
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

            ManualBilling mb = new ManualBilling();
            keyCd = e.KeyCode.ToString();
            KeyPressEvent kpe = new KeyPressEvent();
            searchKey = kpe.manualSearchkey(keyCd);

            BillGeneration bg = new BillGeneration();
            bg.manualBilling(searchKey);
        }

        private void ManualBilling_Load(object sender, EventArgs e)
        {
            txtBoxDescription.Focus();
        }
    }
}
