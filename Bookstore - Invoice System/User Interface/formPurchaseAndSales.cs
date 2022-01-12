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
using System.Transactions;
using System.Windows.Forms;

namespace Bookstore___Invoice_System.User_Interface
{
    public partial class formPurchaseAndSales : Form
    {
        public formPurchaseAndSales()
        {
            InitializeComponent();
        }

        DealerCustomerDAL dcDAL = new DealerCustomerDAL();
        booksDAL bDAL = new booksDAL();
        employeeDAL eDAL = new employeeDAL();
        transactionDAL tDAL = new transactionDAL();
        transactionDetailDAL tdDAL = new transactionDetailDAL();

        DataTable transactionDT = new DataTable();
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void labelContact_Click(object sender, EventArgs e)
        {

        }

        private void labelSearch_Click(object sender, EventArgs e)
        {

        }

        private void labelReturnAmount_Click(object sender, EventArgs e)
        {

        }

        private void formPurchaseAndSales_Load(object sender, EventArgs e)
        {
            string type = formEmployeeDashboard.transactionType;

            labelTop.Text = type;

            transactionDT.Columns.Add("Book Name");
            transactionDT.Columns.Add("Rate");
            transactionDT.Columns.Add("Quantity");
            transactionDT.Columns.Add("Total");
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBoxSearch.Text;

            if (keyword == "")
            {
                textBoxName.Text = "";
                textBoxEmail.Text = "";
                textBoxContact.Text = "";
                textBoxAddress.Text = "";
                return;
            }

            DealerCustomer dc = dcDAL.SearchDealerCustomerForTransaction(keyword);

            textBoxName.Text = dc.name;
            textBoxEmail.Text = dc.email;
            textBoxContact.Text = dc.contact;
            textBoxAddress.Text = dc.address;
        }

        private void textBoxSearchBook_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBoxSearchBook.Text;

            if (keyword == "")
            {
                textBoxBookName.Text = "";
                textBoxInventory.Text = "";
                textBoxCost.Text = "";
                textBoxQty.Text = "";
                return;
            }

            booksBLL b = bDAL.GetProductsForTransaction(keyword);

            textBoxBookName.Text = b.name;
            textBoxInventory.Text = b.qty.ToString();
            textBoxCost.Text = b.rate.ToString();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string bookName = textBoxBookName.Text;
            decimal Cost = decimal.Parse(textBoxCost.Text);
            decimal Qty = decimal.Parse(textBoxQty.Text);
            decimal inventory = decimal.Parse(textBoxInventory.Text);
            //string form = labelTop.Text;
            if (inventory < Qty && labelTop.Text == "Sales")
            {
                MessageBox.Show("Book not in stock!!");
            }
            else if (bookName == "")
            {
                MessageBox.Show("Select the book first. Try Again!");
            }
            else
            {
                decimal Total = Cost * Qty;

                decimal subTotal = decimal.Parse(textBoxSubTotal.Text);
                subTotal = subTotal + Total;

                transactionDT.Rows.Add(bookName, Cost, Qty, Total);

                dataGridViewAddedBooks.DataSource = transactionDT;

                textBoxSubTotal.Text = subTotal.ToString();

                textBoxSearchBook.Text = "";
                textBoxBookName.Text = "";
                textBoxInventory.Text = "0.00";
                textBoxCost.Text = "0.00";
                textBoxQty.Text = "0.00";
            }
        }

        private void textBoxDiscount_TextChanged(object sender, EventArgs e)
        {
            string check = textBoxDiscount.Text;

            if (check == "")
            {
                MessageBox.Show("Please fill the discount box with zero if not used");
            }
            else
            {
                decimal subTotal = decimal.Parse(textBoxSubTotal.Text);
                decimal discount = decimal.Parse(textBoxDiscount.Text);

                decimal grandTotal = ((100 - discount) / 100) * subTotal;

                textBoxGrandTotal.Text = grandTotal.ToString();
            }
        }

        private void textBoxVat_TextChanged(object sender, EventArgs e)
        {
            string check = textBoxVat.Text;
            if (check == "")
            {
                MessageBox.Show("Please fill the VAT box with zero if not used");
            }
            else
            {
                decimal previousGrandTotal = decimal.Parse(textBoxGrandTotal.Text);
                decimal vat = decimal.Parse(textBoxVat.Text);
                decimal grandTotalWithVAT = ((100 + vat) / 100) * previousGrandTotal;

                textBoxGrandTotal.Text = grandTotalWithVAT.ToString();
            }
        }

