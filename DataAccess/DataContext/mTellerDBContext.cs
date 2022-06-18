using DataAccess.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

// using System.Collections.Generic;
// using System.Text;
// using System.Data.Entity.Core;

namespace DataAccess.DataContext
{
    public class mTellerDBContext : IdentityDbContext<User, Role, int>
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Set the default schema for postgres so it does not default to dbo which is for SQL Server
            modelBuilder.HasDefaultSchema("public");
        }

        private DbSet<CashIn> CashIns { get; set; }
        private DbSet<CashOut> CashOuts { get; set; }
        private DbSet<Organisation> Organisations { get; set; }
        private DbSet<OrganisationBranch> OrganisationBranchs { get; set; }
        private DbSet<AuditTrails> AuditTrails { get; set; }
        private DbSet<City> Cities { get; set; }
        private DbSet<BranchMerchantNumber> BranchMerchantNumbers { get; set; }
        private DbSet<AccountChartType> AccountChartTypes { get; set; }
        private DbSet<ChartOfAccount> ChartOfAccounts { get; set; }
        private DbSet<Country> Countries { get; set; }
        private DbSet<EntityType> EntityTypes { get; set; }
        private DbSet<Feature> Features { get; set; }
        private DbSet<Ledger> Ledgers { get; set; }
        private DbSet<Permission> Permissions { get; set; }
        private DbSet<Region> Regions { get; set; }
        public override DbSet<Role> Roles { get; set; }
        private DbSet<Town> Towns { get; set; }
        public override DbSet<User> Users { get; set; }
    }
}