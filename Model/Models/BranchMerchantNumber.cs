using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    /// <summary>
    /// This is contain details of the agent organization
    /// </summary>
    public class BranchMerchantNumber
    {
        //The identity primary key
        public int   BranchMerchantNumberId {get;set;}
        //The global guid key
        public Guid BranchMerchantNumberUId = Guid.NewGuid();
        //The Merchant Account Number
        [Required]
        public string MerchantPhoneNumber { get; set; }
        //The Network Provider Name
        [Required]
        public string NetworkProviderName {get;set;}
        //The status
        [Required]
        public string Status {get;set;}
        //The branch Code
        [Required]
        public string BranchCode {get;set;}
        //The organization global indentyty
        public Guid OrganizationUId {get;set;}
        //The name of the user capturing the record
        [Required]
        public string CreateUserName {get;set;}
        //The date and time of the captured record. Auto set with format yyyy/MM//dd H:MM SSSS
        [Required]
        public DateTime CreateDateTime {get;set;}
        //The user name of last modification of the record
        [Required]
        public string ModifyUserName {get;set;}
        //The date and time last modification of the record
        [Required]
        public DateTime ModifyDateTime {get;set;}


    }
}