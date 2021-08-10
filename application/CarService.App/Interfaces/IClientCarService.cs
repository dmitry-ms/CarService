using CarService.App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarService.App.Interfaces
{
    public interface IClientCarService
    {
        Task<IEnumerable<ClientCarModel>> GetAllClientCars(string clientId);

        Task AddClientCarAsync(AddClientCarModel model);
    }
}
