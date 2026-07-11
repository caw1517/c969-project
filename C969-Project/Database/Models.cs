using System;
using System.Collections.Generic;
using System.Text;

namespace C969_Project.Database
{
    public abstract class AuditableModel
    {
        public DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; } = string.Empty;

        public DateTime UpdatedDate { get; set; }

        public string LastUpdatedBy { get; set; } = string.Empty;
    }

    public class Customer : AuditableModel
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public int AddressId { get; set; }

        public bool Active { get; set; }
    }
}
