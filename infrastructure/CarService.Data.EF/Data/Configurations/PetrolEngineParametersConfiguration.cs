using CarService.Entities.CarsServices.CarParameters.Engine;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarService.Data.EF.Data.Configurations
{
    public class PetrolEngineParametersConfiguration : IEntityTypeConfiguration<PetrolEngineParameters>
    {
        public void Configure(EntityTypeBuilder<PetrolEngineParameters> builder)
        {
            
        }
    }
}
