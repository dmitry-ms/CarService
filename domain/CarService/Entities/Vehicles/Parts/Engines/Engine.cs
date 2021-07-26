using CarService.Entities.Base;
using CarService.Interfaces;

namespace CarService.Entities.Vehicles.Parts.Engines
{
    public abstract class Engine : Entity, IEngine
    {
        public string NameEngine { get; set; }
        public int EnginePowerKW { get; set; }
    }
}
