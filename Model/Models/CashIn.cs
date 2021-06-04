using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    /// <summary>
    /// The CashIn  object. Capture transaction of recieving cash from customer
    /// </summary>
    public class CashIn
    {
        //The identity primary key
        public int CashInId {get;set;}
        //The guid identifier id to uniquely identify the record
        public Guid CashInUId { get; set; }
        //The entity type id
        public int EntitypeID {get;set;}
        //The default transaction type name
        public string TransactionType { get; set; } = nameof(Transaction.CASHIN);
        //The name of cash sender
        [Required]
        public string CustomerName { get; set; }
        //The phone number of cash sender
        [Required]
        public string CustomerPhoneNumber {get;set;}
        //The registered sim name of momo cashin payee number
        [Required]
        public string DepositorName { get; set; }
        // The registered sim  number of momo cashin payee
        [Required]
        public string DepositPhoneNumber { get; set; }
        // The cashin amount
        [Required]
        public double DepositAmount { get; set; }
        //True if sender pays charges
        [Required]
        public bool IsSendingChargePaidBySender { get; set; }
        //The amount of charges for sending cashin
        [Required]
        public double SendingCost { get; set; }
        //The date of transaction. This is auto set with format yyyy/MM/dd
        [Required]
        public string TransactionDate { get; set; }
        //The previous status value before the transation status
        [Required]
        public string LastStatus {get;set;}
        //The current status of the transaction
        [Required]
        public string Status {get;set;}
        //The history record of the transation
        public string History {get;set;}
        //The telecom network provider name of the receiver
        public string DepositPhoneNumberNetworkName {get;set;}
        //The telecom network provider name of the sender
        public string BranchMerchantNumberNetworkName {get;set;}
        // The merchant number sending the e-cash for the cashin
        public string BranchMerchantNumber {get;set;}
        //The branch code of the transaction
        public string BranchCode {get;set;}
        //The name of the user capturing the record
        public string CreateUserName {get;set;}
        //The date and time of the captured record. Auto set with format yyyy/MM//dd H:MM SSSS
        public DateTime CreateDateTime {get;set;}
        //The user name of last modification of the record
        public string ModifyUserName {get;set;}
        //The date and time last modification of the record
        public DateTime ModifyDateTime {get;set;}
        //The name of last process modifying the record
        public string LastProcessName {get;set;}

    
    }
}
