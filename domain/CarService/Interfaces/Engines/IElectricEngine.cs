namespace CarService.Interfaces
{
    public interface IElectricEngine : IEngine
    {
        public int BatteryCapacity { get; set; }
    }
}
