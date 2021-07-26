using CarService.Interfaces;

namespace CarService.Entities.Vehicles.Parts.Transmissions
{
    public class AutomaticTransmission : Transmission, IAutomaticTransmission
    {
        public int NumberOfGears { get; set; }
    }
}
