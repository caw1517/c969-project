using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace C969_Project.Database
{
    public class DatabaseManager
    {
        public static MySqlConnection Conn { get; set; }

        public static void StartConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["localDb"].ConnectionString;


            try
            {
                Conn = new MySqlConnection(connectionString);

                Conn.Open();

                MessageBox.Show("Connected to Database");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void EndConnection()
        {
            try
            {
                if (Conn != null)
                {
                    Conn.Close();
                }

                Conn = null;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
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
    }
}