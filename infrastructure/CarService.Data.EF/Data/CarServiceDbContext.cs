using CarService.Data.EF.Identity;
using CarService.Entities.Vehicles;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CarService.Entities.Users;
using CarService.Entities.Vehicles.Parts.Engines;
using CarService.Entities.Vehicles.Parts.Transmissions;
using System.Reflection;
using CarService.Entities.CarsServices;
using CarService.Entities.Orders;
using CarService.Entities.CarsServices.Costs;
using CarService.Entities.CarsServices.CarParameters.Engine;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarService.Data.EF.Data
{
    public class CarServiceDbContext : IdentityDbContext<CarServiceUser, CarServiceRole, string>
    {
        public CarServiceDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ServiceMan> ServiceMens { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ClientCar> ClientCars { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {            
            builder.Entity<Costs>(ConfigureCosts);
            builder.Entity<CostsByDriveUnit>(ConfigureCostsByDriveUnit);
            builder.Entity<CostsByOneCylinder>(ConfigureCostsByOneCylinder);

            builder.Entity<EngineParameters>(ConfigureEngineParameters);
            builder.Entity<DieselEngineParameters>();
            builder.Entity<ElectricEngineParameters>();
            builder.Entity<PetrolEngineParameters>();

            builder.Entity<Engine>(ConfigureEngine);
            builder.Entity<DieselEngine>();
            builder.Entity<ElectricEngine>();
            builder.Entity<PetrolEngine>();

            builder.Entity<Transmission>(ConfigureTransmission);
            builder.Entity<AutomaticTransmission>();
            builder.Entity<MechanicTransmission>();
            builder.Entity<RoboticTransmission>();
            builder.Entity<VariatorTransmission>();

            builder.Entity<Vehicle>(ConfigureVehicle);

            builder.Entity<ClientCar>(ConfigureClienCar);
            
            builder.Entity<Person>(ConfigurePerson);
            builder.Entity<ServiceMan>(ConfigureServiceMan);

            builder.Entity<Service>(ConfigureService);

            //builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
        //todo: возможно вынести отдельно
        private void ConfigureCosts(EntityTypeBuilder<Costs> builder)
        {
            builder.Property(c => c.Price)
                .IsRequired();

            builder.Property(c => c.Time)
                .IsRequired();
        }
        private void ConfigureCostsByDriveUnit(EntityTypeBuilder<CostsByDriveUnit> builder)
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
        private void ConfigureCostsByOneCylinder(EntityTypeBuilder<CostsByOneCylinder> builder)
        {
            builder.Property(c => c.PriceByOneCylinder)
                .IsRequired();

            builder.Property(c => c.TimeByOneCylinder)
                .IsRequired();
        }
        private void ConfigureEngineParameters(EntityTypeBuilder<EngineParameters> builder)
        {
            var splitStringConverter = new ValueConverter<IEnumerable<string>, string>(v => string.Join(";", v), v => v.Split(new[] { ';' }));

            builder.Property(e => e.EngineNames).HasConversion(splitStringConverter);
        }
        private void ConfigureEngine(EntityTypeBuilder<Engine> builder)
        {
            builder.Property(d => d.NameEngine)
                .HasMaxLength(20)
                .IsRequired();
        }
        private void ConfigureTransmission(EntityTypeBuilder<Transmission> builder)
        {
            builder.Property(t => t.Name)
                .HasMaxLength(20)
                .IsRequired();
        }
        private void ConfigureVehicle(EntityTypeBuilder<Vehicle> builder)
        {
            builder.Property(v => v.BrandName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(v => v.ModelName)
                .HasMaxLength(20)
                .IsRequired();
        }
        private void ConfigureClienCar(EntityTypeBuilder<ClientCar> builder)
        {
            builder.Property(c => c.VinNumber)
                .HasMaxLength(17);

            builder.Property(c => c.CarPlate)
                .HasMaxLength(10);
        }
        private void ConfigurePerson(EntityTypeBuilder<Person> builder)
        {
            builder.Property(c => c.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(c => c.LastName)
                .HasMaxLength(30)
                .IsRequired();
        }
        private void ConfigureServiceMan(EntityTypeBuilder<ServiceMan> builder)
        {
            builder.HasMany(r => r._roles)
                .WithOne(s => s.ServiceMan);

            builder.Ignore(s => s.Roles);
        }
        private void ConfigureService(EntityTypeBuilder<Service> builder)
        {
            builder.Property(s => s.ServiceType)
                .IsRequired();

            builder.Property(s => s.ServiceName)
                .IsRequired();
        }
    }
}
