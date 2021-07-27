using CarService.App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarService.App.Interfaces
{
    public interface IClientCarService
    {
        public Task<IEnumerable<ClientCarModel>> GetAllClientCars(Guid clientId);
    }
}
