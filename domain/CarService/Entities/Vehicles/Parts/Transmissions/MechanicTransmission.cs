using CarService.Interfaces;

namespace CarService.Entities.Vehicles.Parts.Transmissions
{
    public class MechanicTransmission : Transmission, IMechanicTransmission
    {
        public int NumberOfGears { get; set; }
    }
}
