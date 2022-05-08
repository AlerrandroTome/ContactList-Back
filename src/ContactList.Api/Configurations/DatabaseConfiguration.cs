using ContactList.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Api.Configurations
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, string connString)
        {
            services.AddDbContext<ContactListDbContext>(options =>
                options.UseSqlServer(connString)
            );
        }
    }
}
