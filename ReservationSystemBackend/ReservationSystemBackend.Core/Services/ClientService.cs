using ReservationSystemBackend.Core.Entities;
using ReservationSystemBackend.Core.Interfaces;

namespace ReservationSystemBackend.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _clientRepository.GetAllClients();
        }

        public async Task<Client> GetClientById(int id)
        {
            return await _clientRepository.GetClientById(id);
        }

        public async Task CreateClient(Client client)
        {
            await _clientRepository.CreateClient(client);
        }

        public async Task<bool> UpdateClient(Client client)
        {
            return await _clientRepository.UpdateClient(client);
        }

        public async Task<bool> DeleteClientById(int id)
        {
            return await _clientRepository.DeleteClientById(id);
        }
    }
}
