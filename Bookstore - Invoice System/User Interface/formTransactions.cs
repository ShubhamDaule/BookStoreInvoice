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
    public partial class formTransactions : Form
    {
        public formTransactions()
        {
            InitializeComponent();
        }

        transactionDAL tdal = new transactionDAL();

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void formTransactions_Load(object sender, EventArgs e)
        {
            DataTable datatable = tdal.DisplayAllTransactions();
            dataGridViewTransactions.DataSource = datatable;
        }

        private void comboBoxTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = comboBoxTransactionType.Text;

            DataTable datatable = tdal.DisplayTransactionByType(type);
            dataGridViewTransactions.DataSource = datatable;
        }

        private void buttonAll_Click(object sender, EventArgs e)
        {
            DataTable datatable = tdal.DisplayAllTransactions();
            dataGridViewTransactions.DataSource = datatable;
        }
    }
}
