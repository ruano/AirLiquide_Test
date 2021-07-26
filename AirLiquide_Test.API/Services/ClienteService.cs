using AirLiquide_Test.Domain.Dtos;
using AirLiquide_Test.Domain.Entities;
using AirLiquide_Test.Domain.Interfaces;
using AirLiquide_Test.Domain.Responses;
using System;
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
            Cliente cliente = new(clienteForCreateDto.Nome, clienteForCreateDto.Idade);

            await _clienteRepository.AddOneAsync(cliente);

            return new ClienteResponse(cliente);
        }

        public ClienteResponse Update(ClienteForCreateUpdateDto clienteForUpdateDto)
        {
            throw new NotImplementedException();
        }

        public ClienteResponse Remove(string id)
        {
            throw new NotImplementedException();
        }
    }
}