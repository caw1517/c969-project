using System.Configuration;
using C969_Project.Database;
using MySql.Data.MySqlClient;

namespace C969_Project
{
    public partial class MainForm : Form
    {
        private string connectionString;
        private List<CustomerDisplay> _customers;

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
    }
}
