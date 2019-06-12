using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonicState.Data
{
    public static class DbSetup
    {
        public static void AddDbConnection(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SonicStateDbContext>(options =>
             options.UseLazyLoadingProxies()
                       .UseSqlServer(connectionString));
        }
    }
}
