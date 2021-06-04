using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    /// <summary>
    /// The class for ledger records
    /// </summary>
    public class Ledger
    {
        //The primary key field
        public int LedgerId { get; set; }
        //The global unique field
        public Guid LedgerUId = Guid.NewGuid();
        //The account phone number
        [Required]
        public string AccountNumber { get; set; }
        //The amount
        [Required]
        public string Amount { get; set; }
        //The entry type ie credit or debit
        [Required]
        public char EntryType { get; set; }
        //The transaction type i.e cashin or cashout
        [Required]
        public string TransactionType { get; set; }
        //The value date
        [Required]
        public DateTime EntryDate { get; set; }
        //Narration 
        [Required]
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