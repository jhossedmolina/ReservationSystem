using ReservationSystemBackend.Core.Entities;
using ReservationSystemBackend.Core.Interfaces;
using ReservationSystemBackend.Infraestructure.Data;

namespace ReservationSystemBackend.Infraestructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ReservationSystemDbContext _context;

        public ClientRepository(ReservationSystemDbContext context)
        {
            _context = context;    
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _context.Clients.ToList();
        }

        public async Task<Client> GetClientById(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task CreateClient(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateClient(Client client)
        {
            var currentClient = await GetClientById(client.Id);
            currentClient.FirstName = client.FirstName;
            currentClient.LastName = client.LastName;
            currentClient.Email = client.Email;
            currentClient.Username = client.Username;
            currentClient.Password = client.Password;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteClientById(int id)
        {
            var currentClient = await GetClientById(id);
            _context.Remove(currentClient);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
