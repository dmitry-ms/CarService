namespace CarService.App.Models
{
    public class PetrolEngineModel : EngineModel
    {
        public int EngineVolumeSquareCentimeter { get; set; }
        public int NumberCylinders { get; set; }
        public int NumberValves { get; set; }
    }
}
