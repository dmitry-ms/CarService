using CarService.Entities.CarsServices.Costs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarService.Data.EF.Data.Configurations
{
    public class BaseCostsConfiguration : IEntityTypeConfiguration<BaseCosts>
    {
        public void Configure(EntityTypeBuilder<BaseCosts> builder)
        {
            //builder.HasDiscriminator<string>("BaseType")
            //    .HasValue<Costs>("Costs")
            //    .HasValue<CostsByDriveUnit>("CostsByDriveUnit")
            //    .HasValue<CostsByOneCylinder>("CostsByOneCylinder");
        }
    }
}
