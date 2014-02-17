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
//RavishaHeshan(ravisha_weerasekara@yahoo.com)--2/11/2014

namespace billing_system
{
    public partial class Billingform : Form
    {

        public object obj; //variable for hold currnt form instance
        public string user_name;
        public Login log;


        public Billingform()
        {
            InitializeComponent();

            obj = this;
        }

        public Billingform(string user, Login log)
        {
            InitializeComponent();

            this.log = log;
            obj = this;
            user_name = user;

        }








        private void Billingform_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.textBox2.KeyDown += new KeyEventHandler(textBox2_KeyDown);
            this.textBox3.KeyDown += new KeyEventHandler(textBox3_KeyDown);
            this.txtBoxDescription.KeyDown += new KeyEventHandler(txtBoxDescription_KeyDown);
            this.txtBoxCode.KeyDown += new KeyEventHandler(txtBoxCode_KeyDown);
            this.dataGridView1.KeyDown += new KeyEventHandler(dataGridView1_KeyDown);



            this.ActiveControl = txtBoxCode;
            //this.ActiveControl = txtBoxDescription; //focus on Description textbox
            BillGeneration bf = new BillGeneration();
            textBox1.Text = bf.BillNoGen(this).ToString(); //call to BillNoGen function


            timer1 = new Timer();
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start(); //initialize timer


