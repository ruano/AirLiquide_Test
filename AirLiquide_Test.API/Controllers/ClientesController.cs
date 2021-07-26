using AirLiquide_Test.API.Dtos;
using AirLiquide_Test.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public IActionResult Get(string id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Post([FromBody] ClienteForCreateUpdateDto clienteForCreateDto)
        {
            throw new NotImplementedException();
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