using AutoMapper;
using ContactList.Core.Dtos.Contact;
using ContactList.Core.Dtos.User;
using ContactList.Infrastructure.Entities;

namespace ContactList.Infrastructure.Settings
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            CreateMap<Contact, ContactDto>().ReverseMap();
        }
    }
}
