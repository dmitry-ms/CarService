using System;
using System.ComponentModel.DataAnnotations;

namespace CarService.Web.Models
{
    public class ClientCarVM
    {
        public Guid Id { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public int MileageKM { get; set; }
    }
}
