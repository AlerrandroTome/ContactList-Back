using ContactList.Core.Dtos.Login;
using ContactList.Core.Dtos.Response;

namespace ContactList.Application.Interfaces
{
    public interface IManageLoginService
    {
        Task<Response<string>> Login(LoginDto credentials);
    }
}
