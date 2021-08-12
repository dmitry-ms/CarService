using CarService.App.Constants;
using CarService.App.Interfaces;
using CarService.App.Mapper;
using CarService.App.Models;
using CarService.Entities.Users;
using CarService.Repositories;
using System;
using System.Threading.Tasks;

namespace CarService.App.Services
{
    public class AccountService : IAccountService
    {
        private readonly IIdentityService _identityService;
        private readonly IClientRepository _clientRepository;

        public AccountService(IIdentityService identityService, IClientRepository clientRepository)
        {
            _identityService = identityService;
            _clientRepository = clientRepository;
        }

        public async Task RegisterClientAsync(RegistrationClientModel model)
        {
            var client = ObjectMapper.Mapper.Map<Client>(model);
            client.Id = Guid.NewGuid();

            await _clientRepository.AddAsync(client);

            var result = await _identityService.CreateUserAsync(model.Email, model.Password, RoleNames.CLIENT, client);
            if (!result.Result.Succeeded)
            {
                //throw new BadRequestException();
            }
            await _clientRepository.SaveChangesAsync();
        }

        //public Task<TResult> LoginAsync(LoginModel model)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public Task RegisterCarServiceAdminAsync(RegistrationAdmin model)
        //{
        //    throw new System.NotImplementedException();
        //}        

        //public Task RegisterServiceManAsync(RegistrationServiceManModel model)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
