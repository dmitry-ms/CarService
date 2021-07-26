using CarService.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarService.Data.EF.Data.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(c => c.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(c => c.LastName)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
