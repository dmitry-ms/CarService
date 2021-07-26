using CarService.App.Models;
using System.Threading.Tasks;

namespace CarService.App.Interfaces
{
    public interface IAccountService
    {
       //Task RegisterCarServiceAdminAsync(RegistrationAdmin model);
        //Task RegisterServiceManAsync(RegistrationServiceManModel model);
        Task RegisterClientAsync(RegistrationClientModel model);
        //Task<> LoginAsync(LoginModel model);
    }
}
