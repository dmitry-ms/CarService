using CarService.Entities.CarsServices.CarParameters.Engine;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarService.Data.EF.Data.Configurations
{
    public class ElectricEngineParametersConfiguration : IEntityTypeConfiguration<ElectricEngineParameters>
    {
        public void Configure(EntityTypeBuilder<ElectricEngineParameters> builder)
        {
            builder.Property(e => e.MaxBatteryCapacity)
                .IsRequired(false);
            builder.Property(e => e.MinBatteryCapacity)
                .IsRequired(false);
        }
    }
}
