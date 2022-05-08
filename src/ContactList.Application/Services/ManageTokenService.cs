using ContactList.Application.Interfaces;
using ContactList.Core.Dtos.Response;
using ContactList.Core.Interfaces;
using ContactList.Infrastructure.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ContactList.Application.Services
{
    public class ManageTokenService : IManageTokenService
    {
        private readonly IJwtSettings jwt;

        public ManageTokenService(IJwtSettings jwt)
        {
            this.jwt = jwt;
        }

        public Response<string> GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwt.Secret);
            var expirationDate = DateTime.Parse($"{DateTime.Now.AddDays(1).ToString("dd/MM/yyyy")} 00:00:00");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Login", user.UserName),
                    new Claim("Active", user.Name.ToString()),
                    new Claim("ExpirationDate", expirationDate.ToString("dd/MM/yyyy HH:mm:ss"))
                }),
                Expires = expirationDate,
                NotBefore = DateTime.Now,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = jwt.Audience,
                Issuer = jwt.Issuer
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var response = new Response<string>();
            response.Data = tokenHandler.WriteToken(token);
            return response;
        }
    }
}
