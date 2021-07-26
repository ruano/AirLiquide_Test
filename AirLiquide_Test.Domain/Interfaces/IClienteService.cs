using AirLiquide_Test.Domain.Dtos;
using AirLiquide_Test.Domain.Responses;
using System.Threading.Tasks;

namespace AirLiquide_Test.Domain.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteResponse> Add(ClienteForCreateUpdateDto clienteForCreateDto);
        Task<ClienteResponse> Get(string id);
        ClienteResponse Remove(string id);
        ClienteResponse Update(ClienteForCreateUpdateDto clienteForUpdateDto);
    }
}