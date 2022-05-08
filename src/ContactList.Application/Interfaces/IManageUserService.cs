using ContactList.Core.Dtos.Response;
using ContactList.Core.Dtos.User;
using ContactList.Infrastructure.Entities;

namespace ContactList.Core.Interfaces
{
    public interface IManageUserService
    {
        Task<Response<UserDto?>> GetById(Guid id);

        IQueryable<User> Get();

        Task<Response<UserDto>> Create(CreateUserDto entity);

        Task<Response<UserDto>> Update(UpdateUserDto entity);

        Task<Response<UserDto>> Delete(Guid id);
    }
}
