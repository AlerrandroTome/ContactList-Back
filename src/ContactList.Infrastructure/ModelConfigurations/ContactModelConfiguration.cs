using ContactList.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactList.Infrastructure.ModelConfigurations
{
    public class ContactModelConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(x => x.Id);
            builder.AddBaseModelConfiguration();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(200);
            builder.Property(p => p.PhoneNumber).HasMaxLength(20);
            builder.Property(p => p.WhatsappNumber).HasMaxLength(20);
            builder.Property(p => p.PhoneNumberIsAlreadyWhatsapp);

            builder.HasOne(p => p.User)
                   .WithMany(p => p.Contacts)
                   .HasForeignKey(fk => fk.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
