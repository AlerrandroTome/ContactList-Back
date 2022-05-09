using ContactList.Core;
using ContactList.Core.Interfaces;

namespace ContactList.Infrastructure.Entities
{
    public class Contact : BaseEntity, IODataEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? WhatsappNumber { get; set; }
        public bool PhoneNumberIsWhatsapp { get; set; } = false;
        public Guid UserId { get; set; }
        public User? User { get; set; }
    }
}
