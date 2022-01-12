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
    public partial class formInventory : Form
    {
        public formInventory()
        {
            InitializeComponent();
        }

        private void dataGridViewTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        genreDAL gdal = new genreDAL();
        booksDAL bdal = new booksDAL();

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void formInventory_Load(object sender, EventArgs e)
        {
            DataTable gdatatable = gdal.Select();
            comboBoxBookGenre.DataSource = gdatatable;

            comboBoxBookGenre.DisplayMember = "title";
            comboBoxBookGenre.ValueMember = "title";

            DataTable bdatatable = bdal.Select();
            dataGridViewBooks.DataSource = bdatatable;
        }

        private void comboBoxBookGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = comboBoxBookGenre.Text;

            DataTable datatable = bdal.DisplayProductsByCategory(category);
            dataGridViewBooks.DataSource = datatable;
        }

        private void buttonAll_Click(object sender, EventArgs e)
        {
            DataTable datatable = bdal.Select();
            dataGridViewBooks.DataSource = datatable;
        }
    }
}
