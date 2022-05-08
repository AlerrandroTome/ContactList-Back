using ContactList.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Infrastructure.Context
{
    public class ContactListDbContext : DbContext
    {
        public ContactListDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ContactListDbContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
