using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SonicState.Authentication;
using SonicState.BackgroundServices;
using SonicState.CloudStorage;
using SonicState.Contracts;
using SonicState.Contracts.Repositories;
using SonicState.Contracts.Services;
using SonicState.Contracts.Services.ValidationServices;
using SonicState.Repositories;
using SonicState.Services;
using SonicState.SonicAPI;
using SonicState.Validations.ValidationRules;
using SonicState.Validations.ValidationServices;

namespace SonicState.Web
{
    public static class DependencyInjections
    {
        public static void AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IAudioRepository, AudioRepository>();
            services.AddScoped<IAudioService, AudioService>();
            services.AddScoped<FileStorage, GoogleCloud>();
            services.AddScoped<AudioAnalyzer, SonicAnalyzer>();
            services.AddHostedService<QueuedHostedService>();
            services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();
            services.AddTransient<IChordUnitRepository, ChordUnitRepository>();
            services.AddScoped<IChordService, ChordService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<AuthenticateService, TokenAuthenticationService>();
            services.AddScoped(typeof(TokenManagement));
            services.AddScoped<IRegisterUserValidationService, RegisterUserValidationService>();
            services.AddScoped(typeof(RegisterUserValidationRules));
            services.AddScoped<ILoginUserValidationService, LoginUserValidationService>();
            services.AddScoped(typeof(LoginUserValidationRules));
            services.AddScoped<IClaimAccessor, ClaimAccessor>();
            services.AddAutoMapper();

        }
    }
}
