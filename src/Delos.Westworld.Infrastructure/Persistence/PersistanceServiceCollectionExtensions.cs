using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Delos.Westworld.Infrastructure.Persistence
{
    public static class PersistanceServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<WestworldDbContext>(options => options.UseSqlServer(connectionString));

            return services;
        }
    }
}