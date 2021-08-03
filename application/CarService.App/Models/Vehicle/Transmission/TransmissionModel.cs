using CarService.Enums;
using System;

namespace CarService.App.Models
{
    public abstract class TransmissionModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DriveUnit DriveUnit { get; set; }
    }
}
