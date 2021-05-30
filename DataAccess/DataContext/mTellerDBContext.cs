using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class mTellerDBContext : DbContext
    {
        public mTellerDBContext(DbContextOptions contextOptions) : base(contextOptions)
         { }
        DbSet<CashIn> CashIns { get; set; }
        DbSet<CashOut> CashOuts { get; set; }
        DbSet<Organisation> Organisations { get; set; }
        DbSet<OrganisationBranch> OrganisationBranchs { get; set; }
        DbSet<AuditTrails> AuditTrails {get;set;}
        DbSet<City> Cities {get;set;}
        DbSet<BranchMerchantNumber> BranchMerchantNumbers {get;set;}
        DbSet<AccountChartType> AccountChartTypes {get;set;}
        DbSet<ChartOfAccount> ChartOfAccounts { get; set; }
        DbSet<Country> Countries {get;set;}
        DbSet<EntityType> EntityTypes {get;set;}
        DbSet<Feature> Features {get;set;}
        DbSet<Ledger> Ledgers {get;set;}
        DbSet<Permission> Permissions {get;set;}
        DbSet<Region> Regions {get;set;}
        DbSet<Role> Roles{get;set;}
        DbSet<Town> Towns {get;set;}
        DbSet<User> Users {get;set;}

    }
}
