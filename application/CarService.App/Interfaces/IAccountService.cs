using CarService.App.Models;
using System.Threading.Tasks;

namespace CarService.App.Interfaces
{
    public interface IAccountService
    {
        Task RegisterClientAsync(RegistrationClientModel model);

        //Task RegisterCarServiceAdminAsync(RegistrationAdmin model);
        //Task RegisterServiceManAsync(RegistrationServiceManModel model);
        //Task<> LoginAsync(LoginModel model);
    }
}
