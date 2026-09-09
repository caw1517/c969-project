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
            SetupCityCountryDropDowns();
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
                postalEditCustomerTextBox.Text = _customer.PostalCode;
                activeEditCustomerCheckBox.Checked = _customer.Active;
                countryCustomerSelectBox.SelectedValue = _customer.CountryId;
                cityCustomerSelectBox.SelectedValue = _customer.CityId;
            }
        }

        private void saveEditCustomerButton_Click(object sender, EventArgs e)
        {
            TrimInput();
            var validationErrors = ValidateCustomerInput();

            if (validationErrors.Any())
            {
                MessageBox.Show(string.Join("\n", validationErrors), @"Please fix the following.", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (_formType == CustomerFormType.Add)
            {
                var customerToAdd = new Customer
                {
                    CustomerName = nameEditCustomerTextBox.Text,
                    Active = activeEditCustomerCheckBox.Checked
                };

                var addressToAdd = new Address
                {
                    PrimaryAddress = addressEditCustomerTextBox.Text,
                    Address2 = address2EditCustomerTextBox.Text,
                    CityId = (int)cityCustomerSelectBox.SelectedValue,
                    PostalCode = postalEditCustomerTextBox.Text,
                    Phone = phoneEditCustomerTextBox.Text
                };

                try
                {
                    DatabaseManager.AddCustomer(customerToAdd, addressToAdd);
                    DialogResult = DialogResult.OK;
                }
                catch
                {
                    MessageBox.Show(
                        "Unable to add the customer. No changes were saved.\n\n" +
                        "Please check your database connection and try again. " +
                        "If the problem continues, contact support.",
                        "Add Customer Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else if (_formType == CustomerFormType.Edit)
            {
            }
        }

        private void TrimInput()
        {
            nameEditCustomerTextBox.Text = nameEditCustomerTextBox.Text.Trim();
            phoneEditCustomerTextBox.Text = phoneEditCustomerTextBox.Text.Trim();
            addressEditCustomerTextBox.Text = addressEditCustomerTextBox.Text.Trim();
            address2EditCustomerTextBox.Text = address2EditCustomerTextBox.Text.Trim();
            postalEditCustomerTextBox.Text = postalEditCustomerTextBox.Text.Trim();
        }

        private List<string> ValidateCustomerInput()
        {
            var errors = new List<string>();

            string name = nameEditCustomerTextBox.Text;
            string phone = phoneEditCustomerTextBox.Text;
            string address = addressEditCustomerTextBox.Text;
            string address2 = address2EditCustomerTextBox.Text;
            string postalCode = postalEditCustomerTextBox.Text;

            // Required fields
            if (string.IsNullOrWhiteSpace(name))
                errors.Add("Enter a customer name.");

            if (string.IsNullOrWhiteSpace(address))
                errors.Add("Enter a primary address.");

            if (string.IsNullOrWhiteSpace(phone))
                errors.Add("Enter a phone number.");

            if (string.IsNullOrWhiteSpace(postalCode))
                errors.Add("Enter a postal code.");

            if (countryCustomerSelectBox.SelectedValue is not int)
                errors.Add("Select a country.");

            if (cityCustomerSelectBox.SelectedValue is not int)
                errors.Add("Select a city.");

            // Fixed database column limits
            if (name.Length > 45)
                errors.Add("Customer name must be 45 characters or fewer.");

            if (address.Length > 50)
                errors.Add("Primary address must be 50 characters or fewer.");

            if (address2.Length > 50)
                errors.Add("Address line 2 must be 50 characters or fewer.");

            if (postalCode.Length > 10)
                errors.Add("Postal code must be 10 characters or fewer.");

            if (phone.Length > 20)
                errors.Add("Phone number must be 20 characters or fewer.");

            // Skip empty phone values because the required-field check handles them.
            if (phone.Length > 0 &&
                !Regex.IsMatch(phone, @"\A[0-9-]+\z"))
            {
                errors.Add("Phone number may contain only digits (0–9) and dashes (-).");
            }

            return errors;
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