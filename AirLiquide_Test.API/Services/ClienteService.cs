using AirLiquide_Test.Domain.Dtos;
using AirLiquide_Test.Domain.Entities;
using AirLiquide_Test.Domain.Interfaces;
using AirLiquide_Test.Domain.Responses;
using System.Threading.Tasks;

namespace AirLiquide_Test.API.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ClienteResponse> Get(string id)
        {
            Cliente cliente = await _clienteRepository.FindByIdAsync(id);

            return cliente == null
                ? new ClienteResponse("Cliente não encontrado.")
                : new ClienteResponse(cliente);
        }

        public async Task<ClienteResponse> Add(ClienteForCreateUpdateDto clienteForCreateDto)
        {
            if (await _clienteRepository.FindByNameAsync(clienteForCreateDto.Nome) != null)
            {
                return new ClienteResponse($"Cliente com o nome {clienteForCreateDto.Nome} já existe na base de dados.");
            }

            Cliente cliente = new(clienteForCreateDto.Nome, clienteForCreateDto.Idade);

            await _clienteRepository.AddOneAsync(cliente);

            return new ClienteResponse(cliente);
        }

        public async Task<ClienteResponse> Update(string id, ClienteForCreateUpdateDto clienteForUpdateDto)
        {
            Cliente cliente = await _clienteRepository.FindByIdAsync(id);

            if (cliente == null)
            {
                return new ClienteResponse("Cliente não encontrado.");
            }

            if (!cliente.Nome.Equals(clienteForUpdateDto.Nome))
            {
                if (await _clienteRepository.FindByNameAsync(clienteForUpdateDto.Nome) != null)
                {
                    return new ClienteResponse($"Cliente com o nome {clienteForUpdateDto.Nome} já existe na base de dados.");
                }
            }

            cliente.Update(clienteForUpdateDto);
            await _clienteRepository.UpdateOneAsync(cliente);

            return new ClienteResponse(cliente);
        }

        public async Task<ClienteResponse> Remove(string id)
        {
            Cliente cliente = await _clienteRepository.FindByIdAsync(id);

            if (cliente == null)
            {
                return new ClienteResponse("Cliente não encontrado.");
            }

            await _clienteRepository.RemoveOneAsync(cliente);

            return new ClienteResponse((Cliente)null);
        }
    }
}