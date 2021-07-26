using CarService.Entities.Vehicles;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CarService.Data.EF.Data.Configurations
{
    public class ClientCarConfiguration : IEntityTypeConfiguration<ClientCar>
    {
        public void Configure(EntityTypeBuilder<ClientCar> builder)
        {
            builder.Property(c => c.VinNumber)
                .HasMaxLength(17);

            builder.Property(c => c.CarPlate)
                .HasMaxLength(10);
        }
    }
}
