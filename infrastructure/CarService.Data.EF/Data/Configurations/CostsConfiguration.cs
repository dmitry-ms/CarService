using CarService.Entities.CarsServices.Costs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarService.Data.EF.Data.Configurations
{
    public class CostsConfiguration : IEntityTypeConfiguration<Costs>
    {
        public void Configure(EntityTypeBuilder<Costs> builder)
        {
            builder.Property(c => c.Price)
                .IsRequired();

            builder.Property(c => c.Time)
                .IsRequired();                
        }
    }
}
