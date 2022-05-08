using ContactList.Core;

namespace ContactList.Infrastructure.Entities
{
    public class User : BaseEntity
    {
        public User(string userName, string password, string name)
        {
            UserName = userName;
            Password = password;
            Name = name;
        }

        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
