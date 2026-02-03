using fazyup.api.Shared.Database.Configuration;
using fazyup.api.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace fazyup.api.Database
{
    public class FazyupDbContext : DbContext
    {
        public FazyupDbContext(DbContextOptions<FazyupDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FazyupDbContext).Assembly);
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var clrType = entityType.ClrType;

                if (!clrType.IsClass || clrType.IsAbstract)
                    continue;

                var baseType = clrType.BaseType;

                while (baseType != null)
                {
                    if (baseType.IsGenericType &&
                        baseType.GetGenericTypeDefinition() == typeof(BaseEntity<>))
                    {
                       EntityConfiguration.BaseEntityConfiguration(modelBuilder, clrType);
                        break;
                    }

                    baseType = baseType.BaseType;
                }
            }
        }

    }
}

