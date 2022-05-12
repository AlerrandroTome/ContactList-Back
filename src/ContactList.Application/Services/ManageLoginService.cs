using ContactList.Application.Interfaces;
using ContactList.Core.Dtos.Login;
using ContactList.Core.Dtos.Response;
using ContactList.Core.Interfaces;
using ContactList.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Application.Services
{
    public class ManageLoginService : IManageLoginService
    {
        private readonly IUnitOfWork uow;
        private readonly IManageTokenService tokenService;

        public ManageLoginService(IUnitOfWork uow, IManageTokenService tokenService)
        {
            this.uow = uow;
            this.tokenService = tokenService;
        }

        public async Task<Response<string>> Login(LoginDto credentials)
        {
            //credentials.Password = credentials.Password.Atob();
            var response = new Response<string>();
            var user = await uow.Repository<User>()
                                .Get()
                                .FirstOrDefaultAsync(w => w.UserName.Equals(credentials.UserName) && w.Password.Equals(credentials.Password))
                                .ConfigureAwait(false);

            if (user != null)
            {
                return tokenService.GenerateToken(user);
            }
            else
            {
                throw new ApplicationException("Username or password is wrong.");
            }
        }
    }
}
