using ContactList.Application.Interfaces;
using ContactList.Application.Services;
using ContactList.Core.Interfaces;
using ContactList.Infrastructure.UnitOfWork;

namespace ContactList.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IManageLoginService, ManageLoginService>();
            services.AddScoped<IManageUserService, ManageUserService>();
            services.AddScoped<IManageTokenService, ManageTokenService>();
        }
    }
}