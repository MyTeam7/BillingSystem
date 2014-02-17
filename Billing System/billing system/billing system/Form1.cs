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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.ActiveControl = UserName;
            this.KeyPreview = true;
            this.UserName.KeyDown += new KeyEventHandler(UserName_KeyDown);
            this.maskedTextBox1.KeyDown += new KeyEventHandler(maskedTextBox1_KeyDown);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserName.Text = "";
            maskedTextBox1.Text = "";
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {

            User UPName = new User();
            UPName.GetUsername = UserName.Text;
            UPName.GetPassword = maskedTextBox1.Text;

            if (UserName.Text != " ")
            {
                if (UPName.UsernameAuthenticaion())
                {
                    if (maskedTextBox1.Text != " ")
                    {
                        if (UPName.PasswordAuthenticaion())
                        {
                            if (UPName.UserCatagory() == "Admin")
                            {
                                Admin AdminForm = new Admin(this);
                                AdminForm.Show();
                                this.Hide();

                                UserName.Text = "UserName";
                                maskedTextBox1.Text = "Password";
                                UserName.ForeColor = Color.Gray;
                                maskedTextBox1.ForeColor = Color.Gray;
                                maskedTextBox1.PasswordChar = '\0';
                            }
                            else if (UPName.UserCatagory() == "User")
                            {
                                Billingform Bill = new Billingform(UPName.GetUsername, this);
                                Bill.Show();
                                this.Hide();

                                UserName.Text = "UserName";
                                maskedTextBox1.Text = "Password";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Enter CORRECT Password");
                        }
                    }
                    else
                    {
                        MessageBox.Show("password is Empty");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter CORRECT Username");
                }
            }
            else
            {
                MessageBox.Show("Username is Empty");
            }


        }

        private void UserName_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void UserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidationText log = new ValidationText();
            log.UserName_KeyPress(sender, e);

        }

        private void UserName_Click(object sender, EventArgs e)
        {
            UserName.Text = string.Empty;
        }

        private void maskedTextBox1_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Text = string.Empty;
        }



        public void UserName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {



                string keyVal;

                keyVal = e.KeyValue.ToString(); //keycode value



                if (int.Parse(keyVal) > 64 && int.Parse(keyVal) < 106) //validate Alphanumeric characters-------------------------
                {


                    if (UserName.Text == "UserName")
                    {
                        UserName.Text = "";
                    }
                    UserName.ForeColor = Color.Black;
                    UserName.ReadOnly = false;

                    UserName.Select(UserName.Text.Length, 0);

                }




                if (int.Parse(keyVal) == 9)
                {

                    if (UserName.Text == "UserName")
                    {
                        SystemSounds.Hand.Play();
                    }
                    else
                    {
                        this.ActiveControl = maskedTextBox1;

                    }



                }






            }
            catch (Exception exc)
            {
                MessageBox.Show("Error Occured, Please Try Again, " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }








        public void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                string keyVal;

                keyVal = e.KeyValue.ToString(); //keycode value


                if (int.Parse(keyVal) > 64 && int.Parse(keyVal) < 106) //validate Alphanumeric characters-------------------------
                {

                    if (maskedTextBox1.Text == "Password")
                    {
                        maskedTextBox1.Text = "";
                        maskedTextBox1.ForeColor = Color.Black;
                    }
                    maskedTextBox1.PasswordChar = '*';
                    maskedTextBox1.ReadOnly = false;

                    maskedTextBox1.Select(maskedTextBox1.Text.Length, 0);

                }




                if (int.Parse(keyVal) == 13)
                {
                    if (maskedTextBox1.Text == "Password")
                    {
                        MessageBox.Show("Please Enter your Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        BtnLogin_Click(sender, e);
                    }

                }




            }
            catch (Exception exc)
            {
                MessageBox.Show("Error Occured, Please Try Again, " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }



    }
}
