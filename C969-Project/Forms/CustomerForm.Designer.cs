namespace C969_Project.Forms
{
    partial class CustomerForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            nameEditCustomerLabel = new Label();
            phoneEditCustomerLabel = new Label();
            addressEditCustomerLabel = new Label();
            address2EditCustomerLabel = new Label();
            cityEditCustomerLabel = new Label();
            postalEditCustomerLabel = new Label();
            countryEditCustomerLabel = new Label();
            nameEditCustomerTextBox = new TextBox();
            phoneEditCustomerTextBox = new TextBox();
            addressEditCustomerTextBox = new TextBox();
            address2EditCustomerTextBox = new TextBox();
            postalEditCustomerTextBox = new TextBox();
            activeEditCustomerCheckBox = new CheckBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            saveEditCustomerButton = new Button();
            cancelEditCustomerButton = new Button();
            cityCustomerSelectBox = new ComboBox();
            countryCustomerSelectBox = new ComboBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.Controls.Add(nameEditCustomerLabel, 1, 1);
            tableLayoutPanel1.Controls.Add(phoneEditCustomerLabel, 1, 2);
            tableLayoutPanel1.Controls.Add(addressEditCustomerLabel, 1, 3);
            tableLayoutPanel1.Controls.Add(address2EditCustomerLabel, 1, 4);
            tableLayoutPanel1.Controls.Add(cityEditCustomerLabel, 1, 5);
            tableLayoutPanel1.Controls.Add(postalEditCustomerLabel, 1, 6);
            tableLayoutPanel1.Controls.Add(countryEditCustomerLabel, 1, 7);
            tableLayoutPanel1.Controls.Add(nameEditCustomerTextBox, 2, 1);
            tableLayoutPanel1.Controls.Add(phoneEditCustomerTextBox, 2, 2);
            tableLayoutPanel1.Controls.Add(addressEditCustomerTextBox, 2, 3);
            tableLayoutPanel1.Controls.Add(address2EditCustomerTextBox, 2, 4);
            tableLayoutPanel1.Controls.Add(postalEditCustomerTextBox, 2, 6);
            tableLayoutPanel1.Controls.Add(activeEditCustomerCheckBox, 2, 8);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 2, 9);
            tableLayoutPanel1.Controls.Add(cityCustomerSelectBox, 2, 5);
            tableLayoutPanel1.Controls.Add(countryCustomerSelectBox, 2, 7);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 11;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(484, 486);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // nameEditCustomerLabel
            // 
            nameEditCustomerLabel.AutoSize = true;
            nameEditCustomerLabel.Dock = DockStyle.Fill;
            nameEditCustomerLabel.Location = new Point(25, 20);
            nameEditCustomerLabel.Margin = new Padding(0);
            nameEditCustomerLabel.Name = "nameEditCustomerLabel";
            nameEditCustomerLabel.Size = new Size(86, 49);
            nameEditCustomerLabel.TabIndex = 0;
            nameEditCustomerLabel.Text = "Name: ";
            nameEditCustomerLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // phoneEditCustomerLabel
            // 
            phoneEditCustomerLabel.AutoSize = true;
            phoneEditCustomerLabel.Dock = DockStyle.Fill;
            phoneEditCustomerLabel.Location = new Point(25, 69);
            phoneEditCustomerLabel.Margin = new Padding(0);
            phoneEditCustomerLabel.Name = "phoneEditCustomerLabel";
            phoneEditCustomerLabel.Size = new Size(86, 49);
            phoneEditCustomerLabel.TabIndex = 1;
            phoneEditCustomerLabel.Text = "Phone: ";
            phoneEditCustomerLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // addressEditCustomerLabel
            // 
            addressEditCustomerLabel.Dock = DockStyle.Fill;
            addressEditCustomerLabel.Location = new Point(25, 118);
            addressEditCustomerLabel.Margin = new Padding(0);
            addressEditCustomerLabel.Name = "addressEditCustomerLabel";
            addressEditCustomerLabel.Size = new Size(86, 49);
            addressEditCustomerLabel.TabIndex = 2;
            addressEditCustomerLabel.Text = "Adress:";
            addressEditCustomerLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // address2EditCustomerLabel
            // 
            address2EditCustomerLabel.AutoSize = true;
            address2EditCustomerLabel.Dock = DockStyle.Fill;
            address2EditCustomerLabel.Location = new Point(25, 167);
            address2EditCustomerLabel.Margin = new Padding(0);
            address2EditCustomerLabel.Name = "address2EditCustomerLabel";
            address2EditCustomerLabel.Size = new Size(86, 49);
            address2EditCustomerLabel.TabIndex = 3;
            address2EditCustomerLabel.Text = "Address 2:";
            address2EditCustomerLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cityEditCustomerLabel
            // 
            cityEditCustomerLabel.AutoSize = true;
            cityEditCustomerLabel.Dock = DockStyle.Fill;
            cityEditCustomerLabel.Location = new Point(28, 216);
            cityEditCustomerLabel.Name = "cityEditCustomerLabel";
            cityEditCustomerLabel.Size = new Size(80, 49);
            cityEditCustomerLabel.TabIndex = 4;
            cityEditCustomerLabel.Text = "City:";
            cityEditCustomerLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // postalEditCustomerLabel
            // 
            postalEditCustomerLabel.AutoSize = true;
            postalEditCustomerLabel.Dock = DockStyle.Fill;
            postalEditCustomerLabel.Location = new Point(28, 265);
            postalEditCustomerLabel.Name = "postalEditCustomerLabel";
            postalEditCustomerLabel.Size = new Size(80, 49);
            postalEditCustomerLabel.TabIndex = 5;
            postalEditCustomerLabel.Text = "Postal Code:";
            postalEditCustomerLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // countryEditCustomerLabel
            // 
            countryEditCustomerLabel.AutoSize = true;
            countryEditCustomerLabel.Dock = DockStyle.Fill;
            countryEditCustomerLabel.Location = new Point(25, 314);
            countryEditCustomerLabel.Margin = new Padding(0);
            countryEditCustomerLabel.Name = "countryEditCustomerLabel";
            countryEditCustomerLabel.Size = new Size(86, 49);
            countryEditCustomerLabel.TabIndex = 6;
            countryEditCustomerLabel.Text = "Country:";
            countryEditCustomerLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nameEditCustomerTextBox
            // 
            nameEditCustomerTextBox.BorderStyle = BorderStyle.FixedSingle;
            nameEditCustomerTextBox.Dock = DockStyle.Fill;
            nameEditCustomerTextBox.Location = new Point(114, 33);
            nameEditCustomerTextBox.Margin = new Padding(3, 13, 3, 3);
            nameEditCustomerTextBox.Name = "nameEditCustomerTextBox";
            nameEditCustomerTextBox.Size = new Size(341, 23);
            nameEditCustomerTextBox.TabIndex = 7;
            // 
            // phoneEditCustomerTextBox
            // 
            phoneEditCustomerTextBox.BorderStyle = BorderStyle.FixedSingle;
            phoneEditCustomerTextBox.Dock = DockStyle.Fill;
            phoneEditCustomerTextBox.Location = new Point(114, 82);
            phoneEditCustomerTextBox.Margin = new Padding(3, 13, 3, 3);
            phoneEditCustomerTextBox.Name = "phoneEditCustomerTextBox";
            phoneEditCustomerTextBox.Size = new Size(341, 23);
            phoneEditCustomerTextBox.TabIndex = 8;
            // 
            // addressEditCustomerTextBox
            // 
            addressEditCustomerTextBox.BorderStyle = BorderStyle.FixedSingle;
            addressEditCustomerTextBox.Dock = DockStyle.Fill;
            addressEditCustomerTextBox.Location = new Point(114, 131);
            addressEditCustomerTextBox.Margin = new Padding(3, 13, 3, 3);
            addressEditCustomerTextBox.Name = "addressEditCustomerTextBox";
            addressEditCustomerTextBox.Size = new Size(341, 23);
            addressEditCustomerTextBox.TabIndex = 9;
            // 
            // address2EditCustomerTextBox
            // 
            address2EditCustomerTextBox.BorderStyle = BorderStyle.FixedSingle;
            address2EditCustomerTextBox.Dock = DockStyle.Fill;
            address2EditCustomerTextBox.Location = new Point(114, 180);
            address2EditCustomerTextBox.Margin = new Padding(3, 13, 3, 3);
            address2EditCustomerTextBox.Name = "address2EditCustomerTextBox";
            address2EditCustomerTextBox.Size = new Size(341, 23);
            address2EditCustomerTextBox.TabIndex = 10;
            // 
            // postalEditCustomerTextBox
            // 
            postalEditCustomerTextBox.BorderStyle = BorderStyle.FixedSingle;
            postalEditCustomerTextBox.Dock = DockStyle.Fill;
            postalEditCustomerTextBox.Location = new Point(114, 278);
            postalEditCustomerTextBox.Margin = new Padding(3, 13, 3, 3);
            postalEditCustomerTextBox.Name = "postalEditCustomerTextBox";
            postalEditCustomerTextBox.Size = new Size(341, 23);
            postalEditCustomerTextBox.TabIndex = 12;
            // 
            // activeEditCustomerCheckBox
            // 
            activeEditCustomerCheckBox.AutoSize = true;
            activeEditCustomerCheckBox.Dock = DockStyle.Fill;
            activeEditCustomerCheckBox.Location = new Point(114, 366);
            activeEditCustomerCheckBox.Name = "activeEditCustomerCheckBox";
            activeEditCustomerCheckBox.Size = new Size(341, 43);
            activeEditCustomerCheckBox.TabIndex = 14;
            activeEditCustomerCheckBox.Text = "Active";
            activeEditCustomerCheckBox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel2.Controls.Add(saveEditCustomerButton, 1, 0);
            tableLayoutPanel2.Controls.Add(cancelEditCustomerButton, 2, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(114, 415);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(341, 43);
            tableLayoutPanel2.TabIndex = 15;
            // 
            // saveEditCustomerButton
            // 
            saveEditCustomerButton.Dock = DockStyle.Fill;
            saveEditCustomerButton.Location = new Point(140, 4);
            saveEditCustomerButton.Margin = new Padding(4);
            saveEditCustomerButton.Name = "saveEditCustomerButton";
            saveEditCustomerButton.Size = new Size(94, 35);
            saveEditCustomerButton.TabIndex = 0;
            saveEditCustomerButton.Text = "Save";
            saveEditCustomerButton.UseVisualStyleBackColor = true;
            saveEditCustomerButton.Click += saveEditCustomerButton_Click;
            // 
            // cancelEditCustomerButton
            // 
            cancelEditCustomerButton.Dock = DockStyle.Fill;
            cancelEditCustomerButton.Location = new Point(242, 4);
            cancelEditCustomerButton.Margin = new Padding(4);
            cancelEditCustomerButton.Name = "cancelEditCustomerButton";
            cancelEditCustomerButton.Size = new Size(95, 35);
            cancelEditCustomerButton.TabIndex = 1;
            cancelEditCustomerButton.Text = "Cancel";
            cancelEditCustomerButton.UseVisualStyleBackColor = true;
            cancelEditCustomerButton.Click += cancelEditCustomerButton_Click;
            // 
            // cityCustomerSelectBox
            // 
            cityCustomerSelectBox.Dock = DockStyle.Fill;
            cityCustomerSelectBox.FormattingEnabled = true;
            cityCustomerSelectBox.Location = new Point(114, 229);
            cityCustomerSelectBox.Margin = new Padding(3, 13, 3, 3);
            cityCustomerSelectBox.Name = "cityCustomerSelectBox";
            cityCustomerSelectBox.Size = new Size(341, 23);
            cityCustomerSelectBox.TabIndex = 16;
            // 
            // countryCustomerSelectBox
            // 
            countryCustomerSelectBox.Dock = DockStyle.Fill;
            countryCustomerSelectBox.FormattingEnabled = true;
            countryCustomerSelectBox.Location = new Point(114, 327);
            countryCustomerSelectBox.Margin = new Padding(3, 13, 3, 3);
            countryCustomerSelectBox.Name = "countryCustomerSelectBox";
            countryCustomerSelectBox.Size = new Size(341, 23);
            countryCustomerSelectBox.TabIndex = 17;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 486);
            Controls.Add(tableLayoutPanel1);
            Name = "CustomerForm";
            Text = "Customer";
            Load += CustomerForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label nameEditCustomerLabel;
        private Label phoneEditCustomerLabel;
        private Label addressEditCustomerLabel;
        private Label address2EditCustomerLabel;
        private Label cityEditCustomerLabel;
        private Label postalEditCustomerLabel;
        private Label countryEditCustomerLabel;
        private TextBox nameEditCustomerTextBox;
        private TextBox phoneEditCustomerTextBox;
        private TextBox addressEditCustomerTextBox;
        private TextBox address2EditCustomerTextBox;
        private TextBox postalEditCustomerTextBox;
        private CheckBox activeEditCustomerCheckBox;
        private TableLayoutPanel tableLayoutPanel2;
        private Button saveEditCustomerButton;
        private Button cancelEditCustomerButton;
        private ComboBox cityCustomerSelectBox;
        private ComboBox countryCustomerSelectBox;
    }
}