using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedLib.IServices;

namespace WebMinotaur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly ITokenService tokenService;
        public TestsController(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        [HttpGet]
        [Route("generate/{id}")]
        public string GenerateToken(string id)
        {
            return tokenService.GenerateTokenDevice(id).ToString();
        }

        [HttpPost]
        [Route("decode/")]
        public string DecodeToken([FromBody]TokenModel model)
        {
            return tokenService.DecodeToken(model.token).ToString();
        }
        
    }
    public class TokenModel
    {
        public string token { get; set; } 
    }
}