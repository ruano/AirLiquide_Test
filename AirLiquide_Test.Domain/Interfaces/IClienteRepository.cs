using AirLiquide_Test.Domain.Entities;
using System.Threading.Tasks;

namespace AirLiquide_Test.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task AddAsync(Cliente cliente);
        Task<Cliente> FindByIdAsync(string id);
        void Remove(Cliente cliente);
        void Update(Cliente cliente);
    }
}