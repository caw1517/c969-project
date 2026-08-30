namespace C969_Project.Forms
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            loginLayoutPanel = new TableLayoutPanel();
            loginFormHeaderPanel = new TableLayoutPanel();
            loginFormHeaderLabel = new Label();
            loginFormHeaderSubLabel = new Label();
            loginFormLoginButton = new Button();
            loginLayoutPanel.SuspendLayout();
            loginFormHeaderPanel.SuspendLayout();
            SuspendLayout();
            // 
            // loginLayoutPanel
            // 
            loginLayoutPanel.ColumnCount = 3;
            loginLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.5454545F));
            loginLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90.90909F));
            loginLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.5454545F));
            loginLayoutPanel.Controls.Add(loginFormHeaderPanel, 1, 1);
            loginLayoutPanel.Dock = DockStyle.Fill;
            loginLayoutPanel.Location = new Point(0, 0);
            loginLayoutPanel.Name = "loginLayoutPanel";
            loginLayoutPanel.RowCount = 3;
            loginLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333332F));
            loginLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 83.3333359F));
            loginLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333332F));
            loginLayoutPanel.Size = new Size(484, 411);
            loginLayoutPanel.TabIndex = 0;
            // 
            // loginFormHeaderPanel
            // 
            loginFormHeaderPanel.ColumnCount = 1;
            loginFormHeaderPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            loginFormHeaderPanel.Controls.Add(loginFormHeaderLabel, 0, 0);
            loginFormHeaderPanel.Controls.Add(loginFormHeaderSubLabel, 0, 1);
            loginFormHeaderPanel.Controls.Add(loginFormLoginButton, 0, 4);
            loginFormHeaderPanel.Dock = DockStyle.Fill;
            loginFormHeaderPanel.Location = new Point(25, 37);
            loginFormHeaderPanel.Name = "loginFormHeaderPanel";
            loginFormHeaderPanel.RowCount = 5;
            loginFormHeaderPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            loginFormHeaderPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            loginFormHeaderPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            loginFormHeaderPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            loginFormHeaderPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            loginFormHeaderPanel.Size = new Size(434, 336);
            loginFormHeaderPanel.TabIndex = 0;
            // 
            // loginFormHeaderLabel
            // 
            loginFormHeaderLabel.AutoSize = true;
            loginFormHeaderLabel.Dock = DockStyle.Fill;
            loginFormHeaderLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            loginFormHeaderLabel.ForeColor = SystemColors.MenuHighlight;
            loginFormHeaderLabel.Location = new Point(3, 0);
            loginFormHeaderLabel.Name = "loginFormHeaderLabel";
            loginFormHeaderLabel.Size = new Size(428, 30);
            loginFormHeaderLabel.TabIndex = 1;
            loginFormHeaderLabel.Text = "C969 Scheduling Login";
            loginFormHeaderLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // loginFormHeaderSubLabel
            // 
            loginFormHeaderSubLabel.AutoSize = true;
            loginFormHeaderSubLabel.Dock = DockStyle.Fill;
            loginFormHeaderSubLabel.Location = new Point(3, 30);
            loginFormHeaderSubLabel.Name = "loginFormHeaderSubLabel";
            loginFormHeaderSubLabel.Size = new Size(428, 30);
            loginFormHeaderSubLabel.TabIndex = 2;
            loginFormHeaderSubLabel.Text = "Sign in to manage customers and appointments.";
            // 
            // loginFormLoginButton
            // 
            loginFormLoginButton.Dock = DockStyle.Fill;
            loginFormLoginButton.Location = new Point(3, 247);
            loginFormLoginButton.Name = "loginFormLoginButton";
            loginFormLoginButton.Size = new Size(428, 86);
            loginFormLoginButton.TabIndex = 3;
            loginFormLoginButton.Text = "Login";
            loginFormLoginButton.UseVisualStyleBackColor = true;
            loginFormLoginButton.Click += loginFormLoginButton_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 411);
            Controls.Add(loginLayoutPanel);
            Name = "LoginForm";
            Text = "LoginForm";
            loginLayoutPanel.ResumeLayout(false);
            loginFormHeaderPanel.ResumeLayout(false);
            loginFormHeaderPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel loginLayoutPanel;
        private TableLayoutPanel loginFormHeaderPanel;
        private Label loginFormHeaderLabel;
        private Label loginFormHeaderSubLabel;
        private Button loginFormLoginButton;
    }
}