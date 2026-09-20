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
            ConfigureAppointmentColumns();
            addAppointmentButton.Click += addAppointmentButton_Click;
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

        private void addAppointmentButton_Click(object? sender, EventArgs e)
        {
            using var appointmentForm = new AppointmentForm();

            if (appointmentForm.ShowDialog(this) == DialogResult.OK)
            {
                LoadAppointments(afterSave: true);
            }
        }

        private void LoadAppointments(bool afterSave = false)
        {
            try
            {
                _appointments = DatabaseManager.GetAppointments();
                appointmentsDataTable.AutoGenerateColumns = false;
                appointmentsDataTable.DataSource = _appointments;
                appointmentsDataTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                appointmentTimeZoneLabel.Text =
                    $"Time zone: {TimeZoneInfo.Local.DisplayName}";

                if (_appointments.Count == 0)
                {
                    MessageBox.Show(
                        this,
                        "No appointments found.",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                var message = afterSave
                    ? "The appointment was saved, but the list could not be refreshed. " +
                      "Reopen the application to reload the list before making further changes."
                    : "Appointments could not be loaded. " +
                      "Check your database connection and reopen the application to try again.";

                var title = afterSave
                    ? "Appointment Saved — Refresh Failed"
                    : "Load Appointments Failed";

                MessageBox.Show(
                    this,
                    message,
                    title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        
        private void ConfigureAppointmentColumns()
        {
            appointmentsDataTable.AutoGenerateColumns = false;
            appointmentsDataTable.Columns.Clear();

            appointmentsDataTable.Columns.AddRange(
                new DataGridViewTextBoxColumn
                {
                    Name = "appointmentCustomer",
                    HeaderText = "Customer",
                    DataPropertyName = nameof(AppointmentDisplay.CustomerName)
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "appointmentUser",
                    HeaderText = "User",
                    DataPropertyName = nameof(AppointmentDisplay.UserName)
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "appointmentType",
                    HeaderText = "Type",
                    DataPropertyName = nameof(AppointmentDisplay.Type)
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "appointmentTitle",
                    HeaderText = "Title",
                    DataPropertyName = nameof(AppointmentDisplay.Title)
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "appointmentStart",
                    HeaderText = "Start",
                    DataPropertyName = nameof(AppointmentDisplay.Start)
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "appointmentEnd",
                    HeaderText = "End",
                    DataPropertyName = nameof(AppointmentDisplay.End)
                });
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

        private void editAppointmentButton_Click(object sender, EventArgs e)
        {
            if (appointmentsDataTable.SelectedRows.Count == 0 ||
                appointmentsDataTable.SelectedRows[0].DataBoundItem is not AppointmentDisplay selectedAppointment)
            {
                MessageBox.Show(this,
                    "Select an appointment to edit.",
                    "Select Appointment",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                return;
            }
            
            using var appointmentForm = new AppointmentForm(selectedAppointment);

            if (appointmentForm.ShowDialog(this) == DialogResult.OK)
            {
                LoadAppointments(afterSave: true);
            }
        }
    }
}