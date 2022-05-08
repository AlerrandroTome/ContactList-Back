using ContactList.Core.Dtos.Response;
using ContactList.Infrastructure.Entities;

namespace ContactList.Application.Interfaces
{
    public interface IManageTokenService
    {
        Response<string> GenerateToken(User user);
    }
}
