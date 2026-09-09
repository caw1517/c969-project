using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using Microsoft.VisualBasic.ApplicationServices;

namespace C969_Project.Database
{
    public class DatabaseManager
    {
        public static MySqlConnection? Conn { get; set; }

        public static void StartConnection()
        {
            if (Conn is { State: ConnectionState.Open })
            {
                return;
            }

            EndConnection();

            string connectionString = ConfigurationManager.ConnectionStrings["localDb"].ConnectionString;

            var conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                Conn = conn; // assign only after a successful open
            }
            catch
            {
                conn.Dispose();
                Conn = null; // never leave a dead object behind
                throw; // let the caller decide what the user sees
            }
        }

        public static void EndConnection()
        {
            try
            {
                Conn?.Dispose();
            }
            catch (MySqlException)
            {
                // nothing useful a user can do about a failed close
            }
            finally
            {
                Conn = null; // always
            }
        }

        public static List<CustomerDisplay> GetCustomers()
        {
            var customers = new List<CustomerDisplay>();

            string sql = @"
                            SELECT c.customerId, a.addressId, ci.cityId, co.countryId, c.customerName, c.active, a.address, a.address2, a.postalCode, a.phone, ci.city, co.country
                            FROM customer c
                            JOIN address a ON c.addressId = a.addressId
                            JOIN city ci ON a.cityId = ci.cityId
                            JOIN country co ON co.countryId = ci.countryId
                            ORDER BY c.customerName";

            using var cmd = new MySqlCommand(sql, Conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                customers.Add(new CustomerDisplay
                {
                    CustomerId = reader.GetInt32("customerId"),
                    CustomerName = reader.GetString("customerName"),
                    Active = reader.GetBoolean("active"),
                    Address = reader.GetString("address"),
                    Address2 = reader.GetString("address2"),
                    PostalCode = reader.GetString("postalCode"),
                    City = reader.GetString("city"),
                    Country = reader.GetString("country"),
                    Phone = reader.GetString("phone"),
                    AddressId = reader.GetInt32("addressId"),
                    CityId = reader.GetInt32("cityId"),
                    CountryId = reader.GetInt32("countryId"),
                });
            }

            return customers;
        }

        public static User? AuthenticateUser(string username, string password)
        {
            const string sql = @"
                            SELECT userId, userName, active
                            FROM `user`
                            WHERE userName = @username
                                AND password = @password
                                AND active = 1
                            LIMIT 1";

            using var cmd = new MySqlCommand(sql, Conn);
            cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;

            using var reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                return null;
            }

