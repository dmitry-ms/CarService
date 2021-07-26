using CarService.Entities.Vehicles;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CarService.Data.EF.Data.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.Property(v => v.BrandName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(v => v.ModelName)
                .HasMaxLength(20)
                .IsRequired();

        }
    }
}
