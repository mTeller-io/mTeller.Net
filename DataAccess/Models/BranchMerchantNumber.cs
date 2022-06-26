using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    /// <summary>
    /// This is contain details of the agent organization
    /// </summary>
    public class BranchMerchantNumber
    {
        //The identity primary key
        [Key]
        public int BranchMerchantNumberId { get; set; }

        //The global guid key
        public Guid BranchMerchantNumberUId = Guid.NewGuid();

        //The Merchant Account Numbe
        public string MerchantPhoneNumber { get; set; }

        //The Network Provider Name
        public string NetworkProviderName { get; set; }

        //The status
        public string Status { get; set; }

        //The branch Code
        public string BranchCode { get; set; }

        //The organization global indentyty
        public Guid OrganizationUId { get; set; }

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