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
    class transactionDAL
    {
        static string myconnectionstring = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

        #region Insert Transaction
        public bool Insert_Transaction(transactionsBLL t, out int transactionID)
        {
            bool isSuccess = false;

            transactionID = -1;

            SqlConnection connection = new SqlConnection(myconnectionstring);
            try
            {
                string sql = "INSERT INTO table_transactions (type, dealer_customer_id, grandTotal, transaction_date, tax, discount, added_by) VALUES (@type, @dealer_customer_id, @grandTotal, @transaction_date, @tax, @discount, @added_by); SELECT @@IDENTITY;";

                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@type", t.type);
                command.Parameters.AddWithValue("@dealer_customer_id", t.dealer_customer_id);
                command.Parameters.AddWithValue("@grandTotal", t.grandTotal);
                command.Parameters.AddWithValue("@transaction_date", t.transaction_date);
                command.Parameters.AddWithValue("@tax", t.tax);
                command.Parameters.AddWithValue("@discount", t.discount);
                command.Parameters.AddWithValue("@added_by", t.added_by);

                connection.Open();

                object o = command.ExecuteScalar();

                if (o != null)
                {
                    transactionID = int.Parse(o.ToString());
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
        #region METHOD TO DISPLAY TRANSACTION
        public DataTable DisplayAllTransactions()
        {
            SqlConnection connection = new SqlConnection(myconnectionstring);

            DataTable datatable = new DataTable();

            try
            {
                string sql = "SELECT * FROM table_transactions";

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
        #region METHOD TO DISPLAY TRANSACTION BASED ON TRANSACTION TYPE
        public DataTable DisplayTransactionByType(string type)
        {
            SqlConnection connection = new SqlConnection(myconnectionstring);

            DataTable datatable = new DataTable();

            try
            {
                string sql = "SELECT * FROM table_transactions WHERE type='" + type + "'";

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
