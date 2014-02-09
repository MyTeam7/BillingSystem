using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using billing_system.Classes;
using MySql.Data.MySqlClient;

namespace billing_system
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        //DataTable dbtable;
        private void button10_Click(object sender, EventArgs e)
        {

            if ((txtBoxCode.Text == "") || (txtBoxDescription.Text == "") || (txtBoxDiscount.Text == "") || (textBox2.Text == "") || (textBox8.Text == "") || (txtBoxOther.Text == ""))
            {
                MessageBox.Show("All the fields must be Filled");
            }
            else
            {
                int textboxCode = int.Parse(txtBoxCode.Text);
                string txtboxDescription = txtBoxDescription.Text;
                decimal txtboxDiscount = decimal.Parse(txtBoxDiscount.Text);
                decimal lowestPrice = decimal.Parse(textBox2.Text);
                decimal price = decimal.Parse(textBox8.Text);
                string txtboxOther = txtBoxOther.Text;

                ItemDBConnection adminDb = new ItemDBConnection();


                adminDb.Insert(textboxCode, txtboxDescription, txtboxDiscount, lowestPrice, price, txtboxOther);

            }
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            //SearchItem serItm = new SearchItem();
            //serItm.serchItemDis();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if ((txtBoxCode.Text == "") || (txtBoxDescription.Text == "") || (txtBoxDiscount.Text == "") || (textBox2.Text == "") || (textBox8.Text == "") || (txtBoxOther.Text == ""))
            {
                MessageBox.Show("All the fields must be Filled");
            }
            else
            {
                int textboxCode = int.Parse(txtBoxCode.Text);
                string txtboxDescription = txtBoxDescription.Text;
                decimal txtboxDiscount = decimal.Parse(txtBoxDiscount.Text);
                decimal lowestPrice = decimal.Parse(textBox2.Text);
                decimal price = decimal.Parse(textBox8.Text);
                string txtboxOther = txtBoxOther.Text;

                ItemDBConnection itemupda = new ItemDBConnection();

                itemupda.Update(textboxCode, txtboxDescription, txtboxDiscount, lowestPrice, price, txtboxOther);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if ((txtBoxCode.Text == "") || (txtBoxDescription.Text == "") || (txtBoxDiscount.Text == "") || (textBox2.Text == "") || (textBox8.Text == "") || (txtBoxOther.Text == ""))
            {
                MessageBox.Show("All the fields must be Filled");
            }
            else
            {
                int textboxCode = int.Parse(txtBoxCode.Text);

                ItemDBConnection itemdel = new ItemDBConnection();

                itemdel.Delete(textboxCode);
            }
        }


        private void button9_Click(object sender, EventArgs e)
        {
            // SearchItem serItm = new SearchItem();
            //serItm.serchItemDis(); 

            DBConnection db = new DBConnection();
            //Admin item = new Admin();
            try
            {
                string query;

                if (db.OpenConnection() == true)
                {
                    query = "SELECT * From items";
                    MySqlCommand cmd = new MySqlCommand(query, db.connection);


                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = cmd;
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    BindingSource bsource = new BindingSource();

                    bsource.DataSource = table;
                    dataGridView1.DataSource = table;
                    adapter.Update(table);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured," + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                bool a = db.CloseConnection();
            }

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //DataView Dv = new DataView(dbtable);
            //Dv.RowFilter = string.Format("Description LIKE '%{0}%'", textBox6.Text);
            //dataGridView1.DataSource = Dv;

        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                txtBoxCode.Text = row.Cells["Item_Code"].Value.ToString();
                txtBoxDescription.Text = row.Cells["Description"].Value.ToString();
                txtBoxDiscount.Text = row.Cells["Discount"].Value.ToString();
                textBox2.Text = row.Cells["Lowest_Price"].Value.ToString();
                textBox8.Text = row.Cells["price"].Value.ToString();
                txtBoxOther.Text = row.Cells["Others"].Value.ToString();
            }
        }


    }
}
