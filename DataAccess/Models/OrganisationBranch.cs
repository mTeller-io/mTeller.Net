using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    /// <summary>
    /// This object contains branches belonging to particular organization
    /// </summary>
    public class OrganisationBranch
    {
        //The identity primary key
        [Key]
        public int BranchId { get; set; }

        //The global identification id
        public Guid BranchUId { get; set; }

        //The user assigned branch code
        public string BranchCode { get; set; }

        //The Organization global unique id
        public Guid OrganizationUId { get; set; }

        //The name of the branch
        public string BranchName { get; set; }

        //The branch head user name
        public string BranchHeadUserName { get; set; }

        //The branch physical location address
        public string BranchAddress { get; set; }

        //The branch date of establishment
        public DateTime BranchDateOfEstablishment { get; set; }

        //The Assigned merchant account number of the branch
        public string BranchMerchantNumber { get; set; }

        //The host country of the branch
        public Guid Country { get; set; }

        //The host region of the branch
        public Guid Region { get; set; }

        //The host city of the branch
        public string City { get; set; }

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