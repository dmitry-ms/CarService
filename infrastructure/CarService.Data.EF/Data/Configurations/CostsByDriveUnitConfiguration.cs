using CarService.Entities.CarsServices.Costs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarService.Data.EF.Data.Configurations
{
    public class CostsByDriveUnitConfiguration : IEntityTypeConfiguration<CostsByDriveUnit>
    {
        public void Configure(EntityTypeBuilder<CostsByDriveUnit> builder)
        {
            builder.Property(c => c.PriceByFourWheelDrive)
                .IsRequired();
            builder.Property(c => c.PriceByFrontWheelDriveOrMono)
                .IsRequired();

            builder.Property(c => c.TimeByFourWheelDrive)
                .IsRequired();
            builder.Property(c => c.TimeByFrontWheelDriveOrMono)
                .IsRequired();
        }
    }
}
