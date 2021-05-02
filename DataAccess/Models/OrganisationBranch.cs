using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class OrganisationBranch
    {
        public Guid BranchId { get; set; }
        public Guid OrgId { get; set; }
        public string BranchName { get; set; }
        /// <summary>
        /// Must be TypeOf Employee Id
        /// </summary>
        public Guid BranchHeadId { get; set; }
        public DateTime BranchDateOfEstablishment { get; set; }
        public Guid Country { get; set; }
        public Guid Region { get; set; }
        public string City { get; set; }

    }
}
