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
            return await _databaseContext.Clientes.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Cliente cliente)
        {
            await _databaseContext.Clientes.AddAsync(cliente);
        }

        public void Update(Cliente cliente)
        {
            _databaseContext.Clientes.Update(cliente);
        }

        public void Remove(Cliente cliente)
        {
            _databaseContext.Clientes.Remove(cliente);
        }
    }
}