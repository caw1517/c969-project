using C969_Project.Database;
using C969_Project.Forms;
using MySql.Data.MySqlClient;
using C969_Project.Modules;

namespace C969_Project
{
    public partial class MainForm : Form
    {
        //private string _connectionString;
        private List<CustomerDisplay>? _customers;
        private List<AppointmentDisplay>? _appointments;

        public MainForm()
        {
            InitializeComponent();
            appointmentsDataTable.CellFormatting += appointmentsDataTable_CellFormatting;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            LoadAppointments();
        }

        private void LoadCustomers()
        {
            _customers = DatabaseManager.GetCustomers();
            customersDataTable.AutoGenerateColumns = false;
            customersDataTable.DataSource = _customers;
            customersDataTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadAppointments()
        {
            try
            {
                _appointments = DatabaseManager.GetAppointments();
                appointmentsDataTable.AutoGenerateColumns = false;
                appointmentsDataTable.DataSource = _appointments;
                appointmentsDataTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (_appointments.Count == 0)
                {
                    MessageBox.Show(
                        "No appointments found.",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Appointments could not be loaded. Check your database connection and reopen the application to try again.",
                    "Load Appointments Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
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

        private void appointmentsDataTable_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            appointmentsDataTable.ClearSelection();
            appointmentsDataTable.CurrentCell = null;
        }

        private void appointmentsDataTable_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var propertyName = appointmentsDataTable.Columns[e.ColumnIndex].DataPropertyName;


            if (propertyName != nameof(Appointment.Start) &&
                propertyName != nameof(Appointment.End))
                return;

            if (e.Value is DateTime utcTime)
            {
                e.Value = TimeHelper.ToLocal(utcTime).ToString("g");
                e.FormattingApplied = true;
            }
        }
    }
}