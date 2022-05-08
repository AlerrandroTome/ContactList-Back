using AutoMapper;
using ContactList.Core.Dtos.Response;
using ContactList.Core.Dtos.User;
using ContactList.Core.Interfaces;
using ContactList.Infrastructure.Entities;

namespace ContactList.Application.Services
{
    public class ManageUserService : IManageUserService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;

        public ManageUserService(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        public async Task<Response<UserDto>> Create(CreateUserDto entityDto)
        {
            if (entityDto is null)
            {
                throw new ArgumentNullException(nameof(entityDto));
            }

            var entity = mapper.Map<User>(entityDto);
            var response = new Response<UserDto>();
            var result = await uow.Repository<User>().Create(entity).ConfigureAwait(false);
            response.Data = mapper.Map<UserDto>(result);
            return response;
        }

        public async Task<Response<UserDto>> Delete(Guid id)
        {
            var entity = await uow.Repository<User>().GetById(id).ConfigureAwait(false);

            if(entity is null)
            {
                throw new ApplicationException($"user {id} was not found.");
            }

            if (entity.Contacts.Any())
                throw new ApplicationException("There are contacts saved for this user, so it cannot be removed.");


            var response = new Response<UserDto>();
            var result = await uow.Repository<User>().Delete(entity).ConfigureAwait(false);
            response.Data = mapper.Map<UserDto>(result);
            return response;
        }

        public IQueryable<User> Get()
        {
            return uow.Repository<User>().Get();
        }

        public async Task<Response<UserDto?>> GetById(Guid id)
        {
            var response = new Response<UserDto?>();
            response.Data = mapper.Map<UserDto>(await uow.Repository<User>().GetById(id));
            return response;
        }

        public async Task<Response<UserDto>> Update(UpdateUserDto entityDto)
        {
            if (entityDto is null)
            {
                throw new ArgumentNullException(nameof(entityDto));
            }

            var entity = await uow.Repository<User>().GetById(entityDto.Id).ConfigureAwait(false);
            
            if (entity is null)
            {
                throw new ApplicationException($"user {entityDto.Id} was not found.");
            }

            entity = mapper.Map(entityDto, entity);
            var response = new Response<UserDto>();
            var result = await uow.Repository<User>().Update(entity).ConfigureAwait(false);
            response.Data = mapper.Map<UserDto>(result);
            return response;
        }
    }
}
