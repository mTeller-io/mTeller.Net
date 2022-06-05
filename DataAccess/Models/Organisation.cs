using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    /// <summary>
    /// This is contain details of the agent organization
    /// </summary>
    public class Organisation
    {
        //The identity primary key
        [Key]
        public int OrganizationId { get; set; }

        // The global guid primary key
        public Guid OrganizationUId { get; set; }

        //The name of the organization
        public string Name { get; set; }

        //The VAT identification Id of the organization
        public string VATId { get; set; }

        //The user specified business registration id
        public string BusinessRegistrationId { get; set; }

        //The business registration date of the organization
        public DateTime BusinessRegistrationDate { get; set; }

        //The names of the owners of the organization
        public List<string> Owners { get; set; }

        //The name of the appointed CEO
        public string CEOs { get; set; }

        //The country of origin of the business
        public int CountryOfOrigin { get; set; }

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