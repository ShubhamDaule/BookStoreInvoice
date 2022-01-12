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
    class genreDAL
    {
        static string myconnectionstring = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

        #region Select Method
        public DataTable Select()
        {
           
            SqlConnection connection = new SqlConnection(myconnectionstring);

            DataTable datatable = new DataTable();

            try
            {
               
                string sql = "SELECT * FROM table_categories";

                SqlCommand command = new SqlCommand(sql, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                
                
                connection.Open();
                
                adapter.Fill(datatable);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                connection.Close();
            }

            return datatable;
        }
        #endregion
        #region Insert Genre
        public bool Insert(genreBLL g)
        {
            
            bool isSuccess = false;

            
            SqlConnection connection = new SqlConnection(myconnectionstring);

            try
            {
               
                string sql = "INSERT INTO table_categories (title, description, added_date, added_by) VALUES (@title, @description, @added_date, @added_by)";

                
                SqlCommand command = new SqlCommand(sql, connection);
                
                command.Parameters.AddWithValue("@title", g.title);
                command.Parameters.AddWithValue("@description", g.description);
                command.Parameters.AddWithValue("@added_date", g.added_date);
                command.Parameters.AddWithValue("@added_by", g.added_by);

                connection.Open();

                int rows = command.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
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
        #region Update Method
        public bool Update(genreBLL g)
        {           
            bool isSuccess = false;

            SqlConnection connection = new SqlConnection(myconnectionstring);

            try
            {
                string sql = "UPDATE table_categories SET title=@title, description=@description, added_date=@added_date, added_by=@added_by WHERE id=@id";

                SqlCommand command = new SqlCommand(sql, connection);

              
                command.Parameters.AddWithValue("@title", g.title);
                command.Parameters.AddWithValue("@description", g.description);
                command.Parameters.AddWithValue("@added_date", g.added_date);
                command.Parameters.AddWithValue("@added_by", g.added_by);
                command.Parameters.AddWithValue("@id", g.id);

               
                connection.Open();

           
                int rows = command.ExecuteNonQuery();

               
                if (rows > 0)
                {
                    
                    isSuccess = true;
                }
                else
                {
                  
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
        #region Delete Genre
        public bool Delete(genreBLL g)
        {
            bool isSuccess = false;

            SqlConnection connection = new SqlConnection(myconnectionstring);

            try
            {
                
                string sql = "DELETE FROM table_categories WHERE id=@id";

                SqlCommand command = new SqlCommand(sql, connection);
               
                command.Parameters.AddWithValue("@id", g.id);

              
                connection.Open();

                int rows = command.ExecuteNonQuery();

               
                if (rows > 0)
                {
                  
                    isSuccess = true;
                }
                else
                {
                
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
        #region Search function
        public DataTable Search(string keywords)
        {
            
            SqlConnection connection = new SqlConnection(myconnectionstring);

            
            DataTable datatable = new DataTable();

            try
            {
                
                String sql = "SELECT * FROM table_categories WHERE id LIKE '%" + keywords + "%' OR title LIKE '%" + keywords + "%' OR description LIKE '%" + keywords + "%'";
               
                SqlCommand command = new SqlCommand(sql, connection);

                
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                connection.Open();

                adapter.Fill(datatable);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                connection.Close();
            }

            return datatable;
        }
        #endregion
    }
}
