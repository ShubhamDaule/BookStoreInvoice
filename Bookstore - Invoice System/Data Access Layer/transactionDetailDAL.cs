using Bookstore___Invoice_System.Business_Logic_Layer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookstore___Invoice_System.Data_Access_Layer
{
    class transactionDetailDAL
    {
        static string myconnectionstring = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

        #region Insert Transaction Detail
        public bool InsertTransactionDetail(transactionDetailBLL td)
        {
            bool isSuccess = false;

            SqlConnection connection = new SqlConnection(myconnectionstring);

            try
            {
                string sql = "INSERT INTO table_transaction_detail (book_id, rate, qty, total, dealer_customer_id, added_date, added_by) VALUES (@book_id, @rate, @qty, @total, @dealer_customer_id, @added_date, @added_by)";

                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@book_id", td.book_id);
                command.Parameters.AddWithValue("@rate", td.rate);
                command.Parameters.AddWithValue("@qty", td.qty);
                command.Parameters.AddWithValue("@total", td.total);
                command.Parameters.AddWithValue("@dealer_customer_id", td.dealer_customer_id);
                command.Parameters.AddWithValue("@added_date", td.added_date);
                command.Parameters.AddWithValue("@added_by", td.added_by);

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
    }
}
