using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    /// <summary>
    /// The cash out object. Capture transation of giving cash out to customer
    /// </summary>
    public class CashOut
    {
        //The identity primary key
        [Key]
        public int CashOutId { get; set; }

        //The guid identifier id to uniquely identify the record
        public Guid CashOutUId { get; set; }

        //The entity type id
        public int EntitypeID { get; set; }

        //The default transaction type name
        public string TransactionType { get; set; } = "CASHOUT";

        //The name of cash sender
        public string CustomerName { get; set; }

        //The phone number of cash sender
        public string CustomerPhoneNumber { get; set; }

        //The registered sim name of momo cashin payee number
        public string WithdrawerName { get; set; }

        // The registered sim  number of momo cashin payee
        public string WithdrawerPhoneNumber { get; set; }

        // The identification type of the withdrawer
        public string WithdrawerIDType { get; set; }

        //The identification number
        public string WithdrawerIDNo { get; set; }

        // The cashOut amount
        public double Amount { get; set; }

        //True if sender pays charges
        public string ChargeRate { get; set; }

        //The amount of charges for sending cashin
        public double ChargeAmount { get; set; }

        //The date of transaction. This is auto set with format yyyy/MM/dd
        public string TransactionDate { get; set; }

        //The previous status value before the transation status
        public string PrevStatus { get; set; }

        //The current status of the transaction
        public string Status { get; set; }

        //The history record of the transation
        public string History { get; set; }

        //The telecom network provider name of the receiver
        public string WithdrawerNetworkName { get; set; }

        //The telecom network provider name of the sender
        public string BranchMerchantNumberNetworkName { get; set; }

        // The merchant number sending the e-cash for the cashin
        public string BranchMerchantNumber { get; set; }

        //The branch code of the transaction
        public string BranchCode { get; set; }

        //The name of the user capturing the transation
        public string CreateUserName { get; set; }

        //The date and time of the captured transaction. Auto set with format yyyy/MM//dd H:MM SSSS
        public DateTime CreateDateTime { get; set; }

        //The user name of last modification of the transaction
        public string ModifyUserName { get; set; }

        //The date and time last modification of the transaction
        public DateTime ModifyDateTime { get; set; }

        //The name of last process modifying the transaction
        public string LastProcessName { get; set; }
    }
}