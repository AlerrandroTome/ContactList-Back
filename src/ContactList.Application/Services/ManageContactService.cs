using AutoMapper;
using ContactList.Application.Interfaces;
using ContactList.Core.Dtos.Contact;
using ContactList.Core.Dtos.Response;
using ContactList.Core.Interfaces;
using ContactList.Infrastructure.Entities;

namespace ContactList.Application.Services
{
    public class ManageContactService : IManageContactService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;

        public ManageContactService(IMapper mapper, 
            IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        public async Task<Response<ContactDto>> Create(CreateContactDto entityDto)
        {
            if (entityDto is null)
            {
                throw new ArgumentNullException(nameof(entityDto));
            }

            var entity = mapper.Map<Contact>(entityDto);
            var response = new Response<ContactDto>();
            var result = await uow.Repository<Contact>().Create(entity).ConfigureAwait(false);

            response.Data = mapper.Map<ContactDto>(result);
            return response;
        }

        public async Task<Response<ContactDto>> Delete(Guid id)
        {
            var entity = await uow.Repository<Contact>().GetById(id).ConfigureAwait(false);

            if (entity is null)
            {
                throw new ApplicationException($"Contact {id} was not found.");
            }

            var response = new Response<ContactDto>();
            var result = await uow.Repository<Contact>().Delete(entity).ConfigureAwait(false);

            response.Data = mapper.Map<ContactDto>(result);
            return response;
        }

        public IQueryable<Contact> Get()
        {
            return uow.Repository<Contact>().Get();
        }

        public async Task<Response<ContactDto?>> GetById(Guid id)
        {
            var response = new Response<ContactDto?>();
            response.Data = mapper.Map<ContactDto>(await uow.Repository<Contact>().GetById(id));
            return response;
        }

        public async Task<Response<ContactDto>> Update(UpdateContactDto entityDto)
        {
            if (entityDto is null)
            {
                throw new ArgumentNullException(nameof(entityDto));
            }

            var entity = await uow.Repository<Contact>().GetById(entityDto.Id).ConfigureAwait(false);

            if (entity is null)
            {
                throw new ApplicationException($"Contact {entityDto.Id} was not found.");
            }

            entity = mapper.Map(entityDto, entity);
            var response = new Response<ContactDto>();
            var result = await uow.Repository<Contact>().Update(entity).ConfigureAwait(false);
            response.Data = mapper.Map<ContactDto>(result);
            return response;
        }
    }
}
