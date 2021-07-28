using AirLiquide_Test.API.Configuration.ErrorResponses;
using AirLiquide_Test.API.Configuration.Validations;
using AirLiquide_Test.Domain.Dtos;
using AirLiquide_Test.Domain.Interfaces;
using AirLiquide_Test.Domain.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;
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

        /// <summary>
        /// Retorna um cliente com base no ID
        /// </summary>
        /// <remarks>
        /// Exemplo do request:
        ///
        ///     GET /api/clientes/b50adf00-4808-4240-9ec6-e86bd8c7b9cb
        ///
        /// </remarks>
        /// <param name="id">Identificador único do cliente</param>
        /// <response code="200">Dados do cliente</response>
        /// <response code="400">ID informado inválido</response>
        /// <response code="404">Cliente não encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClienteForDetailsDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CustomBadRequestResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([GuidValidation(ErrorMessage = "O valor GUID é inválido")] string id)
        {
            ClienteResponse clienteResponse = await _clienteService.Get(id);

            if (!clienteResponse.Success)
            {
                return NotFound(new ErrorResponse(clienteResponse.Message));
            }

            return Ok(new ClienteForDetailsDto(clienteResponse.Resource));
        }

        /// <summary>
        /// Cria um novo cliente
        /// </summary>
        /// <remarks>
        /// Exemplo do request:
        ///
        ///     POST /api/clientes
        ///     {
        ///        "nome": "Nome do Cliente",
        ///        "idade": 50
        ///     }
        ///
        /// </remarks>
        /// <param name="clienteForCreateDto">Informações do cliente</param>
        /// <response code="201">Cliente criado com sucesso</response>
        /// <response code="400">Informações inconsistentes do cliente</response>
        /// <response code="409">Erro no processo de criação do cliente</response>
        [HttpPost]
        [ProducesResponseType(typeof(ClienteForDetailsDto), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(CustomBadRequestResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.Conflict)]
        public async Task<IActionResult> Post([FromBody] ClienteForCreateUpdateDto clienteForCreateDto)
        {
            ClienteResponse clienteResponse = await _clienteService.Create(clienteForCreateDto);

            if (!clienteResponse.Success)
            {
                return Conflict(new ErrorResponse(clienteResponse.Message));
            }

            return CreatedAtAction(nameof(Post), new ClienteForDetailsDto(clienteResponse.Resource));
        }

        /// <summary>
        /// Atualiza os dados de um cliente
        /// </summary>
        /// <remarks>
        /// Exemplo do request:
        ///
        ///     PUT /api/clientes/b50adf00-4808-4240-9ec6-e86bd8c7b9cb
        ///     {
        ///        "nome": "Nome do Cliente",
        ///        "idade": 50
        ///     }
        ///
        /// </remarks>
        /// <param name="id">Identificador único do cliente</param>
        /// <param name="clienteForUpdateDto">Informações do cliente</param>
        /// <response code="204">Cliente atualizado com sucesso</response>
        /// <response code="400">Informações inconsistentes do cliente</response>
        /// <response code="422">Erro no processo de atualização do cliente</response>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(CustomBadRequestResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> Put([GuidValidation(ErrorMessage = "O valor GUID é inválido")] string id, [FromBody] ClienteForCreateUpdateDto clienteForUpdateDto)
        {
            ClienteResponse clienteResponse = await _clienteService.Update(id, clienteForUpdateDto);

            if (!clienteResponse.Success)
            {
                return UnprocessableEntity(new ErrorResponse(clienteResponse.Message));
            }

            return NoContent();
        }

        /// <summary>
        /// Remove um cliente com base no ID
        /// </summary>
        /// <remarks>
        /// Exemplo do request:
        ///
        ///     DELETE /api/clientes/b50adf00-4808-4240-9ec6-e86bd8c7b9cb
        ///
        /// </remarks>
        /// <param name="id">Identificador único do cliente</param>
        /// <response code="204">Cliente removido com sucesso</response>
        /// <response code="400">ID informado inválido</response>
        /// <response code="404">Cliente não encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(CustomBadRequestResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([GuidValidation(ErrorMessage = "O valor GUID é inválido")] string id)
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