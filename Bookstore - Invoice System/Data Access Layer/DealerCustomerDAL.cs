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
    class DealerCustomerDAL
    {
        static string myconnectionstring = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

        #region SELECT Dealer and Customer
        public DataTable Select()
        {
            SqlConnection connection = new SqlConnection(myconnectionstring);

            DataTable datatable = new DataTable();

            try
            {
                string sql = "SELECT * FROM table_dealer_customer";

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
        #region Insert to Add details fo Dealer or Customer
        public bool Insert(DealerCustomer dc)
        {
            SqlConnection connection = new SqlConnection(myconnectionstring);

            bool isSuccess = false;

            try
            {
                string sql = "INSERT INTO table_dealer_customer (type, name, email, contact, address, added_date, added_by) VALUES (@type, @name, @email, @contact, @address, @added_date, @added_by)";

                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@type", dc.type);
                command.Parameters.AddWithValue("@name", dc.name);
                command.Parameters.AddWithValue("@email", dc.email);
                command.Parameters.AddWithValue("@contact", dc.contact);
                command.Parameters.AddWithValue("@address", dc.address);
                command.Parameters.AddWithValue("@added_date", dc.added_date);
                command.Parameters.AddWithValue("@added_by", dc.added_by);

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
        #region UPDATE Dealer and Customer Module
        public bool Update(DealerCustomer dc)
        {
            SqlConnection connection = new SqlConnection(myconnectionstring);

            bool isSuccess = false;

            try
            {
                string sql = "UPDATE table_dealer_customer SET type=@type, name=@name, email=@email, contact=@contact, address=@address, added_date=@added_date, added_by=@added_by WHERE id=@id";

                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@type", dc.type);
                command.Parameters.AddWithValue("@name", dc.name);
                command.Parameters.AddWithValue("@email", dc.email);
                command.Parameters.AddWithValue("@contact", dc.contact);
                command.Parameters.AddWithValue("@address", dc.address);
                command.Parameters.AddWithValue("@added_date", dc.added_date);
                command.Parameters.AddWithValue("@added_by", dc.added_by);
                command.Parameters.AddWithValue("@id", dc.id);

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
        #region DELETE Dealer and Customer Module
        public bool Delete(DealerCustomer dc)
        {
            SqlConnection connection = new SqlConnection(myconnectionstring);

            bool isSuccess = false;

            try
            {
                string sql = "DELETE FROM table_dealer_customer WHERE id=@id";

                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", dc.id);

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
        #region SEARCH Dealer and Customer Module
        public DataTable Search(string keyword)
        {
            SqlConnection connection = new SqlConnection(myconnectionstring);

            DataTable datatable = new DataTable();

            try
            {
                string sql = "SELECT * FROM table_dealer_customer WHERE id LIKE '%" + keyword + "%' OR type LIKE '%" + keyword + "%' OR name LIKE '%" + keyword + "%'";

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
        #region METHOD TO SAERCH DEALER Or CUSTOMER FOR TRANSACTON MODULE
        public DealerCustomer SearchDealerCustomerForTransaction(string keyword)
        {
            DealerCustomer dc = new DealerCustomer();

            SqlConnection connection = new SqlConnection(myconnectionstring);

            DataTable datatable = new DataTable();

            try
            {
                string sql = "SELECT name, email, contact, address from table_dealer_customer WHERE id LIKE '%" + keyword + "%' OR name LIKE '%" + keyword + "%'";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                connection.Open();

                adapter.Fill(datatable);

                if (datatable.Rows.Count > 0)
                {
                    dc.name = datatable.Rows[0]["name"].ToString();
                    dc.email = datatable.Rows[0]["email"].ToString();
                    dc.contact = datatable.Rows[0]["contact"].ToString();
                    dc.address = datatable.Rows[0]["address"].ToString();
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

            return dc;
        }
        #endregion
        #region METHOD TO GET ID OF THE DEALER OR CUSTOMER BASED ON NAME
        public DealerCustomer GetDeaCustIDFromName(string Name)
        {
            DealerCustomer dc = new DealerCustomer();

            SqlConnection connection = new SqlConnection(myconnectionstring);

            DataTable datatable = new DataTable();

            try
            {
                string sql = "SELECT id FROM table_dealer_customer WHERE name='" + Name + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                connection.Open();

                adapter.Fill(datatable);
                if (datatable.Rows.Count > 0)
                {
                    dc.id = int.Parse(datatable.Rows[0]["id"].ToString());
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

            return dc;
        }
        #endregion
    }
}
