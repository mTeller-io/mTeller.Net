using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class Employees
    {
        public Guid Gender { get; set; }
        public Guid MaritalStatus { get; set; }
        public Guid Nationality { get; set; }
        public Guid EnployeeID { get; set; }
        public DateTime HiredDate { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public PersonalContact Contact { get; set; }
    }
}
