using Bookstore___Invoice_System.Business_Logic_Layer;
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
    public partial class formBooks : Form
    {
        public formBooks()
        {
            InitializeComponent();
        }

        genreDAL gDAL = new genreDAL();
        booksBLL b = new booksBLL();
        booksDAL bdal = new booksDAL();
        employeeDAL edal = new employeeDAL();

        private void formBooks_Load(object sender, EventArgs e)
        {
            DataTable genreDT = gDAL.Select();
            comboBoxGenre.DataSource = genreDT;
            comboBoxGenre.DisplayMember = "title";
            comboBoxGenre.ValueMember = "title";

            DataTable datatable = bdal.Select();
            dataGridViewBooks.DataSource = datatable;
        }

        private void labelCost_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            b.name = textBoxName.Text;
            b.category = comboBoxGenre.Text;
            b.description = textBoxDescription.Text;
            b.rate = decimal.Parse(textBoxCost.Text);
            b.qty = 0;
            b.added_date = DateTime.Now;
            
            String loggedEmployee = formLogin.logged_In_Employee;
            employeeBLL user = edal.ObtainIDFromUsername(loggedEmployee);

            b.added_by = user.id;

            bool success = bdal.Insert(b);

            if (success == true)
            {
 
                MessageBox.Show("Book Successfully Added!");
                Clear();
                DataTable datatable = bdal.Select();
                dataGridViewBooks.DataSource = datatable;
            }
            else
            {
                MessageBox.Show("Book Could not be Added!");
            }
        }
        public void Clear()
        {
            textBoxBookID.Text = "";
            textBoxName.Text = "";
            textBoxDescription.Text = "";
            textBoxCost.Text = "";
            textBoxSearch.Text = "";
        }

        private void dataGridViewBooks_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            //Display the Value on Respective TextBoxes
            textBoxBookID.Text = dataGridViewBooks.Rows[rowIndex].Cells[0].Value.ToString();
            textBoxName.Text = dataGridViewBooks.Rows[rowIndex].Cells[1].Value.ToString();
            comboBoxGenre.Text = dataGridViewBooks.Rows[rowIndex].Cells[2].Value.ToString();
            textBoxDescription.Text = dataGridViewBooks.Rows[rowIndex].Cells[3].Value.ToString();
            textBoxCost.Text = dataGridViewBooks.Rows[rowIndex].Cells[4].Value.ToString();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            b.id = int.Parse(textBoxBookID.Text);
            b.name = textBoxName.Text;
            b.category = comboBoxGenre.Text;
            b.description = textBoxDescription.Text;
            b.rate = decimal.Parse(textBoxCost.Text);
            b.added_date = DateTime.Now;
            
            String loggedEmployee = formLogin.logged_In_Employee;
            employeeBLL user = edal.ObtainIDFromUsername(loggedEmployee);

            b.added_by = user.id;

            bool success = bdal.Update(b);

            if (success == true)
            {
                MessageBox.Show("Book Successfully Updated!");
                Clear();
             
                DataTable datatable = bdal.Select();
                dataGridViewBooks.DataSource = datatable;
            }
            else
            {
                MessageBox.Show("Failed to Update Book!");
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            b.id = int.Parse(textBoxBookID.Text);


            bool success = bdal.Delete(b);

            if (success == true)
            {
                MessageBox.Show("Book successfully deleted!");
                Clear();
                DataTable datatable = bdal.Select();
                dataGridViewBooks.DataSource = datatable;
            }
            else
            {
                MessageBox.Show("Failed to Delete Book!");
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = textBoxSearch.Text;

            if (keywords != null)
            {
                DataTable datatable = bdal.Search(keywords);
                dataGridViewBooks.DataSource = datatable;
            }
            else
            {
                DataTable datatable = bdal.Select();
                dataGridViewBooks.DataSource = datatable;
            }
        }
    }
}
