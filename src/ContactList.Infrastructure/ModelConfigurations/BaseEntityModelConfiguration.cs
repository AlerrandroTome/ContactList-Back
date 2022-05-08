using ContactList.Core;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactList.Infrastructure.ModelConfigurations
{
    public static class BaseEntityModelConfiguration
    {
        public static void AddBaseModelConfiguration<T>(this EntityTypeBuilder<T> builder) where T : BaseEntity
        {
            _ = builder.Property(p => p.InclusionDate)
                       .IsRequired();

            _ = builder.Property(p => p.LastUpdateDate);
        }
    }
}
