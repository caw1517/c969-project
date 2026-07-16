using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C969_Project.Database;

namespace C969_Project.Forms
{
    public partial class CustomerForm : Form
    {

        private CustomerDisplay _customer;
        //Default - Add new Customer
        public CustomerForm()
        {
            InitializeComponent();
        }

        //Edit the customer - fill in text boxes with existing data
        public CustomerForm(CustomerDisplay customer)
        {
            InitializeComponent();
            _customer = customer;
        }

        private void cancelEditCustomerButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            //If the customer is populated then we are editing
            if (_customer != null)
            {
                nameEditCustomerTextBox.Text = _customer.CustomerName;
                phoneEditCustomerTextBox.Text = _customer.Phone;
                addressEditCustomerTextBox.Text = _customer.Address;
                address2EditCustomerTextBox.Text = _customer.Address2;
                cityEditCustomerTextBox.Text = _customer.City;
                postalEditCustomerTextBox.Text = _customer.PostalCode;
                countryEditCustomerTextBox.Text = _customer.Country;
                activeEditCustomerCheckBox.Checked = _customer.Active;
            }
        }
    }
}
