using System;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


// using System.Collections.Generic;
// using System.Text;
// using System.Data.Entity.Core;

namespace DataAccess.DataContext
{
    public class mTellerDBContext : IdentityDbContext<User, Role,int> 
    {

        public mTellerDBContext(DbContextOptions contextOptions) : base(contextOptions)
        {
           

        }

        // private readonly string _connectionString;

        // public mTellerDBContext(string connectionString)
        // {
        //     _connectionString = connectionString;
        // }

        //  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //     => optionsBuilder.UseNpgsql(_connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

             base.OnModelCreating(modelBuilder);
            //Set the default schema for postgres so it does not default to dbo which is for SQL Server
            modelBuilder.HasDefaultSchema("public");

        }
   
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
        public override DbSet<Role> Roles{get;set;}
        DbSet<Town> Towns {get;set;}
        public override DbSet<User> Users {get;set;}

    }
}
