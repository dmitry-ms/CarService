using CarService.Entities.Vehicles.Parts.Engines;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CarService.Data.EF.Data.Configurations
{
    public class ElectricEngineConfiguration : IEntityTypeConfiguration<ElectricEngine>
    {
        public void Configure(EntityTypeBuilder<ElectricEngine> builder)
        {
            builder.Property(e => e.NameEngine)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
