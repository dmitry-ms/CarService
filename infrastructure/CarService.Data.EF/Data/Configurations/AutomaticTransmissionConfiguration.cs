using CarService.Entities.Vehicles.Parts.Transmissions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CarService.Data.EF.Data.Configurations
{
    public class AutomaticTransmissionConfiguration : IEntityTypeConfiguration<AutomaticTransmission>
    {
        public void Configure(EntityTypeBuilder<AutomaticTransmission> builder)
        {
            builder.Property(a => a.Name)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
