using ContactList.Infrastructure.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ContactList.Api.Configurations
{
    public static class AuthenticationConfiguration
    {
        public static void AddAuthenticationSetup(this IServiceCollection services, string secretValue, JwtSettings jwtSettings)
        {
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt =>
            {
                var parameters = jwt.TokenValidationParameters;
                jwt.SaveToken = true;
                parameters.ValidateAudience = false;
                parameters.ValidateIssuer = false;
                parameters.ValidateIssuerSigningKey = true;
                parameters.IssuerSigningKey = new SymmetricSecurityKey(key: Encoding.ASCII.GetBytes(secretValue));
                parameters.ValidateLifetime = true;
            });
        }
    }
}
