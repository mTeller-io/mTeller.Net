using Business;
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
using Microsoft.OpenApi.Models;
using Service.Exceptions;
using Service.Extensions;
using System;

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

            services.AddTransient<IAppConfig, AppConfig>();

            /*  services.AddDbContext<mTellerDBContext>(options =>
          options.UseNpgsql(Configuration.GetConnectionString("mTellerContext")));  */

            // Register the Swagger Generator service. This service is responsible for genrating Swagger Documents.
            // Note: Add this service at the end after AddMvc() or AddMvcCore().
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "mTeller API",
                    Version = "v1",
                    Description = "The mTeller API shows the endpoints for accessing the mTeller functionalities.",
                    Contact = new OpenApiContact
                    {
                        Name = "mTeller",
                        Email = "mteller@mteller.io",
                        Url = new Uri("https://mteller.io/"),
                    },
                });
            });

            services.AddControllers()
                // .AddOData(opt => opt.EnableQueryFeatures().AddRouteComponents("api", GetEdmModel()))
                .AddOData(option => option.Select().Filter().OrderBy().Expand())
                .AddFluentValidation(s =>
                {
                    s.RegisterValidatorsFromAssemblyContaining<CashInValidator>();
                    s.DisableDataAnnotationsValidation = true;
                });

            /*   services.AddDbContext<mTellerContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("mTellerContext"))); */

            //Register our DB context
            //services.AddDbContextFactory<mTellerDBContext>(
            services.AddDbContext<mTellerDBContext>(
        options =>
            options.UseNpgsql(Configuration.GetConnectionString("NpgSqlConnectionString")
            , actions => actions.MigrationsAssembly("DataAccess")));

            //Register and tell Identity to use our DbContext for when we use its services
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

            //Register JwtSettings token
            services.Configure<JwtSettings>(Configuration.GetSection("Jwt"));

            // Register dependencies
            // services.AddScoped<IUserBusiness, UserBusiness>();
            services.RegisterDependencies();
        }

        /*  private static IEdmModel GetEdmModel()
         {
             ODataConventionModelBuilder modelBuilder = new();
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

            // app.UseAuthorization();

            // app.UseAuthentication();

            app.UseAuth();

            app.UseMiddleware(typeof(RequestErrorHandlerMiddleware));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}