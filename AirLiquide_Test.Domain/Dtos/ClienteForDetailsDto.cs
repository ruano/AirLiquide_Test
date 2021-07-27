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

        public string Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}