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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Main_MenuStripPanel = new Panel();
            Main_MenuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            signOutToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem1 = new ToolStripMenuItem();
            Main_TabControlPanel = new Panel();
            Main_TabControl = new TabControl();
            customersPage = new TabPage();
            customersDataTable = new DataGridView();
            customerId = new DataGridViewTextBoxColumn();
            customerName = new DataGridViewTextBoxColumn();
            customerAddress = new DataGridViewTextBoxColumn();
            customerCity = new DataGridViewTextBoxColumn();
            customerCountry = new DataGridViewTextBoxColumn();
            active = new DataGridViewTextBoxColumn();
            customersButtonLayoutPanel = new FlowLayoutPanel();
            addCustomerButton = new Button();
            editCustomerButton = new Button();
            deleteCustomerButton = new Button();
            maskedTextBox1 = new MaskedTextBox();
            appointmentsPage = new TabPage();
            calendarPage = new TabPage();
            reportsPage = new TabPage();
            loginHistoryPage = new TabPage();
            Main_MenuStripPanel.SuspendLayout();
            Main_MenuStrip.SuspendLayout();
            Main_TabControlPanel.SuspendLayout();
            Main_TabControl.SuspendLayout();
            customersPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)customersDataTable).BeginInit();
            customersButtonLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // Main_MenuStripPanel
            // 
            Main_MenuStripPanel.BorderStyle = BorderStyle.FixedSingle;
            Main_MenuStripPanel.Controls.Add(Main_MenuStrip);
            Main_MenuStripPanel.Dock = DockStyle.Top;
            Main_MenuStripPanel.Location = new Point(0, 0);
            Main_MenuStripPanel.Margin = new Padding(5);
            Main_MenuStripPanel.Name = "Main_MenuStripPanel";
            Main_MenuStripPanel.Size = new Size(1424, 26);
            Main_MenuStripPanel.TabIndex = 0;
            // 
            // Main_MenuStrip
            // 
            Main_MenuStrip.Dock = DockStyle.Fill;
            Main_MenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, aboutToolStripMenuItem });
            Main_MenuStrip.Location = new Point(0, 0);
            Main_MenuStrip.Name = "Main_MenuStrip";
            Main_MenuStrip.Size = new Size(1422, 24);
            Main_MenuStrip.TabIndex = 0;
            Main_MenuStrip.Text = "Main Menu Strip";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { signOutToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // signOutToolStripMenuItem
            // 
            signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            signOutToolStripMenuItem.Size = new Size(120, 22);
            signOutToolStripMenuItem.Text = "Sign Out";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(120, 22);
            exitToolStripMenuItem.Text = "Exit";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem1 });
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(52, 20);
            aboutToolStripMenuItem.Text = "About";
            // 
            // aboutToolStripMenuItem1
            // 
            aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            aboutToolStripMenuItem1.Size = new Size(107, 22);
            aboutToolStripMenuItem1.Text = "About";
            // 
            // Main_TabControlPanel
            // 
            Main_TabControlPanel.BackColor = SystemColors.Control;
            Main_TabControlPanel.BorderStyle = BorderStyle.FixedSingle;
            Main_TabControlPanel.Controls.Add(Main_TabControl);
            Main_TabControlPanel.Dock = DockStyle.Fill;
            Main_TabControlPanel.Location = new Point(0, 26);
            Main_TabControlPanel.Margin = new Padding(5);
            Main_TabControlPanel.Name = "Main_TabControlPanel";
            Main_TabControlPanel.Padding = new Padding(10);
            Main_TabControlPanel.Size = new Size(1424, 835);
            Main_TabControlPanel.TabIndex = 1;
            // 
            // Main_TabControl
            // 
            Main_TabControl.Controls.Add(customersPage);
            Main_TabControl.Controls.Add(appointmentsPage);
            Main_TabControl.Controls.Add(calendarPage);
            Main_TabControl.Controls.Add(reportsPage);
            Main_TabControl.Controls.Add(loginHistoryPage);
            Main_TabControl.Dock = DockStyle.Fill;
            Main_TabControl.ItemSize = new Size(100, 30);
            Main_TabControl.Location = new Point(10, 10);
            Main_TabControl.Name = "Main_TabControl";
            Main_TabControl.SelectedIndex = 0;
            Main_TabControl.Size = new Size(1402, 813);
            Main_TabControl.TabIndex = 0;
            // 
            // customersPage
            // 
            customersPage.BackColor = SystemColors.Control;
            customersPage.Controls.Add(customersDataTable);
            customersPage.Controls.Add(customersButtonLayoutPanel);
            customersPage.Location = new Point(4, 34);
            customersPage.Name = "customersPage";
            customersPage.Padding = new Padding(3);
            customersPage.Size = new Size(1394, 775);
            customersPage.TabIndex = 0;
            customersPage.Text = "Customers";
            // 
            // customersDataTable
            // 
            customersDataTable.AllowUserToAddRows = false;
            customersDataTable.AllowUserToDeleteRows = false;
            customersDataTable.AllowUserToResizeRows = false;
            customersDataTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            customersDataTable.BackgroundColor = SystemColors.ControlLightLight;
            customersDataTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            customersDataTable.Columns.AddRange(new DataGridViewColumn[] { customerId, customerName, customerAddress, customerCity, customerCountry, active });
            customersDataTable.Dock = DockStyle.Fill;
            customersDataTable.EditMode = DataGridViewEditMode.EditProgrammatically;
            customersDataTable.Location = new Point(3, 53);
            customersDataTable.MultiSelect = false;
            customersDataTable.Name = "customersDataTable";
            customersDataTable.RowHeadersVisible = false;
            customersDataTable.Size = new Size(1388, 719);
            customersDataTable.TabIndex = 1;
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
            customerAddress.DataPropertyName = "Address";
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
            customersButtonLayoutPanel.Dock = DockStyle.Top;
            customersButtonLayoutPanel.Location = new Point(3, 3);
            customersButtonLayoutPanel.Name = "customersButtonLayoutPanel";
            customersButtonLayoutPanel.Size = new Size(1388, 50);
            customersButtonLayoutPanel.TabIndex = 0;
            // 
            // addCustomerButton
            // 
            addCustomerButton.Dock = DockStyle.Top;
            addCustomerButton.Location = new Point(3, 7);
            addCustomerButton.Margin = new Padding(3, 7, 3, 3);
            addCustomerButton.Name = "addCustomerButton";
            addCustomerButton.Size = new Size(88, 35);
            addCustomerButton.TabIndex = 0;
            addCustomerButton.Text = "Add";
            addCustomerButton.UseVisualStyleBackColor = true;
            // 
            // editCustomerButton
            // 
            editCustomerButton.Location = new Point(97, 7);
            editCustomerButton.Margin = new Padding(3, 7, 3, 3);
            editCustomerButton.Name = "editCustomerButton";
            editCustomerButton.Size = new Size(88, 35);
            editCustomerButton.TabIndex = 1;
            editCustomerButton.Text = "Edit";
            editCustomerButton.UseVisualStyleBackColor = true;
            editCustomerButton.Click += editCustomerButton_Click;
            // 
            // deleteCustomerButton
            // 
            deleteCustomerButton.Location = new Point(191, 7);
            deleteCustomerButton.Margin = new Padding(3, 7, 3, 3);
            deleteCustomerButton.Name = "deleteCustomerButton";
            deleteCustomerButton.Size = new Size(88, 35);
            deleteCustomerButton.TabIndex = 2;
            deleteCustomerButton.Text = "Delete";
            deleteCustomerButton.UseVisualStyleBackColor = true;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.BackColor = SystemColors.Control;
            maskedTextBox1.BorderStyle = BorderStyle.None;
            maskedTextBox1.ForeColor = SystemColors.ControlDarkDark;
            maskedTextBox1.Location = new Point(285, 16);
            maskedTextBox1.Margin = new Padding(3, 16, 3, 3);
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(315, 16);
            maskedTextBox1.TabIndex = 3;
            maskedTextBox1.Text = "Select a row, then Edit or Delete.  Double-click a row to edit";
            // 
            // appointmentsPage
            // 
            appointmentsPage.Location = new Point(4, 34);
            appointmentsPage.Name = "appointmentsPage";
            appointmentsPage.Padding = new Padding(3);
            appointmentsPage.Size = new Size(1394, 775);
            appointmentsPage.TabIndex = 1;
            appointmentsPage.Text = "Appointments";
            appointmentsPage.UseVisualStyleBackColor = true;
            // 
            // calendarPage
            // 
            calendarPage.Location = new Point(4, 34);
            calendarPage.Name = "calendarPage";
            calendarPage.Size = new Size(1394, 775);
            calendarPage.TabIndex = 2;
            calendarPage.Text = "Calender";
            calendarPage.UseVisualStyleBackColor = true;
            // 
            // reportsPage
            // 
            reportsPage.Location = new Point(4, 34);
            reportsPage.Name = "reportsPage";
            reportsPage.Size = new Size(1394, 775);
            reportsPage.TabIndex = 3;
            reportsPage.Text = "Reports";
            reportsPage.UseVisualStyleBackColor = true;
            // 
            // loginHistoryPage
            // 
            loginHistoryPage.Location = new Point(4, 34);
            loginHistoryPage.Name = "loginHistoryPage";
            loginHistoryPage.Size = new Size(1394, 775);
            loginHistoryPage.TabIndex = 4;
            loginHistoryPage.Text = "Login History";
            loginHistoryPage.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1424, 861);
            Controls.Add(Main_TabControlPanel);
            Controls.Add(Main_MenuStripPanel);
            MinimumSize = new Size(1100, 600);
            Name = "MainForm";
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
            ResumeLayout(false);
        }

        //TODO - Move Tab Control Pages to User Control

        #endregion

        private Panel Main_MenuStripPanel;
        private MenuStrip Main_MenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Panel Main_TabControlPanel;
        private TabControl Main_TabControl;
        private TabPage customersPage;
        private TabPage appointmentsPage;
        private TabPage calendarPage;
        private TabPage reportsPage;
        private TabPage loginHistoryPage;
        private FlowLayoutPanel customersButtonLayoutPanel;
        private Button addCustomerButton;
        private Button editCustomerButton;
        private Button deleteCustomerButton;
        private MaskedTextBox maskedTextBox1;
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
