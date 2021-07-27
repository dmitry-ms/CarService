using CarService.Entities.CarsServices.CarParameters.Engine;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarService.Data.EF.Data.Configurations
{
    public class DieselEngineParametersConfiguration : IEntityTypeConfiguration<DieselEngineParameters>
    {
        public void Configure(EntityTypeBuilder<DieselEngineParameters> builder)
        {
            builder.Property(d => d.DEF)
                .IsRequired(false);
        }
    }
}
