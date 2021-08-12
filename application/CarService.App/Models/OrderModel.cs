using System;
using System.Collections.Generic;

namespace CarService.App.Models
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public DateTime DateAdded { get; set; }
        public ClientCarModel Car { get; set; } 
        public virtual IEnumerable<ServiceInfoModel> Services { get; set; } = new List<ServiceInfoModel>();
    }
}
