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
    public partial class formEmployees : Form
    {
        public formEmployees()
        {
            InitializeComponent();
        }

        employeeBLL employee = new employeeBLL();
        employeeDAL dal = new employeeDAL();

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formEmployees_Load(object sender, EventArgs e)
        {
            DataTable dataTable = dal.Select();
            dataGridViewEmployees.DataSource = dataTable;
        }

        private void Clear()
        {
            textBoxEmployeeID.Text = "";
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxEmail.Text = "";
            textBoxUsername.Text = "";
            textBoxPassword.Text = "";
            textBoxContact.Text = "";
            textBoxAddress.Text = "";
            comboBoxGender.Text = "";
            comboBoxUserType.Text = "";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            
            // get data from user interface
            employee.first_name = textBoxFirstName.Text;
            employee.last_name = textBoxLastName.Text;
            employee.email = textBoxEmail.Text;
            employee.username = textBoxUsername.Text;
            employee.password = textBoxPassword.Text;
            employee.contact = textBoxContact.Text;
            employee.address = textBoxAddress.Text;
            employee.gender = comboBoxGender.Text;
            employee.user_type = comboBoxUserType.Text;
            employee.added_date = DateTime.Now;

            string LoggedInUser = formLogin.logged_In_Employee;
            employeeBLL user = dal.ObtainIDFromUsername(LoggedInUser);
            employee.added_by =  user.id;
            bool success = false;
            // Put data into database
            if (employee.user_type == "" || employee.first_name == "" || employee.username == "" || employee.password == "")
            {
                success = false;
                MessageBox.Show("Please fill in the required fields!");
            }
            else
               success = dal.Insert(employee);
            //if value is inserted, success is true else false
            if(success == true)
            {
                //Inserted succesfully
                MessageBox.Show("Employee Successfully Added!");
                Clear();
            }
            else
            {
                //Failed to insert data
                MessageBox.Show("Failure in adding the new Employee!");
            }
            //Data grid view refresh
            DataTable dataTable = dal.Select();
            dataGridViewEmployees.DataSource = dataTable;
        }

        private void dataGridViewEmployees_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Getting index of a row
            int rowIndex = e.RowIndex;
            textBoxEmployeeID.Text = dataGridViewEmployees.Rows[rowIndex].Cells[0].Value.ToString();
            textBoxFirstName.Text = dataGridViewEmployees.Rows[rowIndex].Cells[1].Value.ToString();
            textBoxLastName.Text = dataGridViewEmployees.Rows[rowIndex].Cells[2].Value.ToString();
            textBoxEmail.Text = dataGridViewEmployees.Rows[rowIndex].Cells[3].Value.ToString();
            textBoxUsername.Text = dataGridViewEmployees.Rows[rowIndex].Cells[4].Value.ToString();
            textBoxPassword.Text = dataGridViewEmployees.Rows[rowIndex].Cells[5].Value.ToString();
            textBoxContact.Text = dataGridViewEmployees.Rows[rowIndex].Cells[6].Value.ToString();
            textBoxAddress.Text = dataGridViewEmployees.Rows[rowIndex].Cells[7].Value.ToString();
            comboBoxGender.Text = dataGridViewEmployees.Rows[rowIndex].Cells[8].Value.ToString();
            comboBoxUserType.Text = dataGridViewEmployees.Rows[rowIndex].Cells[9].Value.ToString();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            //Get the values from User UI
            employee.id = Convert.ToInt32(textBoxEmployeeID.Text);
            employee.first_name = textBoxFirstName.Text;
            employee.last_name = textBoxLastName.Text;
            employee.email = textBoxEmail.Text;
            employee.username = textBoxUsername.Text;
            employee.password = textBoxPassword.Text;
            employee.contact = textBoxContact.Text;
            employee.address = textBoxAddress.Text;
            employee.gender = comboBoxGender.Text;
            employee.user_type = comboBoxUserType.Text;
            employee.added_date = DateTime.Now;
            employee.added_by = 1;

            //Updating Data into database
            bool success = false;
            // Put data into database
            if (employee.user_type == "" || employee.first_name == "" || employee.username == "" || employee.password == "")
            {
                success = false;
                MessageBox.Show("Please fill in the required fields!");
            }
            else
                success = dal.Update(employee);
            //if data is updated successfully then the value of success will be true else it will be false
            if (success == true)
            {
                //Data Updated Successfully
                MessageBox.Show("Employee details successfully updated");
                Clear();
            }
            else
            {
                //failed to update user
                MessageBox.Show("Failure in updating Employee details");
            }
            //Refreshing Data Grid View
            DataTable datatable = dal.Select();
            dataGridViewEmployees.DataSource = datatable;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            //Getting Employee ID from Form
            employee.id = Convert.ToInt32(textBoxEmployeeID.Text);

            bool success = dal.Remove(employee);
            //if data is removed then the value of success will be true else it will be false
            if (success == true)
            {
                //Employee Removed Successfully 
                MessageBox.Show("Employee removed successfully");
                Clear();
            }
            else
            {
                //Failed to remove Employee
                MessageBox.Show("Failed to removed Employee");

            }
            //refreshing datagrid view
            DataTable datatable = dal.Select();
            dataGridViewEmployees.DataSource = datatable;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            //Get Keyword from Text box
            string keywords = textBoxSearch.Text;

            //Chec if the keywords has value or not
            if (keywords != null)
            {
                //Show user based on keywords
                DataTable datatable = dal.Search(keywords);
                dataGridViewEmployees.DataSource = datatable;
            }
            else
            {
                //show all users from the database
                DataTable datatable = dal.Select();
                dataGridViewEmployees.DataSource = datatable;
            }
        }


    }
}
