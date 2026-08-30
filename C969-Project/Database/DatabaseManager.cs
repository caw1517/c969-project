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
                Conn = conn;          // assign only after a successful open
            }
            catch
            {
                conn.Dispose();
                Conn = null;          // never leave a dead object behind
                throw;                // let the caller decide what the user sees
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
                Conn = null;          // always
            }
        }

        public static List<CustomerDisplay> GetCustomers()
        {
            var customers = new List<CustomerDisplay>();

            string sql = @"
                            SELECT c.customerId, c.CustomerName, c.active, a.address, a.address2, a.postalCode, a.phone, ci.city, co.country
                            FROM customer c
                            JOIN address a ON c.addressId = a.addressId
                            JOIN city ci ON a.cityId = ci.cityId
                            JOIN country co ON co.countryId = ci.countryId
                            ORDER BY c.customerName";

            using (var cmd = new MySqlCommand(sql, Conn))
            using (var reader = cmd.ExecuteReader())
            {
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
                        Phone = reader.GetString("phone")
                    });
                }
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

            using (var cmd = new MySqlCommand(sql, Conn))
            {
                cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;

                using (var reader = cmd.ExecuteReader())
                {
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
            }
        }
    }
}