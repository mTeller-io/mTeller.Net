using System;
using System.IO;
using System.Text;
using System.Configuration;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Npgsql.EntityFrameworkCore.PostgreSQL.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using DataAccess.DataContext;

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
         