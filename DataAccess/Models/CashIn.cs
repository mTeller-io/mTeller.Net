using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    /// <summary>
    /// The CashIn  object. Capture transaction of recieving cash from customer
    /// </summary>
    public class CashIn
    {
        //The identity primary key
        [Key]
        public int CashInId { get; set; }

        //The guid identifier id to uniquely identify the record
        public Guid CashInUId { get; set; }

        //The entity type id
        public int EntitypeID { get; set; }

        //The default transaction type name
        public string TransactionType { get; set; } = "CASHIN";

        //The name of cash sender
        public string DepositorName { get; set; }

        //The phone number of cash sender
        public string DepositorContactNo { get; set; }

        //The registered sim name of momo cashin payee number
        public string AccountName { get; set; }

        // The registered sim  number of momo cashin payee
        public string AccountNumber { get; set; }

        // The cashin amount
        public decimal Amount { get; set; }

        //True if sender pays charges
        public bool IsSendingChargePaidBySender { get; set; }

        //The amount of charges for sending cashin
        public decimal SendingCost { get; set; }

        //The date of transaction. This is auto set with format yyyy/MM/dd
        public string TransactionDate { get; set; }

        //The previous status value before the transation status
        public string lastStatus { get; set; }

        //The current status of the transaction
        public string Status { get; set; }

        //The history record of the transation
        public string History { get; set; }

        //The telecom network provider name of the receiver
        public string AccountNetworkName { get; set; }

        //The telecom network provider name of the sender
        public string BranchAccountNetworkName { get; set; }

        // The merchant number sending the e-cash for the cashin
        public string BranchAccountNumber { get; set; }

        //The branch code of the transaction
        public string BranchCode { get; set; }

        //The name of the user capturing the record
        public string CreateUserName { get; set; }

        //The date and time of the captured record. Auto set with format yyyy/MM//dd H:MM SSSS
        public DateTime CreateDateTime { get; set; }

        //The user name of last modification of the record
        public string ModifyUserName { get; set; }

        //The date and time last modification of the record
        public DateTime? ModifyDateTime { get; set; }

        //The name of last process modifying the record
        public string LastProcessName { get; set; }

        // The note entered by payer for reference
        public string PayerNote { get; set; }

        // The note endterd by payer for payee reference
        public string PayeeNote { get; set; }

        //
        public string ExternalId { get; set; }

        // Indicate either is cell phone number or other number
        public string PartyIdType { get; set; }

        // The currency of the customer account
        public string Currency { get; set; }
    }
}