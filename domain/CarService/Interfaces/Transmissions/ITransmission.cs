using CarService.Enums;

namespace CarService.Interfaces
{
    public interface ITransmission
    {
        public string Name { get; set; }
        public DriveUnit DriveUnit { get; }
    }
}
