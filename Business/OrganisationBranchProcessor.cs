using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model;

namespace Business
{
    public class OrganisationBranchProcessor : ProcessorBase<OrganisationBranch>
    {
        public OrganisationBranchProcessor(IMteller mTeller) : base(mTeller)
        { }
    }
}
