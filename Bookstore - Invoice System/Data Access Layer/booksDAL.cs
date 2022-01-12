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
    class booksDAL
    {
        static string myconnectionstring = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

        #region Select method for Books
        public DataTable Select()
        { 
            SqlConnection connection = new SqlConnection(myconnectionstring);

            DataTable datatable = new DataTable();

            try
            {              
                String sql = "SELECT * FROM table_books";
              
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
        #region Insert Books in database
        public bool Insert(booksBLL b)
        {
            bool isSuccess = false;

            SqlConnection connection = new SqlConnection(myconnectionstring);

            try
            {       
                String sql = "INSERT INTO table_books (name, category, description, rate, qty, added_date, added_by) VALUES (@name, @category, @description, @rate, @qty, @added_date, @added_by)";
             
                SqlCommand command = new SqlCommand(sql, connection);
          
                command.Parameters.AddWithValue("@name", b.name);
                command.Parameters.AddWithValue("@category", b.category);
                command.Parameters.AddWithValue("@description", b.description);
                command.Parameters.AddWithValue("@rate", b.rate);
                command.Parameters.AddWithValue("@qty", b.qty);
                command.Parameters.AddWithValue("@added_date", b.added_date);
                command.Parameters.AddWithValue("@added_by", b.added_by);
             
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
        #region Update Books in Database
        public bool Update(booksBLL b)
        {
            bool isSuccess = false;

            SqlConnection connection = new SqlConnection(myconnectionstring);

            try
            {
                String sql = "UPDATE table_books SET name=@name, category=@category, description=@description, rate=@rate, added_date=@added_date, added_by=@added_by WHERE id=@id";

                SqlCommand command = new SqlCommand(sql, connection);
             
                command.Parameters.AddWithValue("@name", b.name);
                command.Parameters.AddWithValue("@category", b.category);
                command.Parameters.AddWithValue("@description", b.description);
                command.Parameters.AddWithValue("@rate", b.rate);
                command.Parameters.AddWithValue("@qty", b.qty);
                command.Parameters.AddWithValue("@added_date", b.added_date);
                command.Parameters.AddWithValue("@added_by", b.added_by);
                command.Parameters.AddWithValue("@id", b.id);

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
        #region Delete Books from database
        public bool Delete(booksBLL b)
        {
            bool isSuccess = false;

            SqlConnection connection = new SqlConnection(myconnectionstring);

            try
            {
                String sql = "DELETE FROM table_books WHERE id=@id";

                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", b.id);

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
        #region SEARCH Method for Product Module
        public DataTable Search(string keywords)
        {
            SqlConnection connection = new SqlConnection(myconnectionstring);

            DataTable datatable = new DataTable();

            try
            {
                string sql = "SELECT * FROM table_books WHERE id LIKE '%" + keywords + "%' OR name LIKE '%" + keywords + "%' OR category LIKE '%" + keywords + "%'";

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
        #region SEARCH PRODUCT IN TRANSACTION MODULE
        public booksBLL GetProductsForTransaction(string keyword)
        {
            booksBLL b = new booksBLL();

            SqlConnection connection = new SqlConnection(myconnectionstring);

            DataTable datatable = new DataTable();

            try
            {
                string sql = "SELECT name, rate, qty FROM table_books WHERE id LIKE '%" + keyword + "%' OR name LIKE '%" + keyword + "%'";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                connection.Open();

                adapter.Fill(datatable);

                if (datatable.Rows.Count > 0)
                {
                    b.name = datatable.Rows[0]["name"].ToString();
                    b.rate = decimal.Parse(datatable.Rows[0]["rate"].ToString());
                    b.qty = decimal.Parse(datatable.Rows[0]["qty"].ToString());
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

            return b;
        }
        #endregion
        #region METHOD TO GET PRODUCT ID BASED ON PRODUCT NAME
        public booksBLL GetProductIDFromName(string ProductName)
        {
            booksBLL b = new booksBLL();

            SqlConnection connection = new SqlConnection(myconnectionstring);

            DataTable datatable = new DataTable();

            try
            {
                string sql = "SELECT id FROM table_books WHERE name='" + ProductName + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                connection.Open();

                adapter.Fill(datatable);
                if (datatable.Rows.Count > 0)
                {
                    b.id = int.Parse(datatable.Rows[0]["id"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return b;
        }
        #endregion
        #region METHOD TO GET CURRENT QUantity from the Database based on Product ID
        public decimal GetProductQty(int ProductID)
        {
            SqlConnection connection = new SqlConnection(myconnectionstring);

            decimal qty = 0;

            DataTable datatable = new DataTable();

            try
            {

                string sql = "SELECT qty FROM table_books WHERE id = " + ProductID;

                SqlCommand command = new SqlCommand(sql, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                connection.Open();

                adapter.Fill(datatable);

                if (datatable.Rows.Count > 0)
                {
                    qty = decimal.Parse(datatable.Rows[0]["qty"].ToString());
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

            return qty;
        }
        #endregion
        #region METHOD TO UPDATE QUANTITY
        public bool UpdateQuantity(int ProductID, decimal Qty)
        {
            bool success = false;

            SqlConnection connection = new SqlConnection(myconnectionstring);

            try
            {
                string sql = "UPDATE table_books SET qty=@qty WHERE id=@id";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@qty", Qty);
                command.Parameters.AddWithValue("@id", ProductID);

                connection.Open();

                int rows = command.ExecuteNonQuery();

                if (rows > 0)
                {
                    success = true;
                }
                else
                {
                    success = false;
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

            return success;
        }
        #endregion
        #region METHOD TO INCREASE PRODUCT
        public bool IncreaseProduct(int ProductID, decimal IncreaseQty)
        {
            bool success = false;

            SqlConnection connection = new SqlConnection(myconnectionstring);

            try
            {
                decimal currentQty = GetProductQty(ProductID);

                decimal NewQty = currentQty + IncreaseQty;

                success = UpdateQuantity(ProductID, NewQty);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                connection.Close();
            }
            return success;
        }
        #endregion
        #region METHOD TO DECREASE PRODUCT
        public bool DecreaseProduct(int ProductID, decimal Qty)
        {
            bool success = false;

            SqlConnection connection = new SqlConnection(myconnectionstring);

            try
            {
                decimal currentQty = GetProductQty(ProductID);

                decimal NewQty = currentQty - Qty;
                if(NewQty >= 0)
                    success = UpdateQuantity(ProductID, NewQty);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                connection.Close();
            }
            return success;
        }
        #endregion
        #region DISPLAY PRODUCTS BASED ON CATEGORIES
        public DataTable DisplayProductsByCategory(string category)
        {
            SqlConnection connection = new SqlConnection(myconnectionstring);

            DataTable datatable = new DataTable();

            try
            {
                string sql = "SELECT * FROM table_books WHERE category='" + category + "'";

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
