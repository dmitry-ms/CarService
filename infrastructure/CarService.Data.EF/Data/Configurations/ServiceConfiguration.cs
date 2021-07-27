using CarService.Entities.CarsServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarService.Data.EF.Data.Configurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(s => s.ServiceType)
                .IsRequired();

            builder.Property(s => s.ServiceName)
                .IsRequired();
        }
    }
}
