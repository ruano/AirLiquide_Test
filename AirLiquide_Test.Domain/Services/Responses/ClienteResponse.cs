using AirLiquide_Test.Domain.Entities;

namespace AirLiquide_Test.Domain.Services.Responses
{
    public class ClienteResponse : BaseResponse<Cliente>
    {
        public ClienteResponse(Cliente resource) : base(resource)
        {
        }

        public ClienteResponse(string message) : base(message)
        {
        }
    }
}