﻿using AirLiquide_Test.Domain.Entities;
using System.Threading.Tasks;

namespace AirLiquide_Test.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task AddOneAsync(Cliente cliente);
        Task<Cliente> FindByIdAsync(string id);
        Task<Cliente> FindByNameAsync(string name);
        Task RemoveOneAsync(Cliente cliente);
        Task UpdateOneAsync(Cliente cliente);
    }
}