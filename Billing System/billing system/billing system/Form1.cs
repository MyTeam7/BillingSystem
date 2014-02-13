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

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            
            User UPName = new User();
            UPName.GetUsername = UserName.Text;
            UPName.GetPassword = maskedTextBox1.Text;

            if (UserName.Text == " ")
            {
                MessageBox.Show("empty");
            }


            if (UPName.UsernameAuthenticaion())
            {
                if (UPName.PasswordAuthenticaion())
                {
                    //MessageBox.Show("you are loged!!!!!");
                    if (UPName.UserCatagory() == "Admin")
                    {
                        Admin AdminForm = new Admin();
                        AdminForm.Show();
                        UserName.Text = "UserName";
                        maskedTextBox1.Text = "Password";
                    }
                    else if (UPName.UserCatagory() == "User")
                    {
                        Billingform Bill = new Billingform();
                        Bill.Show();
                        UserName.Text = "UserName";
                        maskedTextBox1.Text = "Password";
                    }

                }
                else
               
                    MessageBox.Show("PASSWORD is WRONG!!!!!");
                
            }

            else
                MessageBox.Show("USERNAME is INCORRESCT!!!!!");
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
