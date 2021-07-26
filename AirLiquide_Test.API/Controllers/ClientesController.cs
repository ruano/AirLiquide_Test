using AirLiquide_Test.Domain.Dtos;
using AirLiquide_Test.Domain.Interfaces;
using AirLiquide_Test.Domain.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AirLiquide_Test.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([StringLength(36, ErrorMessage = "Valor GUID inválido", MinimumLength = 36)] string id)
        {
            ClienteResponse clienteResponse = await _clienteService.Get(id);

            if (!clienteResponse.Success)
            {
                return NotFound(clienteResponse.Message);
            }

            return Ok(clienteResponse.Resource);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteForCreateUpdateDto clienteForCreateDto)
        {
            ClienteResponse clienteResponse = await _clienteService.Add(clienteForCreateDto);

            return CreatedAtAction(nameof(Post), clienteResponse.Resource);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] ClienteForCreateUpdateDto clienteForUpdateDto)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}