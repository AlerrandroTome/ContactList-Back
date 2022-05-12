using ContactList.Core.Dtos.Login;
using ContactList.Core.Dtos.Response;
using ContactList.Infrastructure.Entities;

namespace ContactList.Application.Interfaces
{
    public interface IManageTokenService
    {
        Response<LoginResponseDto> GenerateToken(User user);
    }
}
