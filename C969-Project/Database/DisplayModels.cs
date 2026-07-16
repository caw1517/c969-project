using System;
using System.Collections.Generic;
using System.Text;

namespace C969_Project.Database
{
    public class CustomerDisplay
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string Address2 { get; set; } = string.Empty;

        //Lambda - Consider using this as one of the 3 required
        public string FullAddress =>
            string.IsNullOrWhiteSpace(Address2) ? Address : $"{Address}, {Address2}";

        public string City { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string PostalCode { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public bool Active { get; set; }
    }
}
