using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DataAccess.Models;
using DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.AspNetCore.Identity;

namespace Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
          
            services.AddControllers();


            /*   services.AddDbContext<mTellerContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("mTellerContext"))); */

            //Register our DB context
            services.AddDbContextFactory<mTellerDBContext>(
        options =>
            options.UseNpgsql(Configuration.GetConnectionString("NpgSqlConnectionString"),actions=>actions.MigrationsAssembly("DataAccess")));
         
           //Register and tell Identity to use our DbContext for when we use its services
            services.AddIdentity<User,Role>(options=>{
                options.Password.RequiredLength =8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Lockout.DefaultLockoutTimeSpan= TimeSpan.FromMinutes(1d);
                options.Lockout.MaxFailedAccessAttempts =3;

            })
            .AddEntityFrameworkStores<mTellerDBContext>()
            .AddDefaultTokenProviders();
           
            
            //Automapper registering
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
