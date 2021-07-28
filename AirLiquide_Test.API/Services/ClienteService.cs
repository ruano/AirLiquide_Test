using AirLiquide_Test.Domain.Dtos;
using AirLiquide_Test.Domain.Entities;
using AirLiquide_Test.Domain.Interfaces;
using AirLiquide_Test.Domain.Services.Responses;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AirLiquide_Test.API.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ILogger<ClienteService> _logger;

        public ClienteService(IClienteRepository clienteRepository, ILogger<ClienteService> logger)
        {
            _clienteRepository = clienteRepository;
            _logger = logger;
        }

        public async Task<ClienteResponse> Get(string id)
        {
            _logger.LogDebug($"Obtendo cliente ID '{id}'");

            Cliente cliente = await _clienteRepository.FindByIdAsync(Guid.Parse(id));

            return cliente == null
                ? new ClienteResponse("Cliente não encontrado.")
                : new ClienteResponse(cliente);
        }

        public async Task<ClienteResponse> Create(ClienteForCreateUpdateDto clienteForCreateDto)
        {
            if (await _clienteRepository.FindByNameAsync(clienteForCreateDto.Nome) != null)
            {
                return new ClienteResponse($"Cliente com o nome {clienteForCreateDto.Nome} já existe na base de dados.");
            }

            _logger.LogDebug($"Criação do cliente '{clienteForCreateDto.Nome}'");

            Cliente cliente = new(clienteForCreateDto.Nome, clienteForCreateDto.Idade);

            await _clienteRepository.AddOneAsync(cliente);

            return new ClienteResponse(cliente);
        }

        public async Task<ClienteResponse> Update(string id, ClienteForCreateUpdateDto clienteForUpdateDto)
        {
            Cliente cliente = await _clienteRepository.FindByIdAsync(Guid.Parse(id));

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

            _logger.LogDebug($"Atualização do cliente '{clienteForUpdateDto.Nome}'");

            cliente.Update(clienteForUpdateDto);
            await _clienteRepository.UpdateOneAsync(cliente);

            return new ClienteResponse(cliente);
        }

        public async Task<ClienteResponse> Remove(string id)
        {
            Cliente cliente = await _clienteRepository.FindByIdAsync(Guid.Parse(id));

            if (cliente == null)
            {
                return new ClienteResponse("Cliente não encontrado.");
            }

            _logger.LogDebug($"Atualização do cliente ID '{id}'");

            await _clienteRepository.RemoveOneAsync(cliente);

            return new ClienteResponse((Cliente)null);
        }
    }
}