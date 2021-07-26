using CarService.Data.EF.Identity;
using CarService.Entities.Vehicles;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CarService.Entities.Users;
using CarService.Entities.Vehicles.Parts.Engines;
using CarService.Entities.Vehicles.Parts.Transmissions;
using System.Reflection;

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
        public DbSet<DieselEngine> DieselEngines { get; set; }
        public DbSet<ElectricEngine> ElectricEngines { get; set; }
        public DbSet<PetrolEngine> PetrolEngines { get; set; }
        public DbSet<AutomaticTransmission> AutomaticTransmissions { get; set; }
        public DbSet<MechanicTransmission> MechanicTransmissions { get; set; }
        public DbSet<RoboticTransmission> RoboticTransmissions { get; set; }
        public DbSet<VariatorTransmission> VariatorTransmissions { get; set; }






        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
