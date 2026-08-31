using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C969_Project.Database;
using C969_Project.Modules;
using MySql.Data.MySqlClient;

namespace C969_Project.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginFormLoginButton_Click(object sender, EventArgs e)
        {
            //Get the username and password, trim the username, password is evaluated as is
            string username = loginFormUsernameInput.Text.Trim();
            string password = loginFormPasswordInput.Text;

            if (!ValidateLoginInput(username, password))
            {
                return;
            };

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
                        "Invalid username or password",
                        "Error",
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
                    "Error connecting to the database.",
                    "Error",
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
                    "Username is required.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show(
                    "Password is required.",
                    "Error",
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
    }
}
