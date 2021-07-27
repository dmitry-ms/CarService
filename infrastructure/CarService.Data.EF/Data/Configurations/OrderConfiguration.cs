using CarService.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarService.Data.EF.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.DateAdded)
                .IsRequired();

            //builder.Property(o => o.Car)
            //    .IsRequired();

            builder.HasMany(o => o.Services)   //
                .WithMany(s => s.Orders);      //
                                               //
            //builder.Property(o => o.Services)  //todo: Is this OK?
            //   .IsRequired();                  //
        }
    }
}
