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
            loginFormLayoutPanel = new TableLayoutPanel();
            loginFormHeaderLabel = new Label();
            loginFormHeaderSubLabel = new Label();
            loginGroupBox = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            loginFormOfficeComboBox = new ComboBox();
            loginFormLanguageComboBox = new ComboBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            label4 = new Label();
            label5 = new Label();
            loginFormUsernameInput = new TextBox();
            loginFormPasswordInput = new TextBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            loginFormLoginButton = new Button();
            loginFormCancelButton = new Button();
            label6 = new Label();
            loginLayoutPanel.SuspendLayout();
            loginFormLayoutPanel.SuspendLayout();
            loginGroupBox.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // loginLayoutPanel
            // 
            loginLayoutPanel.ColumnCount = 3;
            loginLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.5454545F));
            loginLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90.90909F));
            loginLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.5454545F));
            loginLayoutPanel.Controls.Add(loginFormLayoutPanel, 1, 1);
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
            // loginFormLayoutPanel
            // 
            loginFormLayoutPanel.ColumnCount = 1;
            loginFormLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            loginFormLayoutPanel.Controls.Add(loginFormHeaderLabel, 0, 0);
            loginFormLayoutPanel.Controls.Add(loginFormHeaderSubLabel, 0, 1);
            loginFormLayoutPanel.Controls.Add(loginGroupBox, 0, 2);
            loginFormLayoutPanel.Controls.Add(tableLayoutPanel2, 0, 3);
            loginFormLayoutPanel.Controls.Add(tableLayoutPanel3, 0, 4);
            loginFormLayoutPanel.Controls.Add(label6, 0, 5);
            loginFormLayoutPanel.Dock = DockStyle.Fill;
            loginFormLayoutPanel.Location = new Point(25, 37);
            loginFormLayoutPanel.Name = "loginFormLayoutPanel";
            loginFormLayoutPanel.RowCount = 6;
            loginFormLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            loginFormLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            loginFormLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 40.01916F));
            loginFormLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 40.01916F));
            loginFormLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 19.9616756F));
            loginFormLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            loginFormLayoutPanel.Size = new Size(434, 336);
            loginFormLayoutPanel.TabIndex = 0;
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
            // loginGroupBox
            // 
            loginGroupBox.Controls.Add(tableLayoutPanel1);
            loginGroupBox.Dock = DockStyle.Fill;
            loginGroupBox.ForeColor = SystemColors.MenuHighlight;
            loginGroupBox.Location = new Point(3, 63);
            loginGroupBox.Name = "loginGroupBox";
            loginGroupBox.Size = new Size(428, 96);
            loginGroupBox.TabIndex = 4;
            loginGroupBox.TabStop = false;
            loginGroupBox.Text = "Location and Language";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.191803F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64.8082F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(loginFormOfficeComboBox, 1, 0);
            tableLayoutPanel1.Controls.Add(loginFormLanguageComboBox, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 19);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(422, 74);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(142, 27);
            label1.TabIndex = 0;
            label1.Text = "Office:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(3, 27);
            label2.Name = "label2";
            label2.Size = new Size(142, 27);
            label2.TabIndex = 1;
            label2.Text = "Language:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 8F);
            label3.ForeColor = SystemColors.GrayText;
            label3.Location = new Point(3, 54);
            label3.Name = "label3";
            label3.Size = new Size(142, 20);
            label3.TabIndex = 2;
            label3.Text = "Eastern Time (New York)";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // loginFormOfficeComboBox
            // 
            loginFormOfficeComboBox.Dock = DockStyle.Fill;
            loginFormOfficeComboBox.FormattingEnabled = true;
            loginFormOfficeComboBox.Location = new Point(151, 3);
            loginFormOfficeComboBox.Name = "loginFormOfficeComboBox";
            loginFormOfficeComboBox.Size = new Size(268, 23);
            loginFormOfficeComboBox.TabIndex = 3;
            // 
            // loginFormLanguageComboBox
            // 
            loginFormLanguageComboBox.Dock = DockStyle.Fill;
            loginFormLanguageComboBox.FormattingEnabled = true;
            loginFormLanguageComboBox.Location = new Point(151, 30);
            loginFormLanguageComboBox.Name = "loginFormLanguageComboBox";
            loginFormLanguageComboBox.Size = new Size(268, 23);
            loginFormLanguageComboBox.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.51402F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64.4859848F));
            tableLayoutPanel2.Controls.Add(label4, 0, 0);
            tableLayoutPanel2.Controls.Add(label5, 0, 1);
            tableLayoutPanel2.Controls.Add(loginFormUsernameInput, 1, 0);
            tableLayoutPanel2.Controls.Add(loginFormPasswordInput, 1, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 165);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(428, 96);
            tableLayoutPanel2.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(146, 48);
            label4.TabIndex = 0;
            label4.Text = "Username: ";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(3, 48);
            label5.Name = "label5";
            label5.Size = new Size(146, 48);
            label5.TabIndex = 1;
            label5.Text = "Password: ";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // loginFormUsernameInput
            // 
            loginFormUsernameInput.Dock = DockStyle.Fill;
            loginFormUsernameInput.Location = new Point(155, 3);
            loginFormUsernameInput.Name = "loginFormUsernameInput";
            loginFormUsernameInput.Size = new Size(270, 23);
            loginFormUsernameInput.TabIndex = 2;
            // 
            // loginFormPasswordInput
            // 
            loginFormPasswordInput.Dock = DockStyle.Fill;
            loginFormPasswordInput.Location = new Point(155, 51);
            loginFormPasswordInput.Name = "loginFormPasswordInput";
            loginFormPasswordInput.PasswordChar = '*';
            loginFormPasswordInput.Size = new Size(270, 23);
            loginFormPasswordInput.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.Controls.Add(loginFormLoginButton, 1, 0);
            tableLayoutPanel3.Controls.Add(loginFormCancelButton, 2, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 267);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(428, 45);
            tableLayoutPanel3.TabIndex = 6;
            // 
            // loginFormLoginButton
            // 
            loginFormLoginButton.Dock = DockStyle.Fill;
            loginFormLoginButton.Location = new Point(217, 3);
            loginFormLoginButton.Name = "loginFormLoginButton";
            loginFormLoginButton.Size = new Size(101, 39);
            loginFormLoginButton.TabIndex = 3;
            loginFormLoginButton.Text = "Login";
            loginFormLoginButton.UseVisualStyleBackColor = true;
            loginFormLoginButton.Click += loginFormLoginButton_Click;
            // 
            // loginFormCancelButton
            // 
            loginFormCancelButton.Dock = DockStyle.Fill;
            loginFormCancelButton.Location = new Point(324, 3);
            loginFormCancelButton.Name = "loginFormCancelButton";
            loginFormCancelButton.Size = new Size(101, 39);
            loginFormCancelButton.TabIndex = 4;
            loginFormCancelButton.Text = "Cancel";
            loginFormCancelButton.UseVisualStyleBackColor = true;
            loginFormCancelButton.Click += loginFormCancelButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.ForeColor = SystemColors.GrayText;
            label6.Location = new Point(3, 315);
            label6.Name = "label6";
            label6.Size = new Size(428, 21);
            label6.TabIndex = 7;
            label6.Text = "Prototype credentials: test / test";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 411);
            Controls.Add(loginLayoutPanel);
            Name = "LoginForm";
            Text = "Sign In";
            loginLayoutPanel.ResumeLayout(false);
            loginFormLayoutPanel.ResumeLayout(false);
            loginFormLayoutPanel.PerformLayout();
            loginGroupBox.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel loginLayoutPanel;
        private TableLayoutPanel loginFormLayoutPanel;
        private Label loginFormHeaderLabel;
        private Label loginFormHeaderSubLabel;
        private Button loginFormLoginButton;
        private GroupBox loginGroupBox;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox loginFormOfficeComboBox;
        private ComboBox loginFormLanguageComboBox;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label4;
        private Label label5;
        private TextBox loginFormUsernameInput;
        private TextBox loginFormPasswordInput;
        private TableLayoutPanel tableLayoutPanel3;
        private Button loginFormCancelButton;
        private Label label6;
    }
}