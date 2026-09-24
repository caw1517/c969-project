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
        private bool _appointmentDataAvailable;
        private bool _calendarDayMode;
        private readonly MonthCalendar appointmentCalendar = new();
        private readonly DataGridView calendarDataTable = new();
        private readonly Label calendarRangeLabel = new();
        private readonly Label calendarTimeZoneLabel = new();
        private readonly Label calendarStatusLabel = new();
        private readonly Button showWholeMonthButton = new();
        private readonly DataGridView typesByMonthDataTable = new();
        private readonly Label typesByMonthStatusLabel = new();
        private readonly DataGridView userSchedulesDataTable = new();
        private readonly Label userSchedulesStatusLabel = new();
        private readonly Label userSchedulesTimeZoneLabel = new();
        private readonly DataGridView appointmentsByCustomerDataTable = new();
        private readonly Label appointmentsByCustomerStatusLabel = new();

        public MainForm()
        {
            InitializeComponent();
            ConfigureAppointmentColumns();
            ConfigureCalendarLayout();
            ConfigureCalendarBehavior();
            ConfigureReportsLayout();

            addAppointmentButton.Click += addAppointmentButton_Click;
            appointmentsDataTable.CellFormatting += appointmentsDataTable_CellFormatting;
        }

        private void RefreshReports()
        {
            RefreshTypesByMonthReport();
            RefreshUserSchedulesReport();
            RefreshAppointmentsByCustomerReport();
        }

        private void RefreshAppointmentsByCustomerReport()
        {
            if (!_appointmentDataAvailable || _appointments is null)
            {
                appointmentsByCustomerDataTable.DataSource =
                    new List<CustomerAppointmentCountRow>();
                appointmentsByCustomerStatusLabel.Text =
                    "Appointment data unavailable.";
                return;
            }

            var rows = _appointments
                .GroupBy(appointment => appointment.CustomerId)
                .Select(group => new CustomerAppointmentCountRow
                {
                    CustomerId = group.Key,
                    CustomerName = group.First().CustomerName,
                    Count = group.Count()
                })
                .OrderBy(row => row.CustomerName)
                .ThenBy(row => row.CustomerId)
                .ToList();

            appointmentsByCustomerDataTable.DataSource = rows;
            appointmentsByCustomerDataTable.ClearSelection();
            appointmentsByCustomerDataTable.CurrentCell = null;

            appointmentsByCustomerStatusLabel.Text = rows.Count == 0
                ? "No appointments found."
                : $"Appointment counts for {rows.Count} customer(s).";
        }

        private void RefreshUserSchedulesReport()
        {
            userSchedulesTimeZoneLabel.Text =
                $"Time zone: {TimeZoneInfo.Local.DisplayName}";

            if (!_appointmentDataAvailable || _appointments is null)
            {
                userSchedulesDataTable.DataSource =
                    new List<AppointmentDisplay>();
                userSchedulesStatusLabel.Text = "Appointment data unavailable.";
                return;
            }

            var rows = _appointments
                .OrderBy(appointment => appointment.UserName)
                .ThenBy(appointment => appointment.UserId)
                .ThenBy(appointment => appointment.Start)
                .ThenBy(appointment => appointment.AppointmentId)
                .ToList();

            userSchedulesDataTable.DataSource = rows;
            userSchedulesDataTable.ClearSelection();
            userSchedulesDataTable.CurrentCell = null;

            userSchedulesStatusLabel.Text = rows.Count == 0
                ? "No appointments found."
                : $"{rows.Count} appointment(s) across all users.";
        }

        private void RefreshTypesByMonthReport()
        {
            if (!_appointmentDataAvailable || _appointments is null)
            {
                typesByMonthDataTable.DataSource =
                    new List<AppointmentTypeCountRow>();
                typesByMonthStatusLabel.Text = "Appointment data unavailable.";
                return;
            }

            var rows = _appointments
                .GroupBy(appointment =>
                {
                    var localStart = TimeHelper.ToLocal(appointment.Start);

                    return new
                    {
                        Year = localStart.Year,
                        Month = localStart.Month,
                        appointment.Type
                    };
                })
                .Select(group => new AppointmentTypeCountRow
                {
                    Year = group.Key.Year,
                    Month = group.Key.Month,
                    Type = group.Key.Type,
                    Count = group.Count()
                })
                .OrderBy(row => row.Year)
                .ThenBy(row => row.Month)
                .ThenBy(row => row.Type)
                .ToList();

            typesByMonthDataTable.DataSource = rows;
            typesByMonthDataTable.ClearSelection();
            typesByMonthDataTable.CurrentCell = null;

            typesByMonthStatusLabel.Text = rows.Count == 0
                ? "No appointments found."
                : $"Appointment counts by local start month. " +
                  $"Time zone: {TimeZoneInfo.Local.DisplayName}";
        }

        private void ConfigureReportsLayout()
        {
            reportsPage.Padding = new Padding(8);

            var reportTabs = new TabControl
            {
                Name = "reportTabs",
                Dock = DockStyle.Fill
            };

            var typesByMonthPage = new TabPage("Types by Month")
            {
                Name = "typesByMonthPage",
                Padding = new Padding(8),
                UseVisualStyleBackColor = true
            };

            var userSchedulesPage = new TabPage("User Schedules")
            {
                Name = "userSchedulesPage",
                UseVisualStyleBackColor = true
            };

            ConfigureUserSchedulesLayout(userSchedulesPage);

            var appointmentsByCustomerPage =
                new TabPage("Appointments by Customer")
                {
                    Name = "appointmentsByCustomerPage",
                    UseVisualStyleBackColor = true
                };

            ConfigureAppointmentsByCustomerLayout(appointmentsByCustomerPage);

            var layout = new TableLayoutPanel
            {
                Name = "typesByMonthLayout",
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                Margin = new Padding(0)
            };

            layout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(
                new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F));

            typesByMonthStatusLabel.Name = "typesByMonthStatusLabel";
            typesByMonthStatusLabel.AutoSize = true;
            typesByMonthStatusLabel.Text = "Appointment data unavailable.";
            typesByMonthStatusLabel.Margin = new Padding(0, 0, 0, 8);

            typesByMonthDataTable.Name = "typesByMonthDataTable";
            typesByMonthDataTable.Dock = DockStyle.Fill;
            typesByMonthDataTable.Margin = new Padding(0);
            typesByMonthDataTable.ReadOnly = true;
            typesByMonthDataTable.AutoGenerateColumns = false;
            typesByMonthDataTable.AllowUserToAddRows = false;
            typesByMonthDataTable.AllowUserToDeleteRows = false;
            typesByMonthDataTable.AllowUserToResizeRows = false;
            typesByMonthDataTable.RowHeadersVisible = false;
            typesByMonthDataTable.MultiSelect = false;
            typesByMonthDataTable.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            typesByMonthDataTable.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            typesByMonthDataTable.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            typesByMonthDataTable.BackgroundColor = SystemColors.Window;

            var columns = new[]
            {
                (Header: "Year", Property: nameof(AppointmentTypeCountRow.Year)),
                (Header: "Month", Property: nameof(AppointmentTypeCountRow.Month)),
                (Header: "Type", Property: nameof(AppointmentTypeCountRow.Type)),
                (Header: "Count", Property: nameof(AppointmentTypeCountRow.Count))
            };

            foreach (var column in columns)
            {
                typesByMonthDataTable.Columns.Add(
                    new DataGridViewTextBoxColumn
                    {
                        Name = $"typesByMonth{column.Header}",
                        HeaderText = column.Header,
                        DataPropertyName = column.Property,
                        SortMode = DataGridViewColumnSortMode.NotSortable
                    });
            }

            layout.Controls.Add(typesByMonthStatusLabel, 0, 0);
            layout.Controls.Add(typesByMonthDataTable, 0, 1);
            typesByMonthPage.Controls.Add(layout);

            reportTabs.TabPages.Add(typesByMonthPage);
            reportTabs.TabPages.Add(userSchedulesPage);
            reportTabs.TabPages.Add(appointmentsByCustomerPage);
            reportsPage.Controls.Add(reportTabs);
        }

        private void ConfigureAppointmentsByCustomerLayout(TabPage page)
        {
            page.Padding = new Padding(8);

            var layout = new TableLayoutPanel
            {
                Name = "appointmentsByCustomerLayout",
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                Margin = new Padding(0)
            };

            layout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F));

            appointmentsByCustomerStatusLabel.Name =
                "appointmentsByCustomerStatusLabel";
            appointmentsByCustomerStatusLabel.AutoSize = true;
            appointmentsByCustomerStatusLabel.Text =
                "Appointment data unavailable.";
            appointmentsByCustomerStatusLabel.Margin = new Padding(0, 0, 0, 8);

            appointmentsByCustomerDataTable.Name =
                "appointmentsByCustomerDataTable";
            appointmentsByCustomerDataTable.Dock = DockStyle.Fill;
            appointmentsByCustomerDataTable.Margin = new Padding(0);
            appointmentsByCustomerDataTable.ReadOnly = true;
            appointmentsByCustomerDataTable.AutoGenerateColumns = false;
            appointmentsByCustomerDataTable.AllowUserToAddRows = false;
            appointmentsByCustomerDataTable.AllowUserToDeleteRows = false;
            appointmentsByCustomerDataTable.AllowUserToResizeRows = false;
            appointmentsByCustomerDataTable.RowHeadersVisible = false;
            appointmentsByCustomerDataTable.MultiSelect = false;
            appointmentsByCustomerDataTable.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            appointmentsByCustomerDataTable.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            appointmentsByCustomerDataTable.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            appointmentsByCustomerDataTable.BackgroundColor = SystemColors.Window;

            appointmentsByCustomerDataTable.Columns.AddRange(
                new DataGridViewTextBoxColumn
                {
                    Name = "appointmentsByCustomerName",
                    HeaderText = "Customer",
                    DataPropertyName = nameof(CustomerAppointmentCountRow.CustomerName),
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                    FillWeight = 200F
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "appointmentsByCustomerCount",
                    HeaderText = "Count",
                    DataPropertyName = nameof(CustomerAppointmentCountRow.Count),
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                    FillWeight = 100F
                });

            layout.Controls.Add(appointmentsByCustomerStatusLabel, 0, 0);
            layout.Controls.Add(appointmentsByCustomerDataTable, 0, 1);
            page.Controls.Add(layout);
        }

        private void ConfigureUserSchedulesLayout(TabPage page)
        {
            page.Padding = new Padding(8);

            var layout = new TableLayoutPanel
            {
                Name = "userSchedulesLayout",
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                Margin = new Padding(0)
            };

            layout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F));

            userSchedulesTimeZoneLabel.Name = "userSchedulesTimeZoneLabel";
            userSchedulesTimeZoneLabel.AutoSize = true;
            userSchedulesTimeZoneLabel.Text =
                $"Time zone: {TimeZoneInfo.Local.DisplayName}";
            userSchedulesTimeZoneLabel.Margin = new Padding(0, 0, 0, 4);

            userSchedulesStatusLabel.Name = "userSchedulesStatusLabel";
            userSchedulesStatusLabel.AutoSize = true;
            userSchedulesStatusLabel.Text = "Appointment data unavailable.";
            userSchedulesStatusLabel.Margin = new Padding(0, 0, 0, 8);

            userSchedulesDataTable.Name = "userSchedulesDataTable";
            userSchedulesDataTable.Dock = DockStyle.Fill;
            userSchedulesDataTable.Margin = new Padding(0);
            userSchedulesDataTable.ReadOnly = true;
            userSchedulesDataTable.AutoGenerateColumns = false;
            userSchedulesDataTable.AllowUserToAddRows = false;
            userSchedulesDataTable.AllowUserToDeleteRows = false;
            userSchedulesDataTable.AllowUserToResizeRows = false;
            userSchedulesDataTable.RowHeadersVisible = false;
            userSchedulesDataTable.MultiSelect = false;
            userSchedulesDataTable.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            userSchedulesDataTable.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            userSchedulesDataTable.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            userSchedulesDataTable.BackgroundColor = SystemColors.Window;
            userSchedulesDataTable.CellFormatting +=
                userSchedulesDataTable_CellFormatting;

            var columns = new[]
            {
                (Header: "User", Property: nameof(AppointmentDisplay.UserName)),
                (Header: "Customer", Property: nameof(AppointmentDisplay.CustomerName)),
                (Header: "Type", Property: nameof(AppointmentDisplay.Type)),
                (Header: "Title", Property: nameof(AppointmentDisplay.Title)),
                (Header: "Start", Property: nameof(AppointmentDisplay.Start)),
                (Header: "End", Property: nameof(AppointmentDisplay.End))
            };

            foreach (var column in columns)
            {
                var isTimestamp =
                    column.Property == nameof(AppointmentDisplay.Start) ||
                    column.Property == nameof(AppointmentDisplay.End);

                userSchedulesDataTable.Columns.Add(
                    new DataGridViewTextBoxColumn
                    {
                        Name = $"userSchedules{column.Header}",
                        HeaderText = column.Header,
                        DataPropertyName = column.Property,
                        SortMode = DataGridViewColumnSortMode.NotSortable,
                        FillWeight = isTimestamp ? 150F : 100F,
                        MinimumWidth = isTimestamp ? 140 : 80
                    });
            }

            layout.Controls.Add(userSchedulesTimeZoneLabel, 0, 0);
            layout.Controls.Add(userSchedulesStatusLabel, 0, 1);
            layout.Controls.Add(userSchedulesDataTable, 0, 2);
            page.Controls.Add(layout);
        }

        private void ConfigureCalendarLayout()
        {
            calendarPage.Text = "Calendar";
            calendarPage.Padding = new Padding(8);

            var calendarLayout = new TableLayoutPanel
            {
                Name = "calendarLayout",
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                Margin = new Padding(0),
                Padding = new Padding(0)
            };

            calendarLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100F));

            calendarLayout.RowStyles.Add(
                new RowStyle(SizeType.AutoSize));

            calendarLayout.RowStyles.Add(
                new RowStyle(SizeType.AutoSize));

            calendarLayout.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F));

            appointmentCalendar.Name = "appointmentCalendar";
            appointmentCalendar.MaxSelectionCount = 1;
            appointmentCalendar.CalendarDimensions = new Size(1, 1);
            appointmentCalendar.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            appointmentCalendar.Margin = new Padding(0, 0, 0, 8);
            appointmentCalendar.SetDate(DateTime.Today);
            appointmentCalendar.TabIndex = 0;

            var calendarInfoPanel = new FlowLayoutPanel
            {
                Name = "calendarInfoPanel",
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Margin = new Padding(0, 0, 0, 8),
                Padding = new Padding(0),
                TabIndex = 1
            };

            calendarRangeLabel.Name = "calendarRangeLabel";
            calendarRangeLabel.AutoSize = true;
            calendarRangeLabel.Text = DateTime.Today.ToString("MMMM yyyy");
            calendarRangeLabel.Margin = new Padding(0, 0, 0, 4);

            calendarTimeZoneLabel.Name = "calendarTimeZoneLabel";
            calendarTimeZoneLabel.AutoSize = true;
            calendarTimeZoneLabel.Text =
                $"Time zone: {TimeZoneInfo.Local.DisplayName}";
            calendarTimeZoneLabel.Margin = new Padding(0, 0, 0, 4);

            calendarStatusLabel.Name = "calendarStatusLabel";
            calendarStatusLabel.AutoSize = true;
            calendarStatusLabel.Text = "Appointment data unavailable.";
            calendarStatusLabel.Margin = new Padding(0);

            showWholeMonthButton.Name = "showWholeMonthButton";
            showWholeMonthButton.Text = "Show whole month";
            showWholeMonthButton.AutoSize = true;
            showWholeMonthButton.Margin = new Padding(0, 0, 0, 8);
            showWholeMonthButton.TabIndex = 0;

            calendarInfoPanel.Controls.Add(showWholeMonthButton);
            calendarInfoPanel.Controls.Add(calendarRangeLabel);
            calendarInfoPanel.Controls.Add(calendarTimeZoneLabel);
            calendarInfoPanel.Controls.Add(calendarStatusLabel);

            calendarDataTable.Name = "calendarDataTable";
            calendarDataTable.Dock = DockStyle.Fill;
            calendarDataTable.Margin = new Padding(0);
            calendarDataTable.ReadOnly = true;
            calendarDataTable.AllowUserToAddRows = false;
            calendarDataTable.AllowUserToDeleteRows = false;
            calendarDataTable.AllowUserToResizeRows = false;
            calendarDataTable.MultiSelect = false;
            calendarDataTable.RowHeadersVisible = false;
            calendarDataTable.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            calendarDataTable.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            calendarDataTable.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            calendarDataTable.AutoGenerateColumns = false;
            calendarDataTable.BackgroundColor = SystemColors.Window;
            calendarDataTable.TabIndex = 2;

            calendarLayout.Controls.Add(appointmentCalendar, 0, 0);
            calendarLayout.Controls.Add(calendarInfoPanel, 0, 1);
            calendarLayout.Controls.Add(calendarDataTable, 0, 2);

            calendarPage.Controls.Add(calendarLayout);
        }

        private void ConfigureCalendarBehavior()
        {
            calendarDataTable.Columns.Clear();

            var columns = new[]
            {
                (Header: "Customer", Property: nameof(AppointmentDisplay.CustomerName)),
                (Header: "User", Property: nameof(AppointmentDisplay.UserName)),
                (Header: "Type", Property: nameof(AppointmentDisplay.Type)),
                (Header: "Title", Property: nameof(AppointmentDisplay.Title)),
                (Header: "Start", Property: nameof(AppointmentDisplay.Start)),
                (Header: "End", Property: nameof(AppointmentDisplay.End))
            };

            foreach (var column in columns)
            {
                var isTimestamp =
                    column.Property == nameof(AppointmentDisplay.Start) ||
                    column.Property == nameof(AppointmentDisplay.End);

                calendarDataTable.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = $"calendar{column.Header}",
                    HeaderText = column.Header,
                    DataPropertyName = column.Property,
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                    FillWeight = isTimestamp ? 150F : 100F,
                    MinimumWidth = isTimestamp ? 140 : 80
                });
            }

            _ = appointmentCalendar.Handle;
            _calendarDayMode = false;

            calendarDataTable.CellFormatting += calendarDataTable_CellFormatting;
            appointmentCalendar.DateChanged += appointmentCalendar_DateChanged;
            appointmentCalendar.DateSelected += appointmentCalendar_DateSelected;
            showWholeMonthButton.Click += showWholeMonthButton_Click;

            RefreshCalendarView();
        }

        private void appointmentCalendar_DateChanged(
            object? sender,
            DateRangeEventArgs e)
        {
            _calendarDayMode = true;
            RefreshCalendarView();
        }

        private void appointmentCalendar_DateSelected(
            object? sender,
            DateRangeEventArgs e)
        {
            _calendarDayMode = true;
            RefreshCalendarView();
        }

        private void showWholeMonthButton_Click(
            object? sender,
            EventArgs e)
        {
            _calendarDayMode = false;
            RefreshCalendarView();
        }

        private void RefreshCalendarView()
        {
            var selectedLocalDate = appointmentCalendar.SelectionStart.Date;

            calendarRangeLabel.Text = _calendarDayMode
                ? $"Day: {selectedLocalDate:MMMM d, yyyy}"
                : $"Month: {selectedLocalDate:MMMM yyyy}";

            calendarTimeZoneLabel.Text =
                $"Time zone: {TimeZoneInfo.Local.DisplayName}";

            if (!_appointmentDataAvailable || _appointments is null)
            {
                calendarDataTable.DataSource = new List<AppointmentDisplay>();
                calendarStatusLabel.Text = "Appointment data unavailable.";
                return;
            }

            var visibleAppointments = _appointments
                .Where(appointment =>
                {
                    var localStartDate =
                        TimeHelper.ToLocal(appointment.Start).Date;

                    return _calendarDayMode
                        ? localStartDate == selectedLocalDate
                        : localStartDate.Year == selectedLocalDate.Year &&
                          localStartDate.Month == selectedLocalDate.Month;
                })
                .OrderBy(appointment => appointment.Start)
                .ThenBy(appointment => appointment.AppointmentId)
                .ToList();

            calendarDataTable.DataSource = visibleAppointments;
            calendarDataTable.ClearSelection();
            calendarDataTable.CurrentCell = null;

            var period = _calendarDayMode ? "day" : "month";

            calendarStatusLabel.Text = visibleAppointments.Count == 0
                ? $"No appointments this {period}."
                : $"{visibleAppointments.Count} appointment(s) this {period}.";
        }

        private void userSchedulesDataTable_CellFormatting(
            object? sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var propertyName =
                userSchedulesDataTable.Columns[e.ColumnIndex].DataPropertyName;

            if (propertyName != nameof(AppointmentDisplay.Start) &&
                propertyName != nameof(AppointmentDisplay.End))
                return;

            if (e.Value is DateTime utcTime)
            {
                e.Value = TimeHelper.ToLocal(utcTime).ToString("g");
                e.FormattingApplied = true;
            }
        }

        private void calendarDataTable_CellFormatting(
            object? sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var propertyName =
                calendarDataTable.Columns[e.ColumnIndex].DataPropertyName;

            if (propertyName != nameof(AppointmentDisplay.Start) &&
                propertyName != nameof(AppointmentDisplay.End))
                return;

            if (e.Value is DateTime utcTime)
            {
                e.Value = TimeHelper.ToLocal(utcTime).ToString("g");
                e.FormattingApplied = true;
            }
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

        private void LoadAppointments(bool afterSave = false, bool afterDelete = false)
        {
            try
            {
                _appointments = DatabaseManager.GetAppointments();
                appointmentsDataTable.AutoGenerateColumns = false;
                appointmentsDataTable.DataSource = _appointments;
                appointmentsDataTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                appointmentTimeZoneLabel.Text =
                    $"Time zone: {TimeZoneInfo.Local.DisplayName}";

                _appointmentDataAvailable = true;
                RefreshCalendarView();
                RefreshReports();

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
                _appointmentDataAvailable = false;
                RefreshCalendarView();
                RefreshReports();

                var message = afterDelete
                    ? "The appointment was deleted, but the list could not be refreshed. " +
                      "Reopen the application to reload the list before making further changes."
                    : afterSave
                        ? "The appointment was saved, but the list could not be refreshed. " +
                          "Reopen the application to reload the list before making further changes."
                        : "Appointments could not be loaded. " +
                          "Check your database connection and reopen the application to try again.";
                var title = afterDelete
                    ? "Appointment Deleted — Refresh Failed"
                    : afterSave
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

        private void deleteAppointmentButton_Click(object sender, EventArgs e)
        {
            if (appointmentsDataTable.SelectedRows.Count == 0 ||
                appointmentsDataTable.SelectedRows[0].DataBoundItem
                    is not AppointmentDisplay selectedAppointment)
            {
                MessageBox.Show(
                    this,
                    "Select an appointment to delete.",
                    "Select Appointment",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var appointmentName = string.IsNullOrWhiteSpace(selectedAppointment.Title)
                ? $"Appointment {selectedAppointment.AppointmentId}"
                : selectedAppointment.Title;

            var confirmation = MessageBox.Show(
                this,
                $"Delete '{appointmentName}' for {selectedAppointment.CustomerName}?",
                "Delete Appointment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirmation != DialogResult.Yes)
                return;

            try
            {
                DatabaseManager.DeleteAppointment(selectedAppointment.AppointmentId);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    this,
                    ex.Message,
                    "Delete Appointment Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            catch (Exception)
            {
                MessageBox.Show(
                    this,
                    "The appointment could not be deleted. " +
                    "Check your database connection and reload the list before trying again.",
                    "Delete Appointment Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            LoadAppointments(afterDelete: true);
        }
    }
}
