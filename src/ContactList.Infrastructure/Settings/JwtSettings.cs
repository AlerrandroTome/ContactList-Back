using ContactList.Core.Interfaces;

namespace ContactList.Infrastructure.Settings
{
    public class JwtSettings : IJwtSettings
    {
        public JwtSettings()
        {
            Secret = string.Empty;
            Audience = string.Empty;
            Issuer = string.Empty;
        }

        public string Secret { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
    }
}
