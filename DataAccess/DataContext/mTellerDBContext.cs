using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class mTellerDBContext : DbContext
    {
        public mTellerDBContext(DbContextOptions contextOptions) : base(contextOptions) { }
        DbSet<CashIn> CashIn { get; set; }
        DbSet<CashOut> CashOut { get; set; }
        DbSet<Organisation> Organisation { get; set; }
        DbSet<OrganisationBranch> OrganisationBranch { get; set; }
        DbSet<AuditTrails> AuditTrails {get;set;}
        DbSet<City> City {get;set;}
        DbSet<BranchMerchantNumber> BranchMerchantNumber {get;set;}
    }
}
