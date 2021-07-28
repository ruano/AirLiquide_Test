using AirLiquide_Test.Domain.Entities;

namespace AirLiquide_Test.Domain.Dtos
{
    public class ClienteForDetailsDto
    {
        public ClienteForDetailsDto(Cliente cliente)
        {
            Id = cliente.Id.ToString();
            Nome = cliente.Nome;
            Idade = cliente.Idade;
        }

        public string Id { get; private set; }
        public string Nome { get; private set; }
        public int Idade { get; private set; }
    }
}