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
    public partial class formDealerCustomer : Form
    {
        public formDealerCustomer()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        DealerCustomer dc = new DealerCustomer();
        DealerCustomerDAL dcDal = new DealerCustomerDAL();
        employeeDAL eDal = new employeeDAL();

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            dc.type = comboBoxType.Text;
            dc.name = textBoxName.Text;
            dc.email = textBoxEmail.Text;
            dc.contact = textBoxContact.Text;
            dc.address = textBoxAddress.Text;
            dc.added_date = DateTime.Now;

            string loggedEmployee = formLogin.logged_In_Employee;
            employeeBLL user = eDal.ObtainIDFromUsername(loggedEmployee);
            dc.added_by = user.id;

            bool success = dcDal.Insert(dc);

            if (success == true)
            {
                MessageBox.Show("Dealer or Customer Added Successfully!");
                Clear();
                DataTable datatable = dcDal.Select();
                dataGridViewDealerCustomer.DataSource = datatable;
            }
            else
            {
                MessageBox.Show("Failed to add Dealer or Customer!");
            }
        }
        public void Clear()
        {
            textBoxDealerCustomerID.Text = "";
            textBoxName.Text = "";
            textBoxEmail.Text = "";
            textBoxContact.Text = "";
            textBoxAddress.Text = "";
            textBoxSearch.Text = "";
        }

        private void formDealerCustomer_Load(object sender, EventArgs e)
        {
            DataTable datatable = dcDal.Select();
            dataGridViewDealerCustomer.DataSource = datatable;
        }

        private void dataGridViewDealerCustomer_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;

            textBoxDealerCustomerID.Text = dataGridViewDealerCustomer.Rows[rowIndex].Cells[0].Value.ToString();
            comboBoxType.Text = dataGridViewDealerCustomer.Rows[rowIndex].Cells[1].Value.ToString();
            textBoxName.Text = dataGridViewDealerCustomer.Rows[rowIndex].Cells[2].Value.ToString();
            textBoxEmail.Text = dataGridViewDealerCustomer.Rows[rowIndex].Cells[3].Value.ToString();
            textBoxContact.Text = dataGridViewDealerCustomer.Rows[rowIndex].Cells[4].Value.ToString();
            textBoxAddress.Text = dataGridViewDealerCustomer.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            dc.id = int.Parse(textBoxDealerCustomerID.Text);
            dc.type = comboBoxType.Text;
            dc.name = textBoxName.Text;
            dc.email = textBoxEmail.Text;
            dc.contact = textBoxContact.Text;
            dc.address = textBoxAddress.Text;
            dc.added_date = DateTime.Now;

            string loggedEmployee = formLogin.logged_In_Employee;
            employeeBLL user = eDal.ObtainIDFromUsername(loggedEmployee);
            dc.added_by = user.id;

            bool success = dcDal.Update(dc);

            if (success == true)
            {
                MessageBox.Show("Dealer or Customer updated Successfully!");
                Clear();

                DataTable datatable = dcDal.Select();
                dataGridViewDealerCustomer.DataSource = datatable;
            }
            else
            {
                MessageBox.Show("Failed to Udpate Dealer or Customer!");
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            dc.id = int.Parse(textBoxDealerCustomerID.Text);

            bool success = dcDal.Delete(dc);

            if (success == true)
            {
                MessageBox.Show("Dealer or Customer Deleted Successfully!");
                Clear();
                DataTable datatable = dcDal.Select();
                dataGridViewDealerCustomer.DataSource = datatable;
            }
            else
            {
                MessageBox.Show("Failed to Delete Dealer or Customer!");
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBoxSearch.Text;

            if (keyword != null)
            {
                DataTable datatable = dcDal.Search(keyword);
                dataGridViewDealerCustomer.DataSource = datatable;
            }
            else
            {
                DataTable datatable = dcDal.Select();
                dataGridViewDealerCustomer.DataSource = datatable;
            }
        }
    }
}
