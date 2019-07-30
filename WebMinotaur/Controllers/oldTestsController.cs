using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedLib;
using SharedLib.IServices;
using WebMinotaur.Data;

namespace WebMinotaur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class oldTestsController : ControllerBase
    {
        private readonly ITokenService tokenService;
        private readonly ApplicationDbContext db;
        public oldTestsController(ITokenService tokenService, ApplicationDbContext db)
        {
            this.tokenService = tokenService;
            this.db = db;
        }

        [HttpGet]
        [Route("generate/{id}")]
        public string GenerateToken(string id)
        {
            return tokenService.GenerateToken(id).ToString();
        }

        [HttpPost]
        [Route("decode/")]
        public string DecodeToken([FromBody]TokenModel model)
        {
            return tokenService.DecodeToken(model.token).ToString();
        }

        [HttpPost]
        [Route("addInfoIP/")]
        public InfoIP addInfoIp([FromBody]InfoIP infoIp)
        {
            var toInsertInfo = new InfoIP {
                Ip = infoIp.Ip,
                Record = DateTime.UtcNow,
                DeviceId = infoIp.DeviceId
            };
            db.InfoIP.Add(toInsertInfo);
            db.SaveChanges();
            return toInsertInfo;
        }
        
    }
    public class TokenModel
    {
        public string token { get; set; } 
    }
}