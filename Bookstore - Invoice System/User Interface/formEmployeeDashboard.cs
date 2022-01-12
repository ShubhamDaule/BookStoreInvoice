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
    public partial class formEmployeeDashboard : Form
    {
        public formEmployeeDashboard()
        {
            InitializeComponent();
        }

        public static string transactionType;

        private void formEmployeeDashboard_Load(object sender, EventArgs e)
        {
            labelLoggedInEmployee.Text = formLogin.logged_In_Employee;
        }

        private void formEmployeeDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            formLogin login = new formLogin();
            login.Show();
            this.Hide();
        }

        private void dealerAndCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formDealerCustomer dealerCustomer = new formDealerCustomer();
            dealerCustomer.Show();
        }

        private void purchaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formPurchaseAndSales purchase = new formPurchaseAndSales();
            transactionType = "Purchase";
            purchase.Show();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formPurchaseAndSales sales = new formPurchaseAndSales();
            transactionType = "Sales";
            sales.Show();
        }

        private void transactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formInventory inventory = new formInventory();
            inventory.Show();
        }
    }
}
