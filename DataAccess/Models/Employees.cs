using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Employees
    {
        public Guid Gender { get; set; }
        public Guid MaritalStatus { get; set; }
        public Guid Nationality { get; set; }
        public Guid EnployeeID { get; set; }
        public Guid AddressId { get; set; }
        public DateTime HiredDate { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string SSNITId { get; set; }
        public string TIN { get; set; }
        public string GhanaCardId { get; set; }
    }
}
