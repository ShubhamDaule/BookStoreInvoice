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
    public partial class formBookGenres : Form
    {
        public formBookGenres()
        {
            InitializeComponent();
        }

        private void formBookGenres_Load(object sender, EventArgs e)
        {
            DataTable datatable = dal.Select();
            dataGridViewBookGenres.DataSource = datatable;
        }

        private void labelBookGenreID_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        genreBLL g = new genreBLL();
        genreDAL dal = new genreDAL();
        employeeDAL edal = new employeeDAL();
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            g.title = textBoxGenre.Text;
            g.description = textBoxDescription.Text;
            g.added_date = DateTime.Now;

            
            string loggedEmployee = formLogin.logged_In_Employee;
            employeeBLL user = edal.ObtainIDFromUsername(loggedEmployee);
            
            g.added_by = user.id;

            
            bool success = dal.Insert(g);

            
            if (success == true)
            {
                
                MessageBox.Show("Genre Successfully Added!");
                Clear();
                
                DataTable datatable = dal.Select();
                dataGridViewBookGenres.DataSource = datatable;
            }
            else
            {
                MessageBox.Show("Failed to add Genre!");
            }
        }
        public void Clear()
        {
            textBoxBookGenreID.Text = "";
            textBoxGenre.Text = "";
            textBoxDescription.Text = "";
            textBoxSearch.Text = "";
        }

        private void dataGridViewBookGenres_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int RowIndex = e.RowIndex;
            textBoxBookGenreID.Text = dataGridViewBookGenres.Rows[RowIndex].Cells[0].Value.ToString();
            textBoxGenre.Text = dataGridViewBookGenres.Rows[RowIndex].Cells[1].Value.ToString();
            textBoxDescription.Text = dataGridViewBookGenres.Rows[RowIndex].Cells[2].Value.ToString();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            g.id = int.Parse(textBoxBookGenreID.Text);
            g.title = textBoxGenre.Text;
            g.description = textBoxDescription.Text;
            g.added_date = DateTime.Now;

            string loggedEmployee = formLogin.logged_In_Employee;
            employeeBLL user = edal.ObtainIDFromUsername(loggedEmployee);
            
            g.added_by = user.id;

            
            bool success = dal.Update(g);
            
            if (success == true)
            {
                
                MessageBox.Show("Genre Successfully Updated!");
                Clear();
                
                DataTable datatable = dal.Select();
                dataGridViewBookGenres.DataSource = datatable;
            }
            else
            {
               
                MessageBox.Show("Failed to Update Genre!");
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            g.id = int.Parse(textBoxBookGenreID.Text);

            
            bool success = dal.Delete(g);

            if (success == true)
            {
                
                MessageBox.Show("Genre Successfully Removed!");
                Clear();
               
                DataTable datatable = dal.Select();
                dataGridViewBookGenres.DataSource = datatable;
            }
            else
            {
                MessageBox.Show("Failed to Remove Genre!");
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = textBoxSearch.Text;

            if (keywords != null)
            {

                DataTable datatable = dal.Search(keywords);
                dataGridViewBookGenres.DataSource = datatable;
            }
            else
            {

                DataTable datatable = dal.Select();
                dataGridViewBookGenres.DataSource = datatable;
            }
        }
    }
}
