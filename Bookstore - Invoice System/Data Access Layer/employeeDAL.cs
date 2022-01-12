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
    class employeeDAL
    {
        static string myconnectionstring = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

        #region Select data from database
        public DataTable Select()
        {
            SqlConnection connection = new SqlConnection(myconnectionstring);
            DataTable datatable = new DataTable();
            try
            {
                //Get all the data from the database via SQL Query
                String sql = "SELECT * FROM table_employees";
                //To execute the command
                SqlCommand cmd = new SqlCommand(sql, connection);
                //To get the data from database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Open the connection to the database
                connection.Open();
                //Now fill the data in the datatable
                adapter.Fill(datatable);
            }
            catch(Exception error)
            {
                //If an error occurs then display error message on windows form
                MessageBox.Show(error.Message);
            }
            finally
            {
                connection.Close();
            }
            //Now return the values of datatable
            return datatable;
        }
        #endregion
        #region Inserting data into database
        public bool Insert(employeeBLL employee)
        {
            bool isSuccess = false;
            SqlConnection connection = new SqlConnection(myconnectionstring);
            try
            {
                String sql = "INSERT INTO table_employees (first_name, last_name, email, username, password, contact, address, gender, user_type, added_date, added_by) VALUES (@first_name, @last_name, @email, @username, @password, @contact, @address, @gender, @user_type, @added_date, @added_by)";
                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@first_name", employee.first_name);
                cmd.Parameters.AddWithValue("@last_name", employee.last_name);
                cmd.Parameters.AddWithValue("@email", employee.email);
                cmd.Parameters.AddWithValue("@username", employee.username);
                cmd.Parameters.AddWithValue("@password", employee.password);
                cmd.Parameters.AddWithValue("@contact", employee.contact);
                cmd.Parameters.AddWithValue("@address", employee.address);
                cmd.Parameters.AddWithValue("@gender", employee.gender);
                cmd.Parameters.AddWithValue("@user_type", employee.user_type);
                cmd.Parameters.AddWithValue("@added_date", employee.added_date);
                cmd.Parameters.AddWithValue("@added_by", employee.added_by);

                connection.Open();

                int check = cmd.ExecuteNonQuery();

                //If the query is executed Successfully then the value of check will be greater than 0 else it will be less than 0
                if (check > 0)
                {
                    //Query Sucessfull
                    isSuccess = true;
                }
                else
                {
                    //Query Failed
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
        #endregion
        #region Updating data in the database
        public bool Update(employeeBLL employee)
        {
            bool isSuccess = false;
            SqlConnection connection = new SqlConnection(myconnectionstring);

            try
            {
                string sql = "UPDATE table_employees SET first_name = @first_name, last_name = @last_name, email = @email, username = @username, password = @password, contact = @contact, address = @address, gender = @gender, user_type = @user_type, added_date = @added_date, added_by = @added_by WHERE id = @id";
                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@first_name", employee.first_name);
                cmd.Parameters.AddWithValue("@last_name", employee.last_name);
                cmd.Parameters.AddWithValue("@email", employee.email);
                cmd.Parameters.AddWithValue("@username", employee.username);
                cmd.Parameters.AddWithValue("@password", employee.password);
                cmd.Parameters.AddWithValue("@contact", employee.contact);
                cmd.Parameters.AddWithValue("@address", employee.address);
                cmd.Parameters.AddWithValue("@gender", employee.gender);
                cmd.Parameters.AddWithValue("@user_type", employee.user_type);
                cmd.Parameters.AddWithValue("@added_date", employee.added_date);
                cmd.Parameters.AddWithValue("@added_by", employee.added_by);
                cmd.Parameters.AddWithValue("@id", employee.id);

                connection.Open();

                int check = cmd.ExecuteNonQuery();
                if (check > 0)
                {
                    //Query Successfull
                    isSuccess = true;
                }
                else
                {
                    //Query Failed
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
        #endregion
        #region Remove data from database
        public bool Remove(employeeBLL employee)
        {
            bool isSuccess = false;
            SqlConnection connection = new SqlConnection(myconnectionstring);
            try
            {
                string sql = "DELETE FROM table_employees WHERE id=@id";

                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@id", employee.id);
                connection.Open();

                int check = cmd.ExecuteNonQuery();
                if (check > 0)
                {
                    //Query Successfull
                    isSuccess = true;
                }
                else
                {
                    //Query Failed
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
        #endregion
        #region Employee search using keywords
        public DataTable Search(string keywords)
        {
            SqlConnection connection = new SqlConnection(myconnectionstring);
            DataTable datatable = new DataTable();
            try
            {
                //Get all the data from the database via SQL Query
                String sql = "SELECT * FROM table_employees WHERE id LIKE '%" + keywords + "%' OR first_name LIKE '%" + keywords + "%' OR last_name LIKE '%" + keywords + "%' OR username LIKE '%" + keywords + "%'";
                //To execute the command
                SqlCommand cmd = new SqlCommand(sql, connection);
                //To get the data from database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Open the connection to the database
                connection.Open();
                //Now fill the data in the datatable
                adapter.Fill(datatable);
            }
            catch (Exception error)
            {
                //If an error occurs then display error message on windows form
                MessageBox.Show(error.Message);
            }
            finally
            {
                connection.Close();
            }
            //Now return the values of datatable
            return datatable;
        }
        #endregion
        #region Obtain Employee ID from Username
        public employeeBLL ObtainIDFromUsername(string username)
        {
            employeeBLL employee = new employeeBLL();
            SqlConnection connection = new SqlConnection(myconnectionstring);
            DataTable datatable = new DataTable();

            try
            {
                string sql = "SELECT id FROM table_employees WHERE username='" + username + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                connection.Open();

                adapter.Fill(datatable);
                if (datatable.Rows.Count > 0)
                {
                    employee.id = int.Parse(datatable.Rows[0]["id"].ToString());
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
            return employee;
        }
        #endregion
    }
}