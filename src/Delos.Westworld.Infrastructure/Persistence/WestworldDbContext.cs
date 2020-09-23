using System.Reflection;
using Delos.Westworld.Domain;
using Microsoft.EntityFrameworkCore;

namespace Delos.Westworld.Infrastructure.Persistence
{
    public class WestworldDbContext: DbContext
    {
        public DbSet<Park> Parks { get; set; }
        public DbSet<Host> Hosts { get; set; }

        public WestworldDbContext(DbContextOptions<WestworldDbContext> options)
            : base(options)
        {
        }

        public WestworldDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}