using AirLiquide_Test.Domain.Entities;
using AirLiquide_Test.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AirLiquide_Test.Database.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<Cliente> FindByNameAsync(string name)
        {
            return await DatabaseContext.Clientes.FirstOrDefaultAsync(c => c.Nome.ToLower().Equals(name.ToLower()));
        }
    }
}