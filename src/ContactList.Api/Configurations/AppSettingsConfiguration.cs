using ContactList.Core.Interfaces;
using ContactList.Infrastructure.Settings;
using Microsoft.Extensions.Options;

namespace ContactList.Api.Configurations
{
    public static class AppSettingsConfiguration
    {
        public static void AddAppSettingsSetup(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnStringSettings>(configuration.GetSection(nameof(ConnStringSettings)));
            services.AddSingleton(x => (IConnStringSettings)x.GetRequiredService<IOptions<ConnStringSettings>>().Value);

            services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));
            services.AddSingleton<IJwtSettings>(x => x.GetRequiredService<IOptions<JwtSettings>>().Value);
        }
    }
}
