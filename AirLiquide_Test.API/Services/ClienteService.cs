using AirLiquide_Test.API.Dtos;
using AirLiquide_Test.API.Responses;
using AirLiquide_Test.Domain.Interfaces;
using System;

namespace AirLiquide_Test.API.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public ClienteResponse Get(string id)
        {
            throw new NotImplementedException();
        }

        public ClienteResponse Add(ClienteForCreateUpdateDto clienteForCreateDto)
        {
            throw new NotImplementedException();
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