using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    /// <summary>
    /// The chart of account of the business for book keeping purpose
    /// </summary>
    public class ChartOfAccount
    {
        //Auto increment primary key
        [Key]
        public int ChartOfAccountId { get; set; }

        //Global unique key
        public Guid ChartOfAccountUId { get; set; } = Guid.NewGuid();

        //Account Number
        public string AccountNumber { get; set; }

        //Account Type
        public string AccountType { get; set; }

        //Domicile branch
        public string BranchCode { get; set; }

        //Account balance
        public decimal Balance { get; set; }

        //The name of the user capturing the record
        public string CreateUserName { get; set; }

        //The date and time of the captured record. Auto set with format yyyy/MM//dd H:MM SSSS
        public DateTime CreateDateTime { get; set; }

        //The user name of last modification of the record
        public string ModifyUserName { get; set; }

        //The date and time last modification of the record
        public DateTime ModifyDateTime { get; set; }
    }
}