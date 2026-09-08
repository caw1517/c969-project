using C969_Project.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace C969_Project.Forms
{
    public partial class CustomerForm : Form
    {
        private CustomerDisplay? _customer;
        Country activeCountry = null;

        private readonly CustomerFormType _formType;


        //Default - Add new Customer
        public CustomerForm()
        {
            InitializeComponent();
            _formType = CustomerFormType.Add;
            this.Text = @"Add new customer";

            SetupCityCountryDropDowns();
        }

        //Edit the customer - fill in text boxes with existing data
        public CustomerForm(CustomerDisplay customer)
        {
            InitializeComponent();
            _customer = customer;
            _formType = CustomerFormType.Edit;
            this.Text = @"Edit Customer";
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
                //cityEditCustomerTextBox.Text = _customer.City;
                postalEditCustomerTextBox.Text = _customer.PostalCode;
                //countryEditCustomerTextBox.Text = _customer.Country;
                activeEditCustomerCheckBox.Checked = _customer.Active;
            }
        }

        private void saveEditCustomerButton_Click(object sender, EventArgs e)
        {
            var validationErrors = ValidateCustomerInput();

            if (validationErrors.Any())
            {
                MessageBox.Show(string.Join("\n", validationErrors), @"Please fix the following.", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            if (_formType == CustomerFormType.Add)
            {
            }
            else if (_formType == CustomerFormType.Edit)
            {
            }
        }

        private List<string> ValidateCustomerInput()
        {
            List<string> validationErrors = new List<string>();

            if (string.IsNullOrWhiteSpace(nameEditCustomerTextBox.Text))
                validationErrors.Add("Customer name must not be empty.");

            if (string.IsNullOrWhiteSpace(phoneEditCustomerTextBox.Text))
                validationErrors.Add("Phone number must not be empty.");

            var phone = phoneEditCustomerTextBox.Text.Trim();

            if (phone.Length > 0 && !Regex.IsMatch(phone, @"\A[0-9-]*[0-9][0-9-]*\z"))
            {
                validationErrors.Add("Phone number must contain only digits and dashes.");
            }

            if (string.IsNullOrWhiteSpace(addressEditCustomerTextBox.Text))
                validationErrors.Add("Customer address must not be empty.");

            //if(string.IsNullOrWhiteSpace(cityEditCustomerTextBox.Text))
            //    validationErrors.Add("City must not be empty.");

            if (string.IsNullOrWhiteSpace(postalEditCustomerTextBox.Text))
                validationErrors.Add("Postal code must not be empty.");

            //if(string.IsNullOrWhiteSpace(countryEditCustomerTextBox.Text))
            //    validationErrors.Add("Country must not be empty.");

            return validationErrors;
        }

        private void SetupCityCountryDropDowns()
        {
            List<Country>? countries = DatabaseManager.GetCountryList();
            List<City>? cities;

            if (countries != null)
            {
                countryCustomerSelectBox.DisplayMember = "CountryName";
                countryCustomerSelectBox.ValueMember = "CountryId";
                countryCustomerSelectBox.DataSource = countries;
                countryCustomerSelectBox.SelectedIndex = -1;

                countryCustomerSelectBox.SelectedIndexChanged += countryCustomerSelectBox_SelectedIndexChanged;

            }
        }

        private void countryCustomerSelectBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            cityCustomerSelectBox.DataSource = null;

            if (countryCustomerSelectBox.SelectedValue is int countryId)
            {
                cityCustomerSelectBox.DisplayMember = "CityName";
                cityCustomerSelectBox.ValueMember = "CityId";
                cityCustomerSelectBox.DataSource = DatabaseManager.GetCityByCountry(countryId);
            }

            cityCustomerSelectBox.SelectedIndex = -1;
        }
    }
}