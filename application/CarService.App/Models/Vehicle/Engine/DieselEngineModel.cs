namespace CarService.App.Models
{
    public class DieselEngineModel : EngineModel
    {
        public int EngineVolumeSquareCentimeter { get; set; }
        public bool DEF { get; set; }
        public int NumberCylinders { get; set; }
        public int NumberValves { get; set; }
    }
}
