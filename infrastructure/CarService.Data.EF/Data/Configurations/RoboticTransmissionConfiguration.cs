using CarService.Entities.Vehicles.Parts.Transmissions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CarService.Data.EF.Data.Configurations
{
    public class RoboticTransmissionConfiguration : IEntityTypeConfiguration<RoboticTransmission>
    {
        public void Configure(EntityTypeBuilder<RoboticTransmission> builder)
        {
            builder.Property(r => r.Name)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(r => r.DriveUnit)
                .IsRequired();

            builder.Property(r => r.NumberOfGears)
                .IsRequired();
        }
    }
}
