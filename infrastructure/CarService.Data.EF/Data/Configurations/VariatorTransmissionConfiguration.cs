using CarService.Entities.Vehicles.Parts.Transmissions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CarService.Data.EF.Data.Configurations
{
    public class VariatorTransmissionConfiguration : IEntityTypeConfiguration<VariatorTransmission>
    {
        public void Configure(EntityTypeBuilder<VariatorTransmission> builder)
        {
            builder.Property(v => v.Name)
                .HasMaxLength(30)
                .IsRequired();
            
            builder.Property(v => v.DriveUnit)
                .IsRequired();

        }
    }
}
