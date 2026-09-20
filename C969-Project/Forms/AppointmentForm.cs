using C969_Project.Database;
using C969_Project.Modules;

namespace C969_Project.Forms;

public partial class AppointmentForm : Form
{
    private readonly int? _appointmentId;
    private readonly int _originalUserId;
    private readonly int? _originalCustomerId;

    public AppointmentForm()
    {
        InitializeComponent();

        Text = "Add Appointment";
        StartPosition = FormStartPosition.CenterParent;
        customerComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        titleTextBox.MaxLength = 255;
        urlTextBox.MaxLength = 255;
        startDateTimePicker.Format = DateTimePickerFormat.Custom;
        startDateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm";
        endDateTimePicker.Format = DateTimePickerFormat.Custom;
        endDateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm";

        var now = AtMinutePrecision(DateTime.Now);
        startDateTimePicker.Value = now;
        endDateTimePicker.Value = now.AddHours(1);
        timeZoneLabel.Text = $"Time zone: {TimeZoneInfo.Local.DisplayName}";
        saveButton.DialogResult = DialogResult.None;
        cancelButton.DialogResult = DialogResult.Cancel;
        AcceptButton = saveButton;
        CancelButton = cancelButton;
        Load += AppointmentForm_Load;
        saveButton.Click += SaveButton_Click;
    }

    public AppointmentForm(AppointmentDisplay appointment) : this()
    {
        _appointmentId = appointment.AppointmentId;
        _originalUserId = appointment.UserId;

        Text = "Edit Appointment";
        typeTextBox.Text = appointment.Type;
        titleTextBox.Text = appointment.Title;
        descriptionTextBox.Text = appointment.Description;
        locationTextBox.Text = appointment.Location;
        contactTextBox.Text = appointment.Contact;
        urlTextBox.Text = appointment.Url;
        startDateTimePicker.Value =
            AtMinutePrecision(TimeHelper.ToLocal(appointment.Start));
        endDateTimePicker.Value =
            AtMinutePrecision(TimeHelper.ToLocal(appointment.End));

        _originalCustomerId = appointment.CustomerId;
    }

    private void AppointmentForm_Load(object? sender, EventArgs e)
    {
        try
        {
            var customers = DatabaseManager.GetCustomers();
            customerComboBox.DisplayMember = nameof(CustomerDisplay.CustomerName);
            customerComboBox.ValueMember = nameof(CustomerDisplay.CustomerId);
            customerComboBox.DataSource = customers;
            customerComboBox.SelectedIndex = -1;

            if (_originalCustomerId.HasValue)
                customerComboBox.SelectedValue = _originalCustomerId.Value;

            if (customers.Count == 0)
            {
                saveButton.Enabled = false;
                MessageBox.Show(this, "A customer is required to save an appointment.",
                    "No Customers", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception)
        {
            saveButton.Enabled = false;
            MessageBox.Show(this,
                "Customers could not be loaded. Close this form and try again after checking the database connection.",
                "Load Customers Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void SaveButton_Click(object? sender, EventArgs e)
    {
        TrimInputs();

        if (customerComboBox.SelectedValue is not int customerId)
        {
            ShowValidationError("Select a customer.");
            return;
        }

        if (string.IsNullOrWhiteSpace(typeTextBox.Text))
        {
            ShowValidationError("Enter an appointment type.");
            return;
        }

        if (titleTextBox.Text.Length > 255 || urlTextBox.Text.Length > 255)
        {
            ShowValidationError("Title and URL must each be 255 characters or fewer.");
            return;
        }

        DateTime startUtc;
        DateTime endUtc;

        try
        {
            startUtc = TimeHelper.ToUtc(AtMinutePrecision(startDateTimePicker.Value));
            endUtc = TimeHelper.ToUtc(AtMinutePrecision(endDateTimePicker.Value));
        }
        catch (ArgumentException)
        {
            ShowValidationError(
                "The selected start or end time is not a valid local clock value. Check for a daylight saving time change.");
            return;
        }

        if (endUtc <= startUtc)
        {
            ShowValidationError("End must be after Start.");
            return;
        }

        var startEastern = TimeHelper.ToEastern(startUtc);
        var endEastern = TimeHelper.ToEastern(endUtc);

        if (IsWeekend(startEastern) || IsWeekend(endEastern))
        {
            ShowValidationError("Appointments must start and end Monday through Friday in Eastern Time.");
            return;
        }

        if (startEastern.Date != endEastern.Date ||
            startEastern.TimeOfDay < TimeSpan.FromHours(9) ||
            endEastern.TimeOfDay > TimeSpan.FromHours(17))
        {
            ShowValidationError(
                "Appointments must start and end on the same date between 09:00 and 17:00 Eastern Time.");
            return;
        }

        var appointment = new Appointment
        {
            AppointmentId = _appointmentId ?? 0,
            CustomerId = customerId,
            UserId = _appointmentId.HasValue
                ? _originalUserId
                : Session.CurrentUserId,
            Type = typeTextBox.Text,
            Title = titleTextBox.Text,
            Description = descriptionTextBox.Text,
            Location = locationTextBox.Text,
            Contact = contactTextBox.Text,
            Url = urlTextBox.Text,
            Start = startUtc,
            End = endUtc
        };

        if (_appointmentId.HasValue)
        {
            try
            {
                if (HasConflict(appointment))
                    return;

                DatabaseManager.EditAppointment(appointment);
            }
            catch (Exception)
            {
                MessageBox.Show(this,
                    "Unable to complete the appointment edit. " +
                    "Check the database connection and whether the appointment still exists. " +
                    "If the connection was interrupted during saving, " +
                    "check the appointment list before retrying.",
                    "Edit Appointment Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        else
        {
            try
            {
                if (HasConflict(appointment))
                    return;

                DatabaseManager.AddAppointment(appointment);
            }
            catch (Exception)
            {
                MessageBox.Show(this,
                    "Unable to complete the appointment save. Check the database connection. " +
                    "If the connection was interrupted during saving, " +
                    "check the appointment list before retrying.",
                    "Add Appointment Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        DialogResult = DialogResult.OK;
    }

    private void TrimInputs()
    {
        typeTextBox.Text = typeTextBox.Text.Trim();
        titleTextBox.Text = titleTextBox.Text.Trim();
        descriptionTextBox.Text = descriptionTextBox.Text.Trim();
        locationTextBox.Text = locationTextBox.Text.Trim();
        contactTextBox.Text = contactTextBox.Text.Trim();
        urlTextBox.Text = urlTextBox.Text.Trim();
    }

    private static DateTime AtMinutePrecision(DateTime value)
    {
        return new DateTime(value.Year, value.Month, value.Day,
            value.Hour, value.Minute, 0, DateTimeKind.Unspecified);
    }

    private static bool IsWeekend(DateTime value)
    {
        return value.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;
    }

    private void ShowValidationError(string message)
    {
        MessageBox.Show(this, message, "Check Appointment",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private bool HasConflict(Appointment appointment)
    {
        var conflict = DatabaseManager.FindConflict(
            appointment.Start, appointment.End, _appointmentId);

        if (conflict == null)
            return false;

        var conflictName = string.IsNullOrWhiteSpace(conflict.Title)
            ? $"Appointment {conflict.AppointmentId}"
            : conflict.Title;
        var conflictStart = TimeHelper.ToLocal(conflict.Start);
        var conflictEnd = TimeHelper.ToLocal(conflict.End);

        ShowValidationError(
            $"This time overlaps with \"{conflictName}\" " +
            $"({conflictStart:g} to {conflictEnd:g}, local time).");

        return true;
    }
}