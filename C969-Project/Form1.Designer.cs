namespace C969_Project
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Main_MenuStripPanel = new System.Windows.Forms.Panel();
            Main_MenuStrip = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            Main_TabControlPanel = new System.Windows.Forms.Panel();
            Main_TabControl = new System.Windows.Forms.TabControl();
            customersPage = new System.Windows.Forms.TabPage();
            customersDataTable = new System.Windows.Forms.DataGridView();
            customerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            customerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            customerAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            customerCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            customerCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            customersButtonLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            addCustomerButton = new System.Windows.Forms.Button();
            editCustomerButton = new System.Windows.Forms.Button();
            deleteCustomerButton = new System.Windows.Forms.Button();
            maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            appointmentsPage = new System.Windows.Forms.TabPage();
            appointmentsDataTable = new System.Windows.Forms.DataGridView();
            appointmentCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            appointmentUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            appointmentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            appointmentTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            appointmentStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            appointmentEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            appointmentButtonLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            addAppointmentButton = new System.Windows.Forms.Button();
            editAppointmentButton = new System.Windows.Forms.Button();
            deleteAppointmentButton = new System.Windows.Forms.Button();
            appointmentSelectionLabel = new System.Windows.Forms.Label();
            appointmentTimeZoneLabel = new System.Windows.Forms.Label();
            calendarPage = new System.Windows.Forms.TabPage();
            reportsPage = new System.Windows.Forms.TabPage();
            loginHistoryPage = new System.Windows.Forms.TabPage();
            Main_MenuStripPanel.SuspendLayout();
            Main_MenuStrip.SuspendLayout();
            Main_TabControlPanel.SuspendLayout();
            Main_TabControl.SuspendLayout();
            customersPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)customersDataTable).BeginInit();
            customersButtonLayoutPanel.SuspendLayout();
            appointmentsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)appointmentsDataTable).BeginInit();
            appointmentButtonLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // Main_MenuStripPanel
            // 
            Main_MenuStripPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Main_MenuStripPanel.Controls.Add(Main_MenuStrip);
            Main_MenuStripPanel.Dock = System.Windows.Forms.DockStyle.Top;
            Main_MenuStripPanel.Location = new System.Drawing.Point(0, 0);
            Main_MenuStripPanel.Margin = new System.Windows.Forms.Padding(5);
            Main_MenuStripPanel.Name = "Main_MenuStripPanel";
            Main_MenuStripPanel.Size = new System.Drawing.Size(1424, 26);
            Main_MenuStripPanel.TabIndex = 0;
            // 
            // Main_MenuStrip
            // 
            Main_MenuStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            Main_MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, aboutToolStripMenuItem });
            Main_MenuStrip.Location = new System.Drawing.Point(0, 0);
            Main_MenuStrip.Name = "Main_MenuStrip";
            Main_MenuStrip.Size = new System.Drawing.Size(1422, 24);
            Main_MenuStrip.TabIndex = 0;
            Main_MenuStrip.Text = "Main Menu Strip";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { signOutToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // signOutToolStripMenuItem
            // 
            signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            signOutToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            signOutToolStripMenuItem.Text = "Sign Out";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            exitToolStripMenuItem.Text = "Exit";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { aboutToolStripMenuItem1 });
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            aboutToolStripMenuItem.Text = "About";
            // 
            // aboutToolStripMenuItem1
            // 
            aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            aboutToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            aboutToolStripMenuItem1.Text = "About";
            // 
            // Main_TabControlPanel
            // 
            Main_TabControlPanel.BackColor = System.Drawing.SystemColors.Control;
            Main_TabControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Main_TabControlPanel.Controls.Add(Main_TabControl);
            Main_TabControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            Main_TabControlPanel.Location = new System.Drawing.Point(0, 26);
            Main_TabControlPanel.Margin = new System.Windows.Forms.Padding(5);
            Main_TabControlPanel.Name = "Main_TabControlPanel";
            Main_TabControlPanel.Padding = new System.Windows.Forms.Padding(10);
            Main_TabControlPanel.Size = new System.Drawing.Size(1424, 835);
            Main_TabControlPanel.TabIndex = 1;
            // 
            // Main_TabControl
            // 
            Main_TabControl.Controls.Add(customersPage);
            Main_TabControl.Controls.Add(appointmentsPage);
            Main_TabControl.Controls.Add(calendarPage);
            Main_TabControl.Controls.Add(reportsPage);
            Main_TabControl.Controls.Add(loginHistoryPage);
            Main_TabControl.Cursor = System.Windows.Forms.Cursors.Cross;
            Main_TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            Main_TabControl.ItemSize = new System.Drawing.Size(100, 30);
            Main_TabControl.Location = new System.Drawing.Point(10, 10);
            Main_TabControl.Name = "Main_TabControl";
            Main_TabControl.SelectedIndex = 0;
            Main_TabControl.Size = new System.Drawing.Size(1402, 813);
            Main_TabControl.TabIndex = 0;
            // 
            // customersPage
            // 
            customersPage.BackColor = System.Drawing.SystemColors.Control;
            customersPage.Controls.Add(customersDataTable);
            customersPage.Controls.Add(customersButtonLayoutPanel);
            customersPage.Location = new System.Drawing.Point(4, 34);
            customersPage.Name = "customersPage";
            customersPage.Padding = new System.Windows.Forms.Padding(3);
            customersPage.Size = new System.Drawing.Size(1394, 775);
            customersPage.TabIndex = 0;
            customersPage.Text = "Customers";
            // 
            // customersDataTable
            // 
            customersDataTable.AllowUserToAddRows = false;
            customersDataTable.AllowUserToDeleteRows = false;
            customersDataTable.AllowUserToResizeRows = false;
            customersDataTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            customersDataTable.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            customersDataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            customersDataTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { customerId, customerName, customerAddress, customerCity, customerCountry, active });
            customersDataTable.Dock = System.Windows.Forms.DockStyle.Fill;
            customersDataTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            customersDataTable.Location = new System.Drawing.Point(3, 53);
            customersDataTable.MultiSelect = false;
            customersDataTable.Name = "customersDataTable";
            customersDataTable.RowHeadersVisible = false;
            customersDataTable.Size = new System.Drawing.Size(1388, 719);
            customersDataTable.TabIndex = 1;
            customersDataTable.DataBindingComplete += customersDataTable_DataBindingComplete;
            // 
            // customerId
            // 
            customerId.DataPropertyName = "CustomerId";
            customerId.FillWeight = 10F;
            customerId.HeaderText = "ID";
            customerId.Name = "customerId";
            // 
            // customerName
            // 
            customerName.DataPropertyName = "CustomerName";
            customerName.FillWeight = 25F;
            customerName.HeaderText = "Name";
            customerName.Name = "customerName";
            // 
            // customerAddress
            // 
            customerAddress.DataPropertyName = "FullAddress";
            customerAddress.FillWeight = 35F;
            customerAddress.HeaderText = "Address";
            customerAddress.Name = "customerAddress";
            // 
            // customerCity
            // 
            customerCity.DataPropertyName = "City";
            customerCity.FillWeight = 20F;
            customerCity.HeaderText = "City";
            customerCity.Name = "customerCity";
            // 
            // customerCountry
            // 
            customerCountry.DataPropertyName = "Country";
            customerCountry.FillWeight = 15F;
            customerCountry.HeaderText = "Country";
            customerCountry.Name = "customerCountry";
            // 
            // active
            // 
            active.DataPropertyName = "Active";
            active.FillWeight = 10F;
            active.HeaderText = "Active";
            active.Name = "active";
            // 
            // customersButtonLayoutPanel
            // 
            customersButtonLayoutPanel.AutoScroll = true;
            customersButtonLayoutPanel.Controls.Add(addCustomerButton);
            customersButtonLayoutPanel.Controls.Add(editCustomerButton);
            customersButtonLayoutPanel.Controls.Add(deleteCustomerButton);
            customersButtonLayoutPanel.Controls.Add(maskedTextBox1);
            customersButtonLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            customersButtonLayoutPanel.Location = new System.Drawing.Point(3, 3);
            customersButtonLayoutPanel.Name = "customersButtonLayoutPanel";
            customersButtonLayoutPanel.Size = new System.Drawing.Size(1388, 50);
            customersButtonLayoutPanel.TabIndex = 0;
            // 
            // addCustomerButton
            // 
            addCustomerButton.Dock = System.Windows.Forms.DockStyle.Top;
            addCustomerButton.Location = new System.Drawing.Point(3, 7);
            addCustomerButton.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            addCustomerButton.Name = "addCustomerButton";
            addCustomerButton.Size = new System.Drawing.Size(88, 35);
            addCustomerButton.TabIndex = 0;
            addCustomerButton.Text = "Add";
            addCustomerButton.UseVisualStyleBackColor = true;
            addCustomerButton.Click += addCustomerButton_Click;
            // 
            // editCustomerButton
            // 
            editCustomerButton.Location = new System.Drawing.Point(97, 7);
            editCustomerButton.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            editCustomerButton.Name = "editCustomerButton";
            editCustomerButton.Size = new System.Drawing.Size(88, 35);
            editCustomerButton.TabIndex = 1;
            editCustomerButton.Text = "Edit";
            editCustomerButton.UseVisualStyleBackColor = true;
            editCustomerButton.Click += editCustomerButton_Click;
            // 
            // deleteCustomerButton
            // 
            deleteCustomerButton.Location = new System.Drawing.Point(191, 7);
            deleteCustomerButton.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            deleteCustomerButton.Name = "deleteCustomerButton";
            deleteCustomerButton.Size = new System.Drawing.Size(88, 35);
            deleteCustomerButton.TabIndex = 2;
            deleteCustomerButton.Text = "Delete";
            deleteCustomerButton.UseVisualStyleBackColor = true;
            deleteCustomerButton.Click += deleteCustomerButton_Click;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.BackColor = System.Drawing.SystemColors.Control;
            maskedTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            maskedTextBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            maskedTextBox1.Location = new System.Drawing.Point(285, 16);
            maskedTextBox1.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new System.Drawing.Size(315, 16);
            maskedTextBox1.TabIndex = 3;
            maskedTextBox1.Text = "Select a row, then Edit or Delete.  Double-click a row to edit";
            // 
            // appointmentsPage
            // 
            appointmentsPage.BackColor = System.Drawing.SystemColors.Control;
            appointmentsPage.Controls.Add(appointmentsDataTable);
            appointmentsPage.Controls.Add(appointmentButtonLayoutPanel);
            appointmentsPage.Location = new System.Drawing.Point(4, 34);
            appointmentsPage.Name = "appointmentsPage";
            appointmentsPage.Padding = new System.Windows.Forms.Padding(3);
            appointmentsPage.Size = new System.Drawing.Size(1394, 775);
            appointmentsPage.TabIndex = 1;
            appointmentsPage.Text = "Appointments";
            // 
            // appointmentsDataTable
            // 
            appointmentsDataTable.AllowUserToAddRows = false;
            appointmentCustomer.Name = "appointmentCustomer";
            appointmentCustomer.HeaderText = "Customer";
            appointmentCustomer.DataPropertyName = "CustomerName";

            appointmentUser.Name = "appointmentUser";
            appointmentUser.HeaderText = "User";
            appointmentUser.DataPropertyName = "UserName";

            appointmentType.Name = "appointmentType";
            appointmentType.HeaderText = "Type";
            appointmentType.DataPropertyName = "Type";

            appointmentTitle.Name = "appointmentTitle";
            appointmentTitle.HeaderText = "Title";
            appointmentTitle.DataPropertyName = "Title";

            appointmentStart.Name = "appointmentStart";
            appointmentStart.HeaderText = "Start";
            appointmentStart.DataPropertyName = "Start";

            appointmentEnd.Name = "appointmentEnd";
            appointmentEnd.HeaderText = "End";
            appointmentEnd.DataPropertyName = "End";

            appointmentsDataTable.AutoGenerateColumns = false;
            appointmentsDataTable.Columns.AddRange(
                new System.Windows.Forms.DataGridViewColumn[]
                {
                    appointmentCustomer,
                    appointmentUser,
                    appointmentType,
                    appointmentTitle,
                    appointmentStart,
                    appointmentEnd
                });
            appointmentsDataTable.AllowUserToDeleteRows = false;
            appointmentsDataTable.AllowUserToResizeRows = false;
            appointmentsDataTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            appointmentsDataTable.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            appointmentsDataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            appointmentsDataTable.Dock = System.Windows.Forms.DockStyle.Fill;
            appointmentsDataTable.Location = new System.Drawing.Point(3, 53);
            appointmentsDataTable.MultiSelect = false;
            appointmentsDataTable.Name = "appointmentsDataTable";
            appointmentsDataTable.ReadOnly = true;
            appointmentsDataTable.RowHeadersVisible = false;
            appointmentsDataTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            appointmentsDataTable.Size = new System.Drawing.Size(1388, 719);
            appointmentsDataTable.TabIndex = 1;
            appointmentsDataTable.DataBindingComplete += appointmentsDataTable_DataBindingComplete;
            // 
            // appointmentButtonLayoutPanel
            // 
            appointmentButtonLayoutPanel.AutoScroll = true;
            appointmentButtonLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            appointmentButtonLayoutPanel.Controls.Add(addAppointmentButton);
            appointmentButtonLayoutPanel.Controls.Add(editAppointmentButton);
            appointmentButtonLayoutPanel.Controls.Add(deleteAppointmentButton);
            appointmentButtonLayoutPanel.Controls.Add(appointmentSelectionLabel);
            appointmentButtonLayoutPanel.Controls.Add(appointmentTimeZoneLabel);
            appointmentButtonLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            appointmentButtonLayoutPanel.Location = new System.Drawing.Point(3, 3);
            appointmentButtonLayoutPanel.Name = "appointmentButtonLayoutPanel";
            appointmentButtonLayoutPanel.Size = new System.Drawing.Size(1388, 50);
            appointmentButtonLayoutPanel.TabIndex = 0;
            appointmentButtonLayoutPanel.WrapContents = false;
            // 
            // addAppointmentButton
            // 
            addAppointmentButton.Location = new System.Drawing.Point(3, 7);
            addAppointmentButton.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            addAppointmentButton.Name = "addAppointmentButton";
            addAppointmentButton.Size = new System.Drawing.Size(88, 35);
            addAppointmentButton.TabIndex = 0;
            addAppointmentButton.Text = "Add";
            addAppointmentButton.UseVisualStyleBackColor = true;
            // 
            // editAppointmentButton
            // 
            editAppointmentButton.Location = new System.Drawing.Point(97, 7);
            editAppointmentButton.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            editAppointmentButton.Name = "editAppointmentButton";
            editAppointmentButton.Size = new System.Drawing.Size(88, 35);
            editAppointmentButton.TabIndex = 1;
            editAppointmentButton.Text = "Edit";
            editAppointmentButton.UseVisualStyleBackColor = true;
            // 
            // deleteAppointmentButton
            // 
            deleteAppointmentButton.Location = new System.Drawing.Point(191, 7);
            deleteAppointmentButton.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            deleteAppointmentButton.Name = "deleteAppointmentButton";
            deleteAppointmentButton.Size = new System.Drawing.Size(88, 35);
            deleteAppointmentButton.TabIndex = 2;
            deleteAppointmentButton.Text = "Delete";
            deleteAppointmentButton.UseVisualStyleBackColor = true;
            // 
            // appointmentSelectionLabel
            // 
            appointmentSelectionLabel.AutoSize = true;
            appointmentSelectionLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            appointmentSelectionLabel.Location = new System.Drawing.Point(285, 16);
            appointmentSelectionLabel.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            appointmentSelectionLabel.Name = "appointmentSelectionLabel";
            appointmentSelectionLabel.Size = new System.Drawing.Size(176, 15);
            appointmentSelectionLabel.TabIndex = 3;
            appointmentSelectionLabel.Text = "Select a row, then Edit or Delete.";
            // 
            // appointmentTimeZoneLabel
            // 
            appointmentTimeZoneLabel.AutoSize = true;
            appointmentTimeZoneLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            appointmentTimeZoneLabel.Location = new System.Drawing.Point(484, 16);
            appointmentTimeZoneLabel.Margin = new System.Windows.Forms.Padding(20, 16, 3, 3);
            appointmentTimeZoneLabel.Name = "appointmentTimeZoneLabel";
            appointmentTimeZoneLabel.Size = new System.Drawing.Size(65, 15);
            appointmentTimeZoneLabel.TabIndex = 4;
            appointmentTimeZoneLabel.Text = "Time zone:";
            // 
            // calendarPage
            // 
            calendarPage.Location = new System.Drawing.Point(4, 34);
            calendarPage.Name = "calendarPage";
            calendarPage.Size = new System.Drawing.Size(1394, 775);
            calendarPage.TabIndex = 2;
            calendarPage.Text = "Calender";
            calendarPage.UseVisualStyleBackColor = true;
            // 
            // reportsPage
            // 
            reportsPage.Location = new System.Drawing.Point(4, 34);
            reportsPage.Name = "reportsPage";
            reportsPage.Size = new System.Drawing.Size(1394, 775);
            reportsPage.TabIndex = 3;
            reportsPage.Text = "Reports";
            reportsPage.UseVisualStyleBackColor = true;
            // 
            // loginHistoryPage
            // 
            loginHistoryPage.Location = new System.Drawing.Point(4, 34);
            loginHistoryPage.Name = "loginHistoryPage";
            loginHistoryPage.Size = new System.Drawing.Size(1394, 775);
            loginHistoryPage.TabIndex = 4;
            loginHistoryPage.Text = "Login History";
            loginHistoryPage.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1424, 861);
            Controls.Add(Main_TabControlPanel);
            Controls.Add(Main_MenuStripPanel);
            MinimumSize = new System.Drawing.Size(1100, 600);
            Text = "Global Consulting Scheduler";
            Load += MainForm_Load;
            Main_MenuStripPanel.ResumeLayout(false);
            Main_MenuStripPanel.PerformLayout();
            Main_MenuStrip.ResumeLayout(false);
            Main_MenuStrip.PerformLayout();
            Main_TabControlPanel.ResumeLayout(false);
            Main_TabControl.ResumeLayout(false);
            customersPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)customersDataTable).EndInit();
            customersButtonLayoutPanel.ResumeLayout(false);
            customersButtonLayoutPanel.PerformLayout();
            appointmentsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)appointmentsDataTable).EndInit();
            appointmentButtonLayoutPanel.ResumeLayout(false);
            appointmentButtonLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.FlowLayoutPanel appointmentButtonLayoutPanel;
        private System.Windows.Forms.DataGridView appointmentsDataTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn appointmentCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn appointmentUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn appointmentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn appointmentTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn appointmentStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn appointmentEnd;
        private System.Windows.Forms.Button addAppointmentButton;
        private System.Windows.Forms.Button editAppointmentButton;
        private System.Windows.Forms.Button deleteAppointmentButton;
        private System.Windows.Forms.Label appointmentSelectionLabel;
        private System.Windows.Forms.Label appointmentTimeZoneLabel;

        //TODO - Move Tab Control Pages to User Control

        #endregion

        private Panel Main_MenuStripPanel;
        private MenuStrip Main_MenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Panel Main_TabControlPanel;
        private System.Windows.Forms.TabControl Main_TabControl;
        private System.Windows.Forms.TabPage customersPage;
        private TabPage appointmentsPage;
        private TabPage calendarPage;
        private TabPage reportsPage;
        private TabPage loginHistoryPage;
        private System.Windows.Forms.FlowLayoutPanel customersButtonLayoutPanel;
        private System.Windows.Forms.Button addCustomerButton;
        private System.Windows.Forms.Button editCustomerButton;
        private System.Windows.Forms.Button deleteCustomerButton;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private ToolStripMenuItem signOutToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem1;
        private DataGridView customersDataTable;
        private DataGridViewTextBoxColumn customerId;
        private DataGridViewTextBoxColumn customerName;
        private DataGridViewTextBoxColumn customerAddress;
        private DataGridViewTextBoxColumn customerCity;
        private DataGridViewTextBoxColumn customerCountry;
        private DataGridViewTextBoxColumn active;
    }
}
