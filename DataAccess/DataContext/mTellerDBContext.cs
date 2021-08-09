using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
// using System.Collections.Generic;
// using System.Text;
// using System.Data.Entity.Core;

namespace DataAccess.DataContext
{
    public class mTellerDBContext : DbContext
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
            //Set the default schema for postgres so it does not default to dbo which is for SQL Server
            modelBuilder.HasDefaultSchema("public");

       
        }
   
        public DbSet<CashIn> CashIns { get; set; }
        public DbSet<CashOut> CashOuts { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<OrganisationBranch> OrganisationBranchs { get; set; }
        public DbSet<AuditTrails> AuditTrails {get;set;}
        public DbSet<City> Cities {get;set;}
        public DbSet<BranchMerchantNumber> BranchMerchantNumbers {get;set;}
        public DbSet<AccountChartType> AccountChartTypes {get;set;}
        public DbSet<ChartOfAccount> ChartOfAccounts { get; set; }
        public DbSet<Country> Countries {get;set;}
        public DbSet<EntityType> EntityTypes {get;set;}
        public DbSet<Feature> Features {get;set;}
        public DbSet<Ledger> Ledgers {get;set;}
        public DbSet<Permission> Permissions {get;set;}
        public DbSet<Region> Regions {get;set;}
        public DbSet<Role> Roles{get;set;}
        public DbSet<Town> Towns {get;set;}
        public DbSet<User> Users {get;set;}

    }
}
