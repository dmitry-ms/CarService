using CarService.Interfaces;

namespace CarService.Entities.Vehicles.Parts.Engines
{
    public class DieselEngine : Engine, IDieselEngine
    {
        public int EngineVolumeSquareCentimeter { get; set; }
        public bool DEF { get; set; }
        public int NumberCylinders { get; set; }
        public int NumberValves { get; set; }
    }
}
