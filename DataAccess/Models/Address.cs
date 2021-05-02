using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Address
    {
        public Guid AddressId { get; set; }
        public Guid EmployeeId { get; set; }
        public string MailingAddress { get; set; }
        public List<string> Email { get; set; }
        public string City { get; set; }
        public string GhanaPostCode { get; set; }
        public string MobileNumber { get; set; }
    }
}
