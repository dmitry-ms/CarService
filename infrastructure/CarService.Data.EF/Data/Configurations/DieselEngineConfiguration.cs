using CarService.Entities.Vehicles.Parts.Engines;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CarService.Data.EF.Data.Configurations
{
    public class DieselEngineConfiguration : IEntityTypeConfiguration<DieselEngine>
    {
        public void Configure(EntityTypeBuilder<DieselEngine> builder)
        {
            builder.Property(d => d.NameEngine)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