            return new User
            {
                UserId = reader.GetInt32("userId"),
                UserName = reader.GetString("userName"),
                Active = reader.GetBoolean("active")
            };
        }

        public static List<Country>? GetCountryList()
        {
            var countryList = new List<Country>();

            string sql = @"SELECT countryId, country
                            FROM country
                            ORDER BY country";

            using var cmd = new MySqlCommand(sql, Conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                countryList.Add(new Country()
                {
                    CountryId = reader.GetInt32("countryId"),
                    CountryName = reader.GetString("country")
                });
            }

            if (countryList.Count == 0)
                return null;

            return countryList;
        }

        public static List<City>? GetCityByCountry(int countryId)
        {
            var cityList = new List<City>();

            string sql = @"SELECT cityId, city AS cityName
                            FROM city
                            WHERE countryId = @countryId
                            ORDER BY city";

            using var cmd = new MySqlCommand(sql, Conn);
            cmd.Parameters.Add("@countryId", MySqlDbType.Int32).Value = countryId;

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cityList.Add(new City()
                {
                    CityId = reader.GetInt32("cityId"),
                    CityName = reader.GetString("cityName"),
                });
            }

            if (cityList.Count == 0)
                return null;

            return cityList;
        }

        public static void AddCustomer(Customer customer, Address address)
        {
            var connection = Conn;

            if (connection == null || connection.State != ConnectionState.Open)
                throw new InvalidOperationException("The database connection is not open.");

            var createdAt = DateTime.UtcNow;
            var createdBy = Session.CurrentUserName;

            using var transaction = connection.BeginTransaction();

            try
            {
                const string addressSql = @"
            INSERT INTO address
                (address, address2, cityId, postalCode, phone,
                 createDate, createdBy, lastUpdateBy)
            VALUES
                (@address, @address2, @cityId, @postalCode, @phone,
                 @createDate, @createdBy, @lastUpdateBy)";

                using var addressCmd =
                    new MySqlCommand(addressSql, connection, transaction);

                addressCmd.Parameters.Add("@address", MySqlDbType.VarChar).Value =
                    address.PrimaryAddress;
                addressCmd.Parameters.Add("@address2", MySqlDbType.VarChar).Value =
                    address.Address2 ?? string.Empty;
                addressCmd.Parameters.Add("@cityId", MySqlDbType.Int32).Value =
                    address.CityId;
                addressCmd.Parameters.Add("@postalCode", MySqlDbType.VarChar).Value =
                    address.PostalCode;
                addressCmd.Parameters.Add("@phone", MySqlDbType.VarChar).Value =
                    address.Phone;
                addressCmd.Parameters.Add("@createDate", MySqlDbType.DateTime).Value =
                    createdAt;
                addressCmd.Parameters.Add("@createdBy", MySqlDbType.VarChar).Value =
                    createdBy;
                addressCmd.Parameters.Add("@lastUpdateBy", MySqlDbType.VarChar).Value =
                    createdBy;

                addressCmd.ExecuteNonQuery();

                int addressId = checked((int)addressCmd.LastInsertedId);

                const string customerSql = @"
            INSERT INTO customer
                (customerName, addressId, active,
                 createDate, createdBy, lastUpdateBy)
            VALUES
                (@customerName, @addressId, @active,
                 @createDate, @createdBy, @lastUpdateBy)";

                using var customerCmd =
                    new MySqlCommand(customerSql, connection, transaction);

                customerCmd.Parameters.Add("@customerName", MySqlDbType.VarChar).Value =
                    customer.CustomerName;
                customerCmd.Parameters.Add("@addressId", MySqlDbType.Int32).Value =
                    addressId;
                customerCmd.Parameters.Add("@active", MySqlDbType.Int32).Value =
                    customer.Active ? 1 : 0;
                customerCmd.Parameters.Add("@createDate", MySqlDbType.DateTime).Value =
                    createdAt;
                customerCmd.Parameters.Add("@createdBy", MySqlDbType.VarChar).Value =
                    createdBy;
                customerCmd.Parameters.Add("@lastUpdateBy", MySqlDbType.VarChar).Value =
                    createdBy;

                customerCmd.ExecuteNonQuery();

                transaction.Commit();
            }
            catch
            {
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollbackError)
                {
                    System.Diagnostics.Debug.WriteLine(rollbackError);
                }

                throw;
            }
        }

        public static void DeleteCustomer(int customerId, int addressId)
        {
            var connection = Conn;

            if (connection == null || connection.State != ConnectionState.Open)
                throw new InvalidOperationException("The database connection is not open.");

            using var transaction = connection.BeginTransaction();

            try
            {
                string deleteCustomerSql = @"DELETE FROM customer WHERE customerId = @customerId";
                string deleteAddressSql = @"DELETE FROM address WHERE addressId = @addressId";

                using var deleteCustomerCmd = new MySqlCommand(deleteCustomerSql, connection, transaction);
                deleteCustomerCmd.Parameters.Add("@customerId", MySqlDbType.Int32).Value = customerId;

                deleteCustomerCmd.ExecuteNonQuery();

                using var deleteAddressCmd = new MySqlCommand(deleteAddressSql, connection, transaction);
                deleteAddressCmd.Parameters.Add("@addressId", MySqlDbType.Int32).Value = addressId;

                deleteAddressCmd.ExecuteNonQuery();

                transaction.Commit();

            }
            catch
            {
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollbackError)
                {
                    System.Diagnostics.Debug.WriteLine(rollbackError);
                }

                throw;
            }
        }
    }
}