using System;
using System.Collections.Generic;
using System.Text;
using Google.Protobuf.WellKnownTypes;

namespace C969_Project.Database
{
    public abstract class AuditableModel
    {
        public DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; } = string.Empty;

        public DateTime LastUpdate { get; init; }

        public string LastUpdateBy { get; set; } = string.Empty;
    }

    public class Customer : AuditableModel
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public int AddressId { get; set; }

        public bool Active { get; set; }
    }

    public class Country : AuditableModel
    {
        public int CountryId { get; set; }

        public string CountryName { get; set; } = String.Empty;
    }

    public class City : AuditableModel
    {
        public int CityId { get; set; }

        public string CityName { get; set; } = string.Empty;

        public int CountryId { get; set; }
    }

    public class User : AuditableModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public bool Active { get; set; }
    }

    public class Address : AuditableModel
    {
        public int AddressId { get; set; }
        public string PrimaryAddress { get; set; } = string.Empty;
        public string Address2 { get; set; } = string.Empty;
        public int CityId { get; set; }
        public string PostalCode { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }

    public class Appointment : AuditableModel
    {
        public int AppointmentId { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}