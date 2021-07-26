using CarService.Interfaces;

namespace CarService.Entities.Vehicles.Parts.Transmissions
{
    public class RoboticTransmission : Transmission, IRoboticTransmission
    {
        public int NumberOfGears { get; set; }
    }
}
