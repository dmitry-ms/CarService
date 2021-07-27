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






        //public DbSet<DieselEngine> DieselEngines { get; set; }
        //public DbSet<ElectricEngine> ElectricEngines { get; set; }  
        //public DbSet<PetrolEngine> PetrolEngines { get; set; }
        //public DbSet<AutomaticTransmission> AutomaticTransmissions { get; set; }
        //public DbSet<MechanicTransmission> MechanicTransmissions { get; set; }
        //public DbSet<RoboticTransmission> RoboticTransmissions { get; set; }
        //public DbSet<VariatorTransmission> VariatorTransmissions { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            //todo: с этим нада шота делать и почистить папку с конфигурациями
            builder.Entity<Costs>();
            builder.Entity<CostsByDriveUnit>();
            builder.Entity<CostsByOneCylinder>();
            builder.Entity<BaseCosts>();
            builder.Entity<DieselEngineParameters>();
            builder.Entity<ElectricEngineParameters>();
            builder.Entity<ICEngineParameters>();
            builder.Entity<PetrolEngineParameters>();
            builder.Entity<DieselEngine>();
            builder.Entity<ElectricEngine>();
            builder.Entity<PetrolEngine>();
            builder.Entity<AutomaticTransmission>();
            builder.Entity<MechanicTransmission>();
            builder.Entity<RoboticTransmission>();
            builder.Entity<VariatorTransmission>();

            var splitStringConverter = new ValueConverter<IEnumerable<string>, string>(v => string.Join(";", v), v => v.Split(new[] { ';' }));

            builder.Entity<EngineParameters>().Property(e => e.EngineNames).HasConversion(splitStringConverter);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
