using C969_Project.Database;
using C969_Project.Forms;
using MySql.Data.MySqlClient;

namespace C969_Project
{
    public partial class MainForm : Form
    {
        //private string _connectionString;
        private List<CustomerDisplay>? _customers;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            _customers = DatabaseManager.GetCustomers();
            customersDataTable.AutoGenerateColumns = false;
            customersDataTable.DataSource = _customers;
            customersDataTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void editCustomerButton_Click(object sender, EventArgs e)
        {
            if (customersDataTable.CurrentRow == null)
            {
                MessageBox.Show("Please select at least one customer to edit.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (customersDataTable.CurrentRow.DataBoundItem is CustomerDisplay selectedCustomer)
            {
                using var customerForm = new CustomerForm(selectedCustomer);
                if (customerForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        LoadCustomers();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(
                            "The customer was updated, but the list could not be refreshed. " +
                            "Reopen the customer screen to reload it.",
                            "Refresh Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            using var customerForm = new CustomerForm();
            if (customerForm.ShowDialog() == DialogResult.OK)
            {
                LoadCustomers();
            }
        }

        private void deleteCustomerButton_Click(object sender, EventArgs e)
        {
            if (customersDataTable.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one customer to delete.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (customersDataTable.SelectedRows[0].DataBoundItem is not CustomerDisplay selectedCustomer)
            {
                return;
            }

            DialogResult confirmation = MessageBox.Show(
                $"Are you sure you want to delete '{selectedCustomer.CustomerName}'?", "Delete customer",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (confirmation != DialogResult.Yes)
            {
                return;
            }

            try
            {
                DatabaseManager.DeleteCustomer(selectedCustomer.CustomerId, selectedCustomer.AddressId);
            }
            catch (MySqlException ex) when (ex.Number == 1451)
            {
                MessageBox.Show("This customer has appointments. Delete them first.");
                return;
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "The customer was not removed. " +
                    "Check your database connection and try again.",
                    "Delete Customer Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            try
            {
                LoadCustomers();
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "The customer was deleted, but the list could not be refreshed. " +
                    "Reopen the customer screen to reload it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void customersDataTable_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            customersDataTable.ClearSelection();
            customersDataTable.CurrentCell = null;
        }
    }
}