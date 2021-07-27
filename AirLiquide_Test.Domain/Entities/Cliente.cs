using AirLiquide_Test.Domain.Dtos;
using System;

namespace AirLiquide_Test.Domain.Entities
{
    public class Cliente
    {
        public Cliente()
        {
        }

        public Cliente(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }

        public void Update(ClienteForCreateUpdateDto clienteForUpdateDto)
        {
            Nome = clienteForUpdateDto.Nome;
            Idade = clienteForUpdateDto.Idade;
        }
    }
}