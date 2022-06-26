using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    /// <summary>
    /// The class for ledger records
    /// </summary>
    public class Ledger
    {
        //The primary key field
        [Key]
        public int LedgerId { get; set; }

        //The global unique field
        public Guid LedgerUId = Guid.NewGuid();

        //The account phone number
        public string AccountNumber { get; set; }

        //The amount
        public string Amount { get; set; }

        //The entry type ie credit or debit
        public char EntryType { get; set; }

        //The transaction type i.e cashin or cashout
        public string TransactionType { get; set; }

        //The value date
        public DateTime EntryDate { get; set; }

        //Narration
        public string Narration { get; set; }

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