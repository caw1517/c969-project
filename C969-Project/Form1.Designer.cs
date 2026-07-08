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
            this.Main_TabControl = new TabControl();
            this.customersPage = new TabPage();
            appointmentsPage = new TabPage();
            Main_MenuStripPanel.SuspendLayout();
            Main_MenuStrip.SuspendLayout();
            Main_TabControlPanel.SuspendLayout();
            this.Main_TabControl.SuspendLayout();
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
            Main_MenuStripPanel.Size = new Size(1424, 30);
            Main_MenuStripPanel.TabIndex = 0;
            // 
            // Main_MenuStrip
            // 
            Main_MenuStrip.Dock = DockStyle.Fill;
            Main_MenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, aboutToolStripMenuItem });
            Main_MenuStrip.Location = new Point(0, 0);
            Main_MenuStrip.Name = "Main_MenuStrip";
            Main_MenuStrip.Size = new Size(1422, 28);
            Main_MenuStrip.TabIndex = 0;
            Main_MenuStrip.Text = "Main Menu Strip";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(52, 24);
            aboutToolStripMenuItem.Text = "About";
            // 
            // Main_TabControlPanel
            // 
            Main_TabControlPanel.Controls.Add(this.Main_TabControl);
            Main_TabControlPanel.Dock = DockStyle.Fill;
            Main_TabControlPanel.Location = new Point(0, 30);
            Main_TabControlPanel.Margin = new Padding(5);
            Main_TabControlPanel.Name = "Main_TabControlPanel";
            Main_TabControlPanel.Size = new Size(1424, 831);
            Main_TabControlPanel.TabIndex = 1;
            // 
            // Main_TabControl
            // 
            this.Main_TabControl.Controls.Add(this.customersPage);
            this.Main_TabControl.Controls.Add(appointmentsPage);
            this.Main_TabControl.Dock = DockStyle.Fill;
            this.Main_TabControl.ItemSize = new Size(100, 30);
            this.Main_TabControl.Location = new Point(0, 0);
            this.Main_TabControl.Name = "Main_TabControl";
            this.Main_TabControl.SelectedIndex = 0;
            this.Main_TabControl.Size = new Size(1424, 831);
            this.Main_TabControl.TabIndex = 0;
            // 
            // customersPage
            // 
            this.customersPage.Location = new Point(4, 34);
            this.customersPage.Name = "customersPage";
            this.customersPage.Padding = new Padding(3);
            this.customersPage.Size = new Size(1416, 793);
            this.customersPage.TabIndex = 0;
            this.customersPage.Text = "Customers";
            this.customersPage.UseVisualStyleBackColor = true;
            // 
            // appointmentsPage
            // 
            appointmentsPage.Location = new Point(4, 34);
            appointmentsPage.Name = "appointmentsPage";
            appointmentsPage.Padding = new Padding(3);
            appointmentsPage.Size = new Size(1416, 793);
            appointmentsPage.TabIndex = 1;
            appointmentsPage.Text = "Appointments";
            appointmentsPage.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1424, 861);
            Controls.Add(Main_TabControlPanel);
            Controls.Add(Main_MenuStripPanel);
            Name = "MainForm";
            Text = "Global Consulting Scheduler";
            Main_MenuStripPanel.ResumeLayout(false);
            Main_MenuStripPanel.PerformLayout();
            Main_MenuStrip.ResumeLayout(false);
            Main_MenuStrip.PerformLayout();
            Main_TabControlPanel.ResumeLayout(false);
            this.Main_TabControl.ResumeLayout(false);
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
    }
}
