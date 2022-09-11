using System;
using Business;
using Business.Interface;
using Business.Extensions;
using Business.Settings;
using Common;
using DataAccess.DataContext;
using DataAccess.Models;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Service.Extensions;



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
            var jwtSettings = Configuration.GetSection("Jwt").Get<JwtSettings>();
            services.AddAuth(jwtSettings);
            services.AddTransient<IAppConfig, AppConfig>();

            services.AddControllers()
               // .AddOData(opt => opt.EnableQueryFeatures().AddRouteComponents("api", GetEdmModel()))
                .AddOData(option=>option.Select().Filter().OrderBy().Expand())
                .AddFluentValidation(s =>
                {
                    s.RegisterValidatorsFromAssemblyContaining<CashInValidator>();
                    s.DisableDataAnnotationsValidation = true;
                });

            // Register our DB context
            // services.AddDbContextFactory<mTellerDBContext>(
            services.AddDbContext<mTellerDBContext>(options =>
            options.UseNpgsql(
                Configuration.GetConnectionString("NpgSqlConnectionString"), actions =>
                actions.MigrationsAssembly("DataAccess")));

            // Register and tell Identity to use our DbContext for when we use its services
            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1d);
                options.Lockout.MaxFailedAccessAttempts = 3;
            })
            .AddEntityFrameworkStores<mTellerDBContext>()
            .AddDefaultTokenProviders();

            // Register JwtSettings token
            services.Configure<JwtSettings>(Configuration.GetSection("Jwt"));

            // Register dependencies
            services.AddScoped<IUserBusiness, UserBusiness>();
            services.RegisterDependencies();
        }

       /*  private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<CashIn>("CashIns");
            modelBuilder.EntitySet<CashOut>("CashOuts");
            IEdmModel model = modelBuilder.GetEdmModel();

            return model;
        } */

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "mTeller API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuth();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}