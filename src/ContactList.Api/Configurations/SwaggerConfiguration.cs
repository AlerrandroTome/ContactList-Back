using Microsoft.OpenApi.Models;

namespace ContactListWebApi.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerServiceSetup(this IServiceCollection service)
        {
            service.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ContactListApi", Description = "This is a simple contact list web api", Version = "v1" });

                c.AddSecurityDefinition("", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Description = "Authentication Token of Library",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "",
                            }
                        },
                        new string[] { }
                    }
                });
            });
        }

        public static void AddSwaggerAppSetup(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ContactListApi v1");
            });
        }
    }
}
