using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLiquide_Test.API.Responses
{
    public abstract class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}