            label16.Text = user_name;





        }


        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void txtBoxDescription_KeyDown(object sender, KeyEventArgs e)
        {
            try
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
            catch (Exception exc)
            {
                MessageBox.Show("Error Occured, Please Try Again, " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }




        //----------------------------------------------------------------------------------------------------------------------------------------------------------------


        public void txtBoxCode_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                string keyVal;




                keyVal = e.KeyValue.ToString(); //convert and assign pressed keyValue 

                if (int.Parse(keyVal) > 95 && int.Parse(keyVal) < 106)
                {

                    txtBoxCode.ReadOnly = false;


                }


                else if (int.Parse(keyVal) == 27)
                {
                    if (MessageBox.Show("Are you sure you want to exit?", "Confirm exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.Close();
                    }

                }


                else if (int.Parse(keyVal) == 13)
                {

                    int code = Convert.ToInt32(txtBoxCode.Text);
                    BarcodeReader br = new BarcodeReader(code);
                    br.reader(this);
                }

                else if (int.Parse(keyVal) == 8) //validate BackSpace---------------------------------------------------------------
                {
                }


                else
                {
                    SystemSounds.Hand.Play();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error Occured, Please Try Again, " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }



        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                BillGeneration bf = new BillGeneration();
                label9.Text = bf.Date(this).ToString() + " "; //call to Date function
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error Occured, Please Try Again, " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



        public void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                string keyVal = e.KeyValue.ToString();


                if (int.Parse(keyVal) > 95 && int.Parse(keyVal) < 106)
                {

                    string key = e.KeyCode.ToString();
                    key = key.Substring(6, key.Length - 6);

                    textBox2.ReadOnly = false;
                    if (textBox2.Text.Length < 4)
                    {
                        textBox2.Text = textBox2.Text + key;
                    }
                    textBox2.Select(textBox2.Text.Length, 0);
                    textBox2.ReadOnly = true;


                }

                else if (int.Parse(keyVal) == 8) //validate BackSpace---------------------------------------------------------------
                {
                    if (textBox2.Text.Length != 0)
                    {
                        textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 1); //remove last character from the text of the textbox

                        textBox2.Select(textBox2.Text.Length, 0); //move cursor into the end of text in the textbox
                    }
                    else
                    {
                        SystemSounds.Hand.Play();
                    }
                }
                else if (int.Parse(keyVal) == 37 || int.Parse(keyVal) == 39)
                {
                }
                else if (int.Parse(keyVal) == 13)
                {
                    KeyPressEvent kpe = new KeyPressEvent();
                    kpe.enterButton("bf", "qty", this);
                }
                else
                {
                    SystemSounds.Hand.Play();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error Occured, Please Try Again, " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }




        //------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            string keyVal = e.KeyValue.ToString();

            if (int.Parse(keyVal) == 13 && textBox3.Text != "")
            {
                decimal tot;
                decimal cash;
                Decimal.TryParse(textBox3.Text, out cash);
                Decimal.TryParse(label7.Text, out tot);
                if (cash < tot)
                {
                    MessageBox.Show("Cash value is lesser than Total Invoice amount", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    label14.Text = (cash - tot).ToString();
                }

                //call print function
                //if (PrintClass.printfunction())
                //{
                BillGeneration bg = new BillGeneration();
                bg.billToDB(this);
                //}

            }
            else if (int.Parse(keyVal) == 110) //validate dot---------------------------------------------------------------
            {
                string dot = ".";

                textBox3.Text = textBox3.Text + dot;
                textBox3.Select(textBox3.Text.Length, 0);
            }

            else if (int.Parse(keyVal) == 8) //validate BackSpace---------------------------------------------------------------
            {
                if (textBox3.Text.Length > 0) //check is there any text in the textbox
                {
                    string text = textBox3.Text;
                    text = text.Substring(0, text.Length - 1); //remove last character from the text of the textbox
                    textBox3.Text = text;
                    textBox3.Select(textBox3.Text.Length, 0); //move cursor into the end of text in the textbox

                }
                else
                {

                    SystemSounds.Hand.Play();
                }




            }

            else if (int.Parse(keyVal) > 95 && int.Parse(keyVal) < 106)
            {
                string num = e.KeyCode.ToString();
                num = num.Substring(6, num.Length - 6);
                textBox3.Text = textBox3.Text + num;
                textBox3.Select(textBox3.Text.Length, 0);
            }
            else if (int.Parse(keyVal) == 27)
            {
                this.ActiveControl = txtBoxDescription;
                textBox3.Text = "";
            }

            else
            {
                SystemSounds.Hand.Play();
            }


        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                string keyVal;


                keyVal = e.KeyValue.ToString();


                if (int.Parse(keyVal) == 40)
                {
                    if (dataGridView1.RowCount != 0 || dataGridView1.RowCount != 1)
                    {
                        KeyPressEvent kpe = new KeyPressEvent();
                        kpe.downArrow("bf", "dgv", this); //mb=ManualBilling, dgv=DataGridView

                    }

                }
                else if (int.Parse(keyVal) == 38)
                {
                    KeyPressEvent kpe = new KeyPressEvent();

                    kpe.upArrow("bf", "dgv", this);
                }
                else if (int.Parse(keyVal) == 13)
                {
                    KeyPressEvent kpe = new KeyPressEvent();
                    kpe.enterButton("bf", "dgv", this);

                }
                else if (int.Parse(keyVal) == 27)
                {
                    dataGridView1.Rows[0].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1[0, 0];
                    ActiveControl = txtBoxDescription; // focus on Description textbox
                    dataGridView1.BorderStyle = BorderStyle.Fixed3D; //change borderStyle to identify active control
                    txtBoxDescription.BorderStyle = BorderStyle.FixedSingle; //change borderStyle to identify active control
                    txtBoxDescription.Select(txtBoxDescription.Text.Length, 0);   //move cursor into the end of text in the textbox

                }
                else if (int.Parse(keyVal) == 46)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);

                    if (dataGridView1.RowCount == 0)
                    {
                        ActiveControl = txtBoxDescription; // focus on Description textbox
                        dataGridView1.BorderStyle = BorderStyle.Fixed3D; //change borderStyle to identify active control
                        txtBoxDescription.BorderStyle = BorderStyle.FixedSingle; //change borderStyle to identify active control
                        txtBoxDescription.Select(txtBoxDescription.Text.Length, 0);   //move cursor into the end of text in the textbox
                    }
                    else
                    {

                        dataGridView1.Rows[0].Selected = true;
                        dataGridView1.CurrentCell = dataGridView1[0, 0];
                        ActiveControl = txtBoxDescription; // focus on Description textbox
                        dataGridView1.BorderStyle = BorderStyle.Fixed3D; //change borderStyle to identify active control
                        txtBoxDescription.BorderStyle = BorderStyle.FixedSingle; //change borderStyle to identify active control
                        txtBoxDescription.Select(txtBoxDescription.Text.Length, 0);   //move cursor into the end of text in the textbox
                    }
                    BillGeneration bg = new BillGeneration();
                    bg.total(this);
                }
                else
                {
                    if (int.Parse(keyVal) < 65 && int.Parse(keyVal) > 105 && int.Parse(keyVal) != 32)
                    {

                        SystemSounds.Hand.Play();
                    }

                }
            }

            catch (Exception exc)
            {
                MessageBox.Show("Error Occured, Please Try Again, " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void button15_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);

            if (dataGridView1.RowCount == 0)
            {
                ActiveControl = txtBoxDescription; // focus on Description textbox
                dataGridView1.BorderStyle = BorderStyle.Fixed3D; //change borderStyle to identify active control
                txtBoxDescription.BorderStyle = BorderStyle.FixedSingle; //change borderStyle to identify active control
                txtBoxDescription.Select(txtBoxDescription.Text.Length, 0);   //move cursor into the end of text in the textbox
            }
            else
            {

                dataGridView1.Rows[0].Selected = true;
                dataGridView1.CurrentCell = dataGridView1[0, 0];
                ActiveControl = txtBoxDescription; // focus on Description textbox
                dataGridView1.BorderStyle = BorderStyle.Fixed3D; //change borderStyle to identify active control
                txtBoxDescription.BorderStyle = BorderStyle.FixedSingle; //change borderStyle to identify active control
                txtBoxDescription.Select(txtBoxDescription.Text.Length, 0);   //move cursor into the end of text in the textbox
            }
            BillGeneration bg = new BillGeneration();
            bg.total(this);

        }

        private void Billingform_FormClosing(object sender, FormClosingEventArgs e)
        {
            const string message =
        "Are you sure that you would like to close the form?";
            const string caption = "Form Closing";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            // If the no button was pressed ... 
            if (result == DialogResult.No)
            {
                // cancel the closure of the form.
                e.Cancel = true;
            }
            else
            {
                log.Show();
            }
        }


        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void reload()
        {
            Billingform bf = new Billingform(user_name,log);
            bf.Show();
            this.Close();
        }


    }
}
