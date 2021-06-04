using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    /// <summary>
    /// This object contains branches belonging to particular organization
    /// </summary>
    public class OrganisationBranch
    {
        //The identity primary key
        public int BranchId { get; set; }
        //The global identification id
        public Guid BranchUId {get;set;}
        //The user assigned branch code
        [Required]
        public string BranchCode {get;set;}
        //The Organization global unique id
        public Guid OrganizationUId { get; set; }
        //The name of the branch
        [Required]
        public string BranchName { get; set; }
        //The branch head user name
        [Required]
        public string BranchHeadUserName { get; set; }
        //The branch physical location address
        [Required]
        public string BranchAddress {get;set;}
        //The branch date of establishment
        [Required]
        public DateTime BranchDateOfEstablishment { get; set; }
        //The Assigned merchant account number of the branch
        [Required]
        public string BranchMerchantNumber {get;set;}
        //The host country of the branch
        [Required]
        public Guid CountryUId { get; set; }
        //The host region of the branch
        [Required]
        public Guid RegionUId { get; set; }
        //The host city of the branch
        [Required]
        public string City { get; set; }
         //The name of the user capturing the record
        public string CreateUserName {get;set;}
        //The date and time of the captured record. Auto set with format yyyy/MM//dd H:MM SSSS
        public DateTime CreateDateTime {get;set;}
        //The user name of last modification of the record
        public string ModifyUserName {get;set;}
        //The date and time last modification of the record
        public DateTime ModifyDateTime {get;set;}

    }
}
