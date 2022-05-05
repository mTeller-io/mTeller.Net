using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DataAccess.Models;
using DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Business;
using Business.Interface;
using Microsoft.OpenApi.Models;
using Business.Settings;
using Business.Extensions;
using DataAccess.Repository;
using Common;


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
          
            services.AddControllers();

            services.AddAuth(jwtSettings);

            services.AddTransient<IAppConfig,AppConfig>();
            
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

            /*   services.AddDbContext<mTellerContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("mTellerContext"))); */


            //Register our DB context
            //services.AddDbContextFactory<mTellerDBContext>(
            services.AddDbContext<mTellerDBContext>(
        options =>
            options.UseNpgsql(Configuration.GetConnectionString("NpgSqlConnectionString")
            ,actions=>actions.MigrationsAssembly("DataAccess")));
         
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
           
           //Register JwtSettings token
           services.Configure<JwtSettings>(Configuration.GetSection("Jwt"));
            
            //Automapper registering
            services.AddAutoMapper(typeof(Startup));

           

            //Register dependencies
            services.AddScoped<IJwtTokenBusiness,JwtTokenBusiness>();
            services.AddScoped<IAuthBusiness,AuthBusiness>();
            services.AddScoped<ICashInBusiness,CashInBusiness>();
            services.AddScoped<ICashOutBusiness, CashOutBusiness>();
            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<IRoleBusiness,RoleBusiness>();
           // services.AddScoped<ImTellerRepository<CashIn>,mTellerRepository<CashIn>>();
             services.AddScoped(typeof(ImTellerRepository<>),typeof(mTellerRepository<>));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else{

                app.UseExceptionHandler("/Error");

            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "mTeller API V1");

                //// To serve SwaggerUI at application's root page, set the RoutePrefix property to an empty string.
                //c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

           // app.UseAuthorization();

           // app.UseAuthentication();

            app.UseAuth();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
