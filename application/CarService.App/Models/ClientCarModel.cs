using System;

namespace CarService.App.Models
{
    public class ClientCarModel
    {
        public Guid Id { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public int MileageKM { get; set; }
    }
}
