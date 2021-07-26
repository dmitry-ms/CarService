using CarService.Entities.Vehicles.Parts.Transmissions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CarService.Data.EF.Data.Configurations
{
    public class MechanicTransmissionConfiguration : IEntityTypeConfiguration<MechanicTransmission>
    {
        public void Configure(EntityTypeBuilder<MechanicTransmission> builder)
        {
            builder.Property(m => m.Name)
                .HasMaxLength(20)
                .IsRequired();                

            //builder.Property(m => m.DriveUnit)
            //    .IsRequired();

            //builder.Property(m => m.NumberOfGears)
            //    .IsRequired();
        }
    }
}
