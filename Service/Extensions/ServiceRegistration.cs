using AutoMapper;
using Business;
using Business.Interface;
using Business.Mapping;
using DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;
using Platform;
using Platform.Interface;
using Platform.MoMo;

namespace Service.Extensions
{
    public static class ServiceRegistration
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<IJwtTokenBusiness, JwtTokenBusiness>();
            services.AddScoped<IAuthBusiness, AddCashIn>();
            services.AddScoped<ICashInBusiness, CashInBusiness>();
            services.AddScoped<ICashOutBusiness, CashOutBusiness>();
            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<IRoleBusiness, RoleBusiness>();

            services.AddScoped(typeof(ImTellerRepository<>), typeof(mTellerRepository<>));
            //services.AddScoped<IMomoAPI, MomoAPI>();
            services.AddScoped<IMomoCollectionAPIService, MomoCollectionAPIService>();
            services.AddScoped<IMomoDisbursementAPIService, MomoDisbursementAPIService>();
            services.AddScoped<IDisbursement, Disbursement>();

            // Register the Swagger Generator service. This service is responsible for genrating Swagger Documents.
            // Note: Add this service at the end after AddMvc() or AddMvcCore().
            /* services.AddSwaggerGen(c =>
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
             });*/

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}