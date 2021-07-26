using CarService.Entities.Vehicles.Parts.Engines;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CarService.Data.EF.Data.Configurations
{
    public class PetrolEngineConfiguration : IEntityTypeConfiguration<PetrolEngine>
    {
        public void Configure(EntityTypeBuilder<PetrolEngine> builder)
        {
            builder.Property(p => p.NameEngine)
                .HasMaxLength(20)
                .IsRequired();

            //builder.Property(p => p.NumberCylinders)
            //    .IsRequired();

            //builder.Property(p => p.NumberValves)
            //    .IsRequired();

            //builder.Property(p => p.EngineVolumeSquareCentimeter)
            //    .IsRequired();
        }
    }
}
