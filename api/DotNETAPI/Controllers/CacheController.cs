using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNETAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNETAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        [HttpGet]
        [Route("aeroportosDisponiveis")]
        public IActionResult ObterAeroportosDisponiveis([FromServices] ICacheService cacheService)
        {
            return Ok(cacheService.ObterAeroportos(false));
        }
    }
}