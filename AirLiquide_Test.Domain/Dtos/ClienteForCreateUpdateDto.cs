using System.ComponentModel.DataAnnotations;

namespace AirLiquide_Test.Domain.Dtos
{
    public class ClienteForCreateUpdateDto
    {
        [Required(ErrorMessage = "O nome do cliente é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome do cliente não deve ultrapassar 100 caracteres")]
        public string Nome { get; set; }

        [Range(1, 150, ErrorMessage = "A idade do cliente deve estar entre 1 e 150")]
        public int Idade { get; set; }
    }
}