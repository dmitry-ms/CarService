using CarService.Entities.CarsServices.Costs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarService.Data.EF.Data.Configurations
{
    public class CostsByOneCylinderConfiguration : IEntityTypeConfiguration<CostsByOneCylinder>
    {
        public void Configure(EntityTypeBuilder<CostsByOneCylinder> builder)
        {
            builder.Property(c => c.PriceByOneCylinder)
                .IsRequired();

            builder.Property(c => c.TimeByOneCylinder)
                .IsRequired();
        }
    }
}
