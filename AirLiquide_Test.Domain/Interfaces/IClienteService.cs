using AirLiquide_Test.Domain.Dtos;
using AirLiquide_Test.Domain.Responses;
using System.Threading.Tasks;

namespace AirLiquide_Test.Domain.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteResponse> Add(ClienteForCreateUpdateDto clienteForCreateDto);
        Task<ClienteResponse> Get(string id);
        Task<ClienteResponse> Remove(string id);
        Task<ClienteResponse> Update(string id, ClienteForCreateUpdateDto clienteForUpdateDto);
    }
}