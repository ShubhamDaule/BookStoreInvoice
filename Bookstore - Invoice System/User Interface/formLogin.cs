using Bookstore___Invoice_System.Business_Logic_Layer;
using Bookstore___Invoice_System.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookstore___Invoice_System.User_Interface
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        loginBLL login = new loginBLL();
        loginDAL dal = new loginDAL();
        public static string logged_In_Employee;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //closing the login form
            this.Close();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            login.username = textBoxUsername.Text.Trim();
            login.password = textBoxPassword.Text.Trim();
            login.user_type = comboBoxUserType.Text.Trim();


            bool success = dal.loginCheck(login);
            if (success == true)
            {
                //Login Successfull
                MessageBox.Show("Login Successful!");
                logged_In_Employee = login.username;
                switch (login.user_type)
                {
                    case "Administrator":
                        {
                            //Display Admin Dashboard
                            formAdminDashboard admin = new formAdminDashboard();
                            admin.Show();
                            this.Hide();
                        }
                        break;

                    case "Employee":
                        {
                            //Display User Dashboard
                            formEmployeeDashboard user = new formEmployeeDashboard();
                            user.Show();
                            this.Hide();
                        }
                        break;

                    default:
                        {
                            //Display an error message
                            MessageBox.Show("User Type Invalid!");
                        }
                        break;
                }
            }
            else
            {
                //login Failed
                MessageBox.Show("Login Failed, Try Again!");
            }
        }
    }
}
