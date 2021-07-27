using CarService.Entities.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CarService.Data.EF.Data.Configurations
{
    public class ServiceManConfiguration : IEntityTypeConfiguration<ServiceMan>
    {
        public void Configure(EntityTypeBuilder<ServiceMan> builder)
        {
            builder.Property(s => s.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(s => s.LastName)
                .HasMaxLength(30)
                .IsRequired();

            builder.HasMany(r => r._roles)
                .WithOne(s => s.ServiceMan);

            builder.Ignore(s => s.Roles);
        }
    }
}
