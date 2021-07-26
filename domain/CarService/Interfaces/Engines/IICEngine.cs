
namespace CarService.Interfaces
{
    public interface IICEngine : IEngine
    {
        public int EngineVolumeSquareCentimeter { get; set; }
        int NumberCylinders { get; set; }
        int NumberValves { get; set; }
    }
}
