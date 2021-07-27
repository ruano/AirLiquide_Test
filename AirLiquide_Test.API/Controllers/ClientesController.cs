using AirLiquide_Test.API.Configuration.ErrorResponses;
using AirLiquide_Test.Domain.Dtos;
using AirLiquide_Test.Domain.Interfaces;
using AirLiquide_Test.Domain.Responses;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AirLiquide_Test.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([StringLength(36, ErrorMessage = "ID inválido", MinimumLength = 36)] string id)
        {
            ClienteResponse clienteResponse = await _clienteService.Get(id);

            if (!clienteResponse.Success)
            {
                return NotFound(new ErrorResponse(clienteResponse.Message));
            }

            return Ok(new ClienteForDetailsDto(clienteResponse.Resource));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteForCreateUpdateDto clienteForCreateDto)
        {
            ClienteResponse clienteResponse = await _clienteService.Add(clienteForCreateDto);

            if (!clienteResponse.Success)
            {
                return Conflict(new ErrorResponse(clienteResponse.Message));
            }

            return CreatedAtAction(nameof(Post), new ClienteForDetailsDto(clienteResponse.Resource));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([StringLength(36, ErrorMessage = "ID inválido", MinimumLength = 36)] string id, [FromBody] ClienteForCreateUpdateDto clienteForUpdateDto)
        {
            ClienteResponse clienteResponse = await _clienteService.Update(id, clienteForUpdateDto);

            if (!clienteResponse.Success)
            {
                return UnprocessableEntity(new ErrorResponse(clienteResponse.Message));
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([StringLength(36, ErrorMessage = "ID inválido", MinimumLength = 36)] string id)
        {
            ClienteResponse clienteResponse = await _clienteService.Remove(id);

            if (!clienteResponse.Success)
            {
                return NotFound(new ErrorResponse(clienteResponse.Message));
            }

            return NoContent();
        }
    }
}