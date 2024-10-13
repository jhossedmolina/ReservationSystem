using ReservationSystemBackend.Core.Entities;

namespace ReservationSystemBackend.Core.Interfaces
{
    public interface IClientService
    {
        IEnumerable<Client> GetAllClients();

        Task<Client> GetClientById(int id);

        Task CreateClient(Client client);

        Task<bool> UpdateClient(Client client);

        Task<bool> DeleteClientById(int id);
    }
}
