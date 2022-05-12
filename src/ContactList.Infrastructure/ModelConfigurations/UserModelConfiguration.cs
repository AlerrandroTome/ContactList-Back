using ContactList.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactList.Infrastructure.ModelConfigurations
{
    public class UserModelConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.AddBaseModelConfiguration();
            builder.Property(p => p.UserName).IsRequired().HasMaxLength(150);
            builder.Property(p => p.Password).IsRequired().HasMaxLength(10);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(200);

            builder.HasMany(m => m.Contacts)
                   .WithOne(o => o.User)
                   .HasForeignKey(fk => fk.UserId);
        }
    }
}
