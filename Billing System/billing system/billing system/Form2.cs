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
                clearItem();

            }

        }

        private void Admin_Load(object sender, EventArgs e)
        {
            //-------------------Dilanka Rathnayaka------------------------------2/9/2014----------------------------
            Reports rep = new Reports();
            rep.FormLoadDateTimePicker(dateTimePicker1, dateTimePicker2);
            //Set Cashier names to combo box
            rep.FormLoadComboBox(comboBox1, comboBox2);
            //-------------------------------------------------------------------------------------------------------

            KeyPressEvent kpe = new KeyPressEvent();
            kpe.manualBilling("admin", "", this);

            this.KeyPreview = true;
            this.textBox6.KeyDown += new KeyEventHandler(textBox6_KeyDown);

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
                clearItem();
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
                clearItem();
            }
        }


        private void button9_Click(object sender, EventArgs e)
        {
            KeyPressEvent kpe = new KeyPressEvent();
            kpe.manualBilling("admin", textBox6.Text, this);
            //// SearchItem serItm = new SearchItem();
            ////serItm.serchItemDis(); 

            //DBConnection db = new DBConnection();
            ////Admin item = new Admin();
            //try
            //{
            //    string query;

            //    if (db.OpenConnection() == true)
            //    {
            //        query = "SELECT * From items";
            //        MySqlCommand cmd = new MySqlCommand(query, db.connection);


            //        MySqlDataAdapter adapter = new MySqlDataAdapter();
            //        adapter.SelectCommand = cmd;
            //        DataTable table = new DataTable();
            //        adapter.Fill(table);
            //        BindingSource bsource = new BindingSource();

            //        bsource.DataSource = table;
            //        dataGridView1.DataSource = table;
            //        adapter.Update(table);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error Occured," + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //finally
            //{
            //    bool a = db.CloseConnection();
            //}

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

        private void button4_Click(object sender, EventArgs e)
        {
            if ((textBox7.Text == "") || (textBox1.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (textBox14.Text == "") || (textBox9.Text == "") || (comboBox3.Text == "") || (textBox5.Text == ""))
            {
                MessageBox.Show("All the fields must be Filled");
            }
            else
            {
                int User_ID = int.Parse(textBox7.Text);
                string Name = textBox1.Text;
                string Address = textBox3.Text;
                int Phone = int.Parse(textBox4.Text);
                string User_Name = textBox14.Text;
                string Password = textBox9.Text;
                string Catagory = comboBox3.Text;
                string Others = textBox5.Text;

                UserDbConnection userDB = new UserDbConnection();
                userDB.Insert(User_ID, Name, Address, Phone, User_Name, Password, Catagory, Others);
                clearUser();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((textBox7.Text == "") || (textBox1.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (textBox14.Text == "") || (textBox9.Text == "") || (comboBox3.Text == "") || (textBox5.Text == ""))
            {
                MessageBox.Show("All the fields must be Filled");
            }
            else
            {
                int User_ID = int.Parse(textBox7.Text);
                string Name = textBox1.Text;
                string Address = textBox3.Text;
                int Phone = int.Parse(textBox4.Text);
                string User_Name = textBox14.Text;
                string Password = textBox9.Text;
                string Catagory = comboBox3.Text;
                string Others = textBox5.Text;

                UserDbConnection userDB = new UserDbConnection();
                userDB.Update(User_ID, Name, Address, Phone, User_Name, Password, Catagory, Others);
                clearUser();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox7.Text == "") || (textBox1.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (textBox14.Text == "") || (textBox9.Text == "") || (comboBox3.Text == "") || (textBox5.Text == ""))
            {
                MessageBox.Show("All the fields must be Filled");
            }
            else
            {

                int User_ID = int.Parse(textBox7.Text);
                UserDbConnection userDB = new UserDbConnection();

                userDB.Delete(User_ID);
                clearUser();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DBConnection db = new DBConnection();
            //Admin item = new Admin();
            try
            {
                string query;

                if (db.OpenConnection() == true)
                {
                    query = "SELECT * From users";
                    MySqlCommand cmd = new MySqlCommand(query, db.connection);


                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = cmd;
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    BindingSource bsource = new BindingSource();

                    bsource.DataSource = table;
                    dataGridView2.DataSource = table;
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];

                textBox7.Text = row.Cells["User_ID"].Value.ToString();
                textBox1.Text = row.Cells["Name"].Value.ToString();
                textBox3.Text = row.Cells["Address"].Value.ToString();
                textBox4.Text = row.Cells["Phone"].Value.ToString();
                textBox14.Text = row.Cells["User_Name"].Value.ToString();
                textBox9.Text = row.Cells["Password"].Value.ToString();
                comboBox3.Text = row.Cells["Catagory"].Value.ToString();
                textBox5.Text = row.Cells["Others"].Value.ToString();
            }
        }
        public void clearItem()
        {
            txtBoxCode.Text = "";
            txtBoxDescription.Text = "";
            txtBoxDiscount.Text = "";
            textBox2.Text = "";
            textBox8.Text = "";
            txtBoxOther.Text = "";
        }
        public void clearUser()
        {
            textBox7.Text = "";
            textBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox14.Text = "";
            textBox9.Text = "";
            comboBox3.Text = "";
            textBox5.Text = "";
        }


        private void textBoxValidation_KeyPress(object sender, KeyPressEventArgs e)
        {

            ValidationText tx = new ValidationText();
            tx.textBoxValidation_KeyPress(sender, e);


        }


        public void textBox6_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {

                string keyVal;
                string keyCd;
                string searchKey;



                keyVal = e.KeyValue.ToString(); //keycode value
                keyCd = e.KeyCode.ToString().ToLower(); //character


                KeyPressEvent kpe = new KeyPressEvent();

                searchKey = kpe.manualSearchkey(keyVal, keyCd, "admin", "search", this);



                if (searchKey == "exit")
                {
                    this.Close();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error Occured, Please Try Again, " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text != "")
            {
                string cmbText = comboBox4.Text;
                //comboBox4.Items.Clear();
                Reports rep = new Reports();
                rep.ComboBoxTextchange(comboBox4, cmbText);
            }
            else
                comboBox4.Items.Clear();
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {


        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            /* if (comboBox1.SelectedIndex == 0)
             {
                 MessageBox.Show("You Cant Sellect Any.Because No cashier Selected");
                 comboBox2.SelectedIndex = 0;
             }
             if (comboBox2.SelectedItem.ToString() == "NON")
             {
                 if (comboBox1.SelectedItem.ToString() == "NON")
                 {
                     comboBox4.Enabled = true;
                 }
                
             }
             else
                 comboBox4.Enabled = false;*/
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "NON")
            {
                comboBox4.Enabled = true;

            }
            else
            {

                comboBox4.Enabled = false;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Reports rep = new Reports();
            rep.DoneButtonClick(comboBox1, comboBox2, comboBox4, dateTimePicker1, dateTimePicker2, dataGridView3);
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("You Cant Sellect Any.Because No cashier Selected");
                comboBox2.SelectedIndex = 0;
            }
        }

    }
}