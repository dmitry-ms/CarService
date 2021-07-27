using CarService.Entities.CarsServices.CarParameters.Engine;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Collections.Generic;

namespace CarService.Data.EF.Data.Configurations
{
    public class EngineParametersConfiguration : IEntityTypeConfiguration<EngineParameters>
    {
        public void Configure(EntityTypeBuilder<EngineParameters> builder)
        {
            var splitStringConverter =
                new ValueConverter<IEnumerable<string>, string>
                (v => string.Join(";", v), v => v.Split(new[] { ';' }));

            builder.Property(e => e.EngineNames)
                .HasConversion(splitStringConverter);
        }
    }
}
