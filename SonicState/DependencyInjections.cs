using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SonicState.CloudStorage;
using SonicState.Contracts;
using SonicState.Contracts.Repositories;
using SonicState.Contracts.Services;
using SonicState.Repositories;
using SonicState.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SonicState.Web
{
    public static class DependencyInjections
    {
        public static void AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAudioRepository, AudioRepository>();
            services.AddScoped<IAudioService, AudioService>();
            services.AddScoped<FileStorage, GoogleCloud>();

            services.AddAutoMapper();

        }
    }
}
