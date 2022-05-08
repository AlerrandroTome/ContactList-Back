using ContactList.Core.Dtos.Contact;
using ContactList.Core.Dtos.Response;
using ContactList.Infrastructure.Entities;

namespace ContactList.Application.Interfaces
{
    public interface IManageContactService
    {
        Task<Response<ContactDto?>> GetById(Guid id);

        IQueryable<Contact> Get();

        Task<Response<ContactDto>> Create(CreateContactDto entity);

        Task<Response<ContactDto>> Update(UpdateContactDto entity);

        Task<Response<ContactDto>> Delete(Guid id);
    }
}
