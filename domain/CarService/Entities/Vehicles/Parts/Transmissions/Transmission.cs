using CarService.Entities.Base;
using CarService.Enums;
using CarService.Interfaces;

namespace CarService.Entities.Vehicles.Parts.Transmissions
{
    public abstract class Transmission : Entity, ITransmission
    {
        public string Name { get; set; }
        public DriveUnit DriveUnit { get; set; }
    }
}
