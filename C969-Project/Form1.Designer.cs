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
            aboutToolStripMenuItem = new ToolStripMenuItem();
            Main_TabControlPanel = new Panel();
            Main_TabControl = new TabControl();
            customersPage = new TabPage();
            customersButtonLayoutPanel = new FlowLayoutPanel();
            addCustomerButton = new Button();
            editCustomerButton = new Button();
            deleteCustomerButton = new Button();
            maskedTextBox1 = new MaskedTextBox();
            appointmentsPage = new TabPage();
            calendarPage = new TabPage();
            reportsPage = new TabPage();
            loginHistoryPage = new TabPage();
            signOutToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem1 = new ToolStripMenuItem();
            Main_MenuStripPanel.SuspendLayout();
            Main_MenuStrip.SuspendLayout();
            Main_TabControlPanel.SuspendLayout();
            Main_TabControl.SuspendLayout();
            customersPage.SuspendLayout();
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
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem1 });
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(52, 20);
            aboutToolStripMenuItem.Text = "About";
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
            customersPage.Controls.Add(customersButtonLayoutPanel);
            customersPage.Location = new Point(4, 34);
            customersPage.Name = "customersPage";
            customersPage.Padding = new Padding(3);
            customersPage.Size = new Size(1394, 775);
            customersPage.TabIndex = 0;
            customersPage.Text = "Customers";
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
            maskedTextBox1.Location = new Point(285, 17);
            maskedTextBox1.Margin = new Padding(3, 17, 3, 3);
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
            appointmentsPage.Size = new Size(1396, 777);
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
            reportsPage.Size = new Size(1396, 777);
            reportsPage.TabIndex = 3;
            reportsPage.Text = "Reports";
            reportsPage.UseVisualStyleBackColor = true;
            // 
            // loginHistoryPage
            // 
            loginHistoryPage.Location = new Point(4, 34);
            loginHistoryPage.Name = "loginHistoryPage";
            loginHistoryPage.Size = new Size(1396, 777);
            loginHistoryPage.TabIndex = 4;
            loginHistoryPage.Text = "Login History";
            loginHistoryPage.UseVisualStyleBackColor = true;
            // 
            // signOutToolStripMenuItem
            // 
            signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            signOutToolStripMenuItem.Size = new Size(180, 22);
            signOutToolStripMenuItem.Text = "Sign Out";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "Exit";
            // 
            // aboutToolStripMenuItem1
            // 
            aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            aboutToolStripMenuItem1.Size = new Size(180, 22);
            aboutToolStripMenuItem1.Text = "About";
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
            Main_MenuStripPanel.ResumeLayout(false);
            Main_MenuStripPanel.PerformLayout();
            Main_MenuStrip.ResumeLayout(false);
            Main_MenuStrip.PerformLayout();
            Main_TabControlPanel.ResumeLayout(false);
            Main_TabControl.ResumeLayout(false);
            customersPage.ResumeLayout(false);
            customersButtonLayoutPanel.ResumeLayout(false);
            customersButtonLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }

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
    }
}
