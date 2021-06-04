using System;
using Model;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Business
{
    public class OrganisationProcessor : ProcessorBase<Organisation>
    {
        public OrganisationProcessor(IMteller mTeller) : base(mTeller)
        {}
    }
}
