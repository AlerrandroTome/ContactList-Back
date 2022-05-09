using ContactList.Api.Middlewares;

namespace ContactList.Api.Configurations
{
    public static class MiddlewaresConfiguration
    {
        public static void AddMiddlewareSetup(this IServiceCollection services)
        {
            services.AddControllers()
                    .ConfigureApiBehaviorOptions(options =>
                        options.SuppressModelStateInvalidFilter = true
                    );

            services.AddMvcCore(options =>
            {
                options.EnableEndpointRouting = true;
                options.Filters.Add<ExceptionFilter>();
                options.Filters.Add<ValidatorFilter>();
            });
        }
    }
}
