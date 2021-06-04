using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterYourLibrary(this IServiceCollection services, DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            services.AddScoped<IMteller, Mteller>(uow => new Mteller(dbContext));
        }
    }
}
