using AirLiquide_Test.Domain.Dtos;

namespace AirLiquide_Test.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public Cliente()
        {
        }

        public Cliente(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;
        }

        public string Nome { get; set; }
        public int Idade { get; set; }

        public void Update(ClienteForCreateUpdateDto clienteForUpdateDto)
        {
            Nome = clienteForUpdateDto.Nome;
            Idade = clienteForUpdateDto.Idade;
        }
    }
}