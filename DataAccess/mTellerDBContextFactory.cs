using DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DataAccess
{
    /// <summary>
    /// This class needed for creating dbcontext instance at design for migration purpose
    /// </summary>
    public class mTellerDBContextFactory : IDesignTimeDbContextFactory<mTellerDBContext>
    {
        public mTellerDBContext CreateDbContext(string[] args)
        {
            //Add configuration setting file
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            //Create instance of context builder
            var dbContextBuilder = new DbContextOptionsBuilder<mTellerDBContext>();
            // Read postgres connection string section of the appsettings configuration file
            var connetionString = configuration.GetConnectionString("NpgSqlConnectionString");
            //pass set connection option of dbcontextbuilder
            dbContextBuilder.UseNpgsql(connetionString);
            //Return new instance of mTellerDBContext for migration
            return new mTellerDBContext(dbContextBuilder.Options);
        }
    }
}