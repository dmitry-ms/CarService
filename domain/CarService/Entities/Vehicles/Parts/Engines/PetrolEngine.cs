using CarService.Interfaces;

namespace CarService.Entities.Vehicles.Parts.Engines
{
    public class PetrolEngine : Engine, IPetrolEngine
    {
        public int EngineVolumeSquareCentimeter { get; set; }
        public int NumberCylinders { get; set; }
        public int NumberValves { get; set; }
    }
}
