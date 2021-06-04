using Microsoft.EntityFrameworkCore;
using Model;

namespace DataAccess
{
    public class MTellerDBContext : DbContext
    {
        public MTellerDBContext(DbContextOptions contextOptions) : base(contextOptions)
        { }

        public DbSet<CashIn> CashIns { get; set; }
        public DbSet<CashOut> CashOuts { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<OrganisationBranch> OrganisationBranchs { get; set; }
        public DbSet<AuditTrails> AuditTrails { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<BranchMerchantNumber> BranchMerchantNumbers { get; set; }
        public DbSet<AccountChartType> AccountChartTypes { get; set; }
        public DbSet<ChartOfAccount> ChartOfAccounts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<EntityType> EntityTypes { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Ledger> Ledgers { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
