using Bookstore___Invoice_System.Business_Logic_Layer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookstore___Invoice_System.Data_Access_Layer
{
    class loginDAL
    {
        //Connect to Database
        static string myconnectionstring = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

        public bool loginCheck(loginBLL login)
        {
            bool isSuccess = false;

            //Connecting To DAtabase
            SqlConnection connection = new SqlConnection(myconnectionstring);

            try
            {
                string sql = "SELECT * FROM table_employees WHERE username=@username AND password=@password AND user_type=@user_type";

                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@username", login.username);
                command.Parameters.AddWithValue("@password", login.password);
                command.Parameters.AddWithValue("@user_type", login.user_type);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable datatable = new DataTable();

                adapter.Fill(datatable);

                //Checking The rows in DataTable 
                if (datatable.Rows.Count > 0)
                {
                    //Login Sucessful
                    isSuccess = true;
                }
                else
                {
                    //Login Failed
                    isSuccess = false;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                connection.Close();
            }

            return isSuccess;
        }
    }
}
