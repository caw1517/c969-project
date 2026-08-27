using C969_Project.Database;
using C969_Project.Forms;

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
                MessageBox.Show(@"Please select at least one customer to edit.");
                return;
            }

            if (customersDataTable.CurrentRow.DataBoundItem is CustomerDisplay selectedCustomer)
            {
                using var customerForm = new CustomerForm(selectedCustomer);
                customerForm.ShowDialog();
            }
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            using var customerForm = new CustomerForm();
            customerForm.ShowDialog();
        }
    }
}
