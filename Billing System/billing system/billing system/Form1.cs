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

            if (UPName.UsernameAuthenticaion())
            {
                if (UPName.PasswordAuthenticaion())
                {
                    //MessageBox.Show("you are loged!!!!!");
                    if (UPName.UserCatagory() == "admin")
                    {
                        Admin AdminForm = new Admin();
                        AdminForm.Show();
                    }
                    else if (UPName.UserCatagory() == "user")
                    {
                        Billingform Bill = new Billingform();
                        Bill.Show();
                    }
                   
                }
                else
                    MessageBox.Show("PASSWORD is WRONG!!!!!");
            }
            else
                MessageBox.Show("USERNAME is INCORRESCT!!!!!");
        }

        

       
    }
}
