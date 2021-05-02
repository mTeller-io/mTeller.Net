using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class MTellerContext : DbContext
    {
        public MTellerContext(DbContextOptions contextOptions) : base(contextOptions) { }
        DbSet<CashIn> CashIns { get; set; }
        DbSet<CashOut> CashOuts { get; set; }
        DbSet<Employees> Employees { get; set; }
        DbSet<Organisation> Organisations { get; set; }
        DbSet<OrganisationBranch> OrganisationBranches { get; set; }
        
    }
}