        private void textBoxPaidAmount_TextChanged(object sender, EventArgs e)
        {

            string check = textBoxPaidAmount.Text;
            string check2 = textBoxGrandTotal.Text;
            if (check == "")
            {
                MessageBox.Show("Please fill the Paid Amount box with zero if not used");
            }
            else if (check2 == "")
            {
                MessageBox.Show("Please fill the Grand Total box with zero if not used");
            }
            else
            {
                decimal grandTotal = decimal.Parse(textBoxGrandTotal.Text);
                decimal paidAmount = decimal.Parse(textBoxPaidAmount.Text);

                decimal returnAmount = paidAmount - grandTotal;

                textBoxReturnAmount.Text = returnAmount.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            transactionsBLL transaction = new transactionsBLL();

            transaction.type = labelTop.Text;

            string deaCustName = textBoxName.Text;
            DealerCustomer dc = dcDAL.GetDeaCustIDFromName(deaCustName);

            transaction.dealer_customer_id = dc.id;
            transaction.grandTotal = Math.Round(decimal.Parse(textBoxGrandTotal.Text), 2);
            transaction.transaction_date = DateTime.Now;
            transaction.tax = decimal.Parse(textBoxVat.Text);
            transaction.discount = decimal.Parse(textBoxDiscount.Text);

            string username = formLogin.logged_In_Employee;
            employeeBLL u = eDAL.ObtainIDFromUsername(username);

            transaction.added_by = u.id;
            transaction.transactionDetails = transactionDT;

            bool success = false;

            using (TransactionScope scope = new TransactionScope())
            {
                int transactionID = -1;
 
                bool w = tDAL.Insert_Transaction(transaction, out transactionID);

                for (int i = 0; i < transactionDT.Rows.Count; i++)
                {
                    transactionDetailBLL transactionDetail = new transactionDetailBLL();

                    string BookName = transactionDT.Rows[i][0].ToString();
                    booksBLL b = bDAL.GetProductIDFromName(BookName);

                    transactionDetail.book_id = b.id;
                    transactionDetail.rate = decimal.Parse(transactionDT.Rows[i][1].ToString());
                    transactionDetail.qty = decimal.Parse(transactionDT.Rows[i][2].ToString());
                    transactionDetail.total = Math.Round(decimal.Parse(transactionDT.Rows[i][3].ToString()), 2);
                    transactionDetail.dealer_customer_id = dc.id;
                    transactionDetail.added_date = DateTime.Now;
                    transactionDetail.added_by = u.id;

                    string transactionType = labelTop.Text;

                    bool x = false;
                    if (transactionType == "Purchase")
                    {
                        if(transaction.dealer_customer_id != 0)
                            x = bDAL.IncreaseProduct(transactionDetail.book_id, transactionDetail.qty);
                    }
                    else if (transactionType == "Sales")
                    {
                        x = bDAL.DecreaseProduct(transactionDetail.book_id, transactionDetail.qty);
                    }

                    bool y = tdDAL.InsertTransactionDetail(transactionDetail);
                    success = w && x && y;
                }
               if (success == true)
                {
                    //Transaction Complete
                    scope.Complete();

                    MessageBox.Show("Transaction Completed Sucessfully!!");

                    dataGridViewAddedBooks.DataSource = null;
                    dataGridViewAddedBooks.Rows.Clear();

                    textBoxSearch.Text = "";
                    textBoxName.Text = "";
                    textBoxEmail.Text = "";
                    textBoxContact.Text = "";
                    textBoxAddress.Text = "";
                    textBoxSearchBook.Text = "";
                    textBoxBookName.Text = "";
                    textBoxInventory.Text = "0";
                    textBoxCost.Text = "0";
                    textBoxQty.Text = "0";
                    textBoxSubTotal.Text = "0";
                    textBoxDiscount.Text = "0";
                    textBoxVat.Text = "0";
                    textBoxGrandTotal.Text = "0";
                    textBoxPaidAmount.Text = "0";
                    textBoxReturnAmount.Text = "0";
                }
                else
                {
                    MessageBox.Show("Transaction Failed!!");
                }
            }
        }
    }
}

