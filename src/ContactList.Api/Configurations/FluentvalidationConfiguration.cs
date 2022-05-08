using ContactList.Infrastructure.Validators.User;
using FluentValidation.AspNetCore;
using System.Globalization;

namespace ContactList.Api.Configurations
{
    public static class FluentValidationConfiguration
    {
        public static void AddFluentValidationSetup(this IServiceCollection services)
        {
            services.AddMvc().AddFluentValidation(options => {
                options.RegisterValidatorsFromAssemblyContaining<CreateUserValidator>();
                options.ValidatorOptions.LanguageManager.Culture = CultureInfo.CreateSpecificCulture("en-us");
            });
        }
    }
}
