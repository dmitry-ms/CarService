using CarService.Entities.CarsServices.CarParameters.Engine;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarService.Data.EF.Data.Configurations
{
    public class ICEngineParametersConfiguration : IEntityTypeConfiguration<ICEngineParameters>
    {
        public void Configure(EntityTypeBuilder<ICEngineParameters> builder)
        {
            builder.Property(i => i.MaxEngineVolume)
                .IsRequired(false);
            builder.Property(i => i.MinEngineVolume)
                .IsRequired(false);
            builder.Property(i => i.MaxNumberCylinders)
                 .IsRequired(false);
            builder.Property(i => i.MinNumberCylinders)
                .IsRequired(false);
            builder.Property(i => i.MaxNumberValves)
                .IsRequired(false);
            builder.Property(i => i.MinNumberValves)
                .IsRequired(false);
        }
    }
}
