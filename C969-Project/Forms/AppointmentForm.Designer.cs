namespace C969_Project.Forms;

partial class AppointmentForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            components?.Dispose();

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        customerComboBox = new ComboBox();
        typeTextBox = new TextBox();
        titleTextBox = new TextBox();
        descriptionTextBox = new TextBox();
        locationTextBox = new TextBox();
        contactTextBox = new TextBox();
        urlTextBox = new TextBox();
        startDateTimePicker = new DateTimePicker();
        endDateTimePicker = new DateTimePicker();
        timeZoneLabel = new Label();
        saveButton = new Button();
        cancelButton = new Button();
        formLayout = new TableLayoutPanel();
        buttonLayout = new FlowLayoutPanel();
        customerLabel = new Label();
        typeLabel = new Label();
        titleLabel = new Label();
        descriptionLabel = new Label();
        locationLabel = new Label();
        contactLabel = new Label();
        urlLabel = new Label();
        startLabel = new Label();
        endLabel = new Label();
        formLayout.SuspendLayout();
        buttonLayout.SuspendLayout();
        SuspendLayout();

        formLayout.AutoScroll = true;
        formLayout.ColumnCount = 2;
        formLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125F));
        formLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        formLayout.Dock = DockStyle.Fill;
        formLayout.Padding = new Padding(16);
        formLayout.RowCount = 11;
        formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
        formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        formLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));

        customerLabel.Text = "Customer *";
        customerLabel.AutoSize = true;
        typeLabel.Text = "Type *";
        typeLabel.AutoSize = true;
        titleLabel.Text = "Title";
        titleLabel.AutoSize = true;
        descriptionLabel.Text = "Description";
        descriptionLabel.AutoSize = true;
        locationLabel.Text = "Location";
        locationLabel.AutoSize = true;
        contactLabel.Text = "Contact";
        contactLabel.AutoSize = true;
        urlLabel.Text = "URL";
        urlLabel.AutoSize = true;
        startLabel.Text = "Start *";
        startLabel.AutoSize = true;
        endLabel.Text = "End *";
        endLabel.AutoSize = true;

        customerComboBox.Name = "customerComboBox";
        customerComboBox.Dock = DockStyle.Top;
        customerComboBox.TabIndex = 0;
        typeTextBox.Name = "typeTextBox";
        typeTextBox.Dock = DockStyle.Top;
        typeTextBox.TabIndex = 1;
        titleTextBox.Name = "titleTextBox";
        titleTextBox.Dock = DockStyle.Top;
        titleTextBox.TabIndex = 2;
        descriptionTextBox.Name = "descriptionTextBox";
        descriptionTextBox.Dock = DockStyle.Fill;
        descriptionTextBox.Multiline = true;
        descriptionTextBox.ScrollBars = ScrollBars.Vertical;
        descriptionTextBox.TabIndex = 3;
        locationTextBox.Name = "locationTextBox";
        locationTextBox.Dock = DockStyle.Top;
        locationTextBox.TabIndex = 4;
        contactTextBox.Name = "contactTextBox";
        contactTextBox.Dock = DockStyle.Top;
        contactTextBox.TabIndex = 5;
        urlTextBox.Name = "urlTextBox";
        urlTextBox.Dock = DockStyle.Top;
        urlTextBox.TabIndex = 6;
        startDateTimePicker.Name = "startDateTimePicker";
        startDateTimePicker.Dock = DockStyle.Top;
        startDateTimePicker.TabIndex = 7;
        endDateTimePicker.Name = "endDateTimePicker";
        endDateTimePicker.Dock = DockStyle.Top;
        endDateTimePicker.TabIndex = 8;
        timeZoneLabel.Name = "timeZoneLabel";
        timeZoneLabel.AutoSize = true;
        timeZoneLabel.Dock = DockStyle.Fill;
        timeZoneLabel.Padding = new Padding(0, 8, 0, 8);

        saveButton.Name = "saveButton";
        saveButton.Text = "Save";
        saveButton.Size = new Size(90, 32);
        saveButton.TabIndex = 0;
        cancelButton.Name = "cancelButton";
        cancelButton.Text = "Cancel";
        cancelButton.Size = new Size(90, 32);
        cancelButton.TabIndex = 1;
        buttonLayout.Dock = DockStyle.Fill;
        buttonLayout.FlowDirection = FlowDirection.RightToLeft;
        buttonLayout.TabIndex = 9;
        buttonLayout.Controls.Add(cancelButton);
        buttonLayout.Controls.Add(saveButton);

        formLayout.Controls.Add(customerLabel, 0, 0);
        formLayout.Controls.Add(customerComboBox, 1, 0);
        formLayout.Controls.Add(typeLabel, 0, 1);
        formLayout.Controls.Add(typeTextBox, 1, 1);
        formLayout.Controls.Add(titleLabel, 0, 2);
        formLayout.Controls.Add(titleTextBox, 1, 2);
        formLayout.Controls.Add(descriptionLabel, 0, 3);
        formLayout.Controls.Add(descriptionTextBox, 1, 3);
        formLayout.Controls.Add(locationLabel, 0, 4);
        formLayout.Controls.Add(locationTextBox, 1, 4);
        formLayout.Controls.Add(contactLabel, 0, 5);
        formLayout.Controls.Add(contactTextBox, 1, 5);
        formLayout.Controls.Add(urlLabel, 0, 6);
        formLayout.Controls.Add(urlTextBox, 1, 6);
        formLayout.Controls.Add(startLabel, 0, 7);
        formLayout.Controls.Add(startDateTimePicker, 1, 7);
        formLayout.Controls.Add(endLabel, 0, 8);
        formLayout.Controls.Add(endDateTimePicker, 1, 8);
        formLayout.Controls.Add(timeZoneLabel, 0, 9);
        formLayout.SetColumnSpan(timeZoneLabel, 2);
        formLayout.Controls.Add(buttonLayout, 0, 10);
        formLayout.SetColumnSpan(buttonLayout, 2);

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(650, 600);
        MinimumSize = new Size(560, 640);
        Controls.Add(formLayout);
        Name = "AppointmentForm";
        Text = "Add Appointment";
        formLayout.ResumeLayout(false);
        formLayout.PerformLayout();
        buttonLayout.ResumeLayout(false);
        ResumeLayout(false);
    }

    private ComboBox customerComboBox;
    private TextBox typeTextBox;
    private TextBox titleTextBox;
    private TextBox descriptionTextBox;
    private TextBox locationTextBox;
    private TextBox contactTextBox;
    private TextBox urlTextBox;
    private DateTimePicker startDateTimePicker;
    private DateTimePicker endDateTimePicker;
    private Label timeZoneLabel;
    private Button saveButton;
    private Button cancelButton;
    private TableLayoutPanel formLayout;
    private FlowLayoutPanel buttonLayout;
    private Label customerLabel;
    private Label typeLabel;
    private Label titleLabel;
    private Label descriptionLabel;
    private Label locationLabel;
    private Label contactLabel;
    private Label urlLabel;
    private Label startLabel;
    private Label endLabel;
}
