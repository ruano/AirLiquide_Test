using AirLiquide_Test.Domain.Entities;
using AirLiquide_Test.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AirLiquide_Test.Database.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ClienteRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Cliente> FindByIdAsync(string id)
        {
            return await _databaseContext.Clientes.FirstOrDefaultAsync(c => c.Id.ToString() == id);
        }

        public async Task AddOneAsync(Cliente cliente)
        {
            await _databaseContext.Clientes.AddAsync(cliente);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task UpdateOneAsync(Cliente cliente)
        {
            _databaseContext.Clientes.Update(cliente);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task RemoveOneAsync(Cliente cliente)
        {
            _databaseContext.Clientes.Remove(cliente);
            await _databaseContext.SaveChangesAsync();
        }
    }
}