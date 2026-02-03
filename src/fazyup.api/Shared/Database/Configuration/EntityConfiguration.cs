using Microsoft.EntityFrameworkCore;

namespace fazyup.api.Shared.Database.Configuration
{
    public static class EntityConfiguration
    {
        public static void BaseEntityConfiguration(ModelBuilder modelBuilder, Type entityType)
        {
            var builder = modelBuilder.Entity(entityType);

            builder.HasKey("Id");

            builder.Property("CreatedAt")
                .IsRequired();

            builder.Property("UpdatedAt");

            builder.HasIndex("CreatedAt");

            var idProperty = entityType.GetProperty("Id");

            if (idProperty != null)
            {
                var idType = idProperty.PropertyType;

                if (idType == typeof(Guid) ||
                    idType == typeof(int) ||
                    idType == typeof(long))
                {
                    builder.Property("Id").ValueGeneratedOnAdd();
                }
            }
        }
    }
}
