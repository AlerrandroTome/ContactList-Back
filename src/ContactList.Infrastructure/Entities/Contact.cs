using ContactList.Core;

namespace ContactList.Infrastructure.Entities
{
    public class Contact : BaseEntity
    {
        public Contact(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? WhatsappNumber { get; set; }
        public bool PhoneNumberIsAlreadyWhatsapp { get; set; } = false;
        public Guid UserId { get; set; }
        public User? User { get; set; }
    }
}
