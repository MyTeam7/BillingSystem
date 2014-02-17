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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.ActiveControl = BtnLogin;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        //Login button Click event
        private void BtnLogin_Click(object sender, EventArgs e)
        {

            User UPName = new User();
            //set username
            UPName.GetUsername = UserName.Text;
            //set password
            UPName.GetPassword = maskedTextBox1.Text;

            //check if username empty
            if (UserName.Text != " ")
            {
                //check username with datbase
                if (UPName.UsernameAuthenticaion())
                {
                    //check if password empty
                    if (maskedTextBox1.Text != " ")
                    {
                        //check username with datbase
                        if (UPName.PasswordAuthenticaion())
                        {
                            //get the catagory
                            if (UPName.UserCatagory() == "Admin")
                            {
                                Admin AdminForm = new Admin(this);
                                AdminForm.Show();
                                this.Hide();

                                //Reset textboxes
                                UserName.Text = "UserName";
                                maskedTextBox1.Text = "Password";
                            }
                            else if (UPName.UserCatagory() == "User")
                            {
                                Billingform Bill = new Billingform(UPName.GetUsername, this);
                                Bill.Show();
                                this.Hide();

                                //Reset textboxes
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

    }
}
