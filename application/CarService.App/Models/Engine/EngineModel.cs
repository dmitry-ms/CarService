using System;

namespace CarService.App.Models
{
    public abstract class EngineModel
    {
        public Guid Id { get; set; }
        public string NameEngine { get; set; }
        public int EnginePowerKW { get; set; }
    }
}
