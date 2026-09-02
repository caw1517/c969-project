using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using C969_Project.Database;
using C969_Project.Modules;
using C969_Project.Resources;
using MySql.Data.MySqlClient;

namespace C969_Project.Forms
{
    public partial class LoginForm : Form
    {

        private readonly string localTimeZoneDisplayName = TimeZoneInfo.Local.DisplayName;
        private bool isInitializingLanguage;


        public LoginForm()
        {

            InitializeComponent();
            loginFormTimeZoneLabel.Text = $"{LoginStrings.LocationLabel}: {localTimeZoneDisplayName}";
            ApplyLocalizedStrings();
            SetLanguageOptions();
        }

        private void loginFormLoginButton_Click(object sender, EventArgs e)
        {
            //Get the username and password, trim the username, password is evaluated as is
            string username = loginFormUsernameInput.Text.Trim();
            string password = loginFormPasswordInput.Text;

            if (!ValidateLoginInput(username, password))
            {
                return;
            }
            ;

            try
            {
                if (DatabaseManager.Conn?.State != ConnectionState.Open)
                {
                    DatabaseManager.StartConnection();
                }

                //Authenticate the user
                User? authenticatedUser = DatabaseManager.AuthenticateUser(username, password);
                if (authenticatedUser is null)
                {
                    MessageBox.Show(
                        LoginStrings.InvalidCredentials,
                        LoginStrings.ErrorTitle,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                //Start the session and log the login
                Session.Start(authenticatedUser.UserName, authenticatedUser.UserId);
                LoginHistoryModule.RecordLogin(authenticatedUser.UserName);
                DialogResult = DialogResult.OK;
            }
            catch (Exception)
            {
                MessageBox.Show(
                    LoginStrings.DatabaseError,
                    LoginStrings.ErrorTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Session.Clear();
                DatabaseManager.EndConnection();
            }

        }

        private bool ValidateLoginInput(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show(
                    LoginStrings.UsernameRequired,
                    LoginStrings.ErrorTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show(
                    LoginStrings.PasswordRequired,
                    LoginStrings.ErrorTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;

            }

            return true;
        }

        private void loginFormCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ApplyLocalizedStrings()
        {
            Text = LoginStrings.FormTitle;
            loginFormHeaderLabel.Text = LoginStrings.HeaderTitle;
            loginFormHeaderSubLabel.Text = LoginStrings.HeaderSubtitle;
            loginGroupBox.Text = LoginStrings.LocationLanguageGroup;
            loginFormUsernameLabel.Text = LoginStrings.UsernameLabel;
            loginFormPasswordLabel.Text = LoginStrings.PasswordLabel;
            loginFormLoginButton.Text = LoginStrings.LoginButton;
            loginFormCancelButton.Text = LoginStrings.CancelButton;
            loginFormOfficeLabel.Text = LoginStrings.OfficeLabel;
            loginFormLanguageLabel.Text = LoginStrings.LanguageLabel;
        }

        private class LanguageSelection
        {
            public string Name { get; set; }
            public string LanguageCode { get; set; }
        }

        List<LanguageSelection> languages = new List<LanguageSelection>
        {
            new LanguageSelection {Name = "English", LanguageCode = "en"},
            new LanguageSelection {Name = "Deutsch", LanguageCode = "de"},
        };

        private void SetLanguageOptions()
        {
            loginFormLanguageComboBox.DataSource = languages;
            loginFormLanguageComboBox.DisplayMember = "Name";
            loginFormLanguageComboBox.ValueMember = "LanguageCode";

            string currentLanguage = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

            LanguageSelection initialSelection =
                languages.FirstOrDefault(language => language.LanguageCode == currentLanguage) ?? languages[0];

            isInitializingLanguage = true;
            try
            {
                loginFormLanguageComboBox.DataSource = languages;
                loginFormLanguageComboBox.DisplayMember = "Name";
                loginFormLanguageComboBox.ValueMember = "LanguageCode";
                loginFormLanguageComboBox.SelectedItem = initialSelection;
            }
            finally
            {
                isInitializingLanguage = false;
            }

        }

        private void loginFormLanguageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loginFormLanguageComboBox.SelectedItem is LanguageSelection selectedLanguage)
            {
                CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo(selectedLanguage.LanguageCode);
                CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo(selectedLanguage.LanguageCode);
                ApplyLocalizedStrings();
            }
        }
    }
}
