using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TIQRI.EMP.ApplicationCore.Entities;
using TIQRI.EMP.ApplicationCore.Interfaces;

namespace TIQRI.EMP.ApplicationCore.Services
{
    public class ClientService : IClientService
    {
        private readonly IAsyncRepository<Client> _clientRepository;

        public ClientService(IAsyncRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task CreateClientAsync(Client client)
        {
            await _clientRepository.AddAsync(client);
        }
    }
}
