using Bookstore___Invoice_System.User_Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookstore___Invoice_System
{
    public partial class formAdminDashboard : Form
    {
        public formAdminDashboard()
        {
            InitializeComponent();
        }

        private void formAdminDashboard_Load(object sender, EventArgs e)
        {
            labelLoggedInEmployee.Text = formLogin.logged_In_Employee;
        }

        private void labelSubHead_Click(object sender, EventArgs e)
        {

        }

        private void labelLoggedInEmployee_Click(object sender, EventArgs e)
        {

        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formEmployees employee = new formEmployees();
            employee.Show();
        }

        private void formAdminDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            formLogin login = new formLogin();
            login.Show();
            this.Hide();
        }

        private void genreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formBookGenres genre = new formBookGenres();
            genre.Show();
        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formBooks book = new formBooks();
            book.Show();
        }

        private void dealerAndCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formDealerCustomer dealerCustomer = new formDealerCustomer();
            dealerCustomer.Show();
        }

        private void transactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formTransactions transaction = new formTransactions();
            transaction.Show();
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formInventory inventory = new formInventory();
            inventory.Show();
        }
    }
}
