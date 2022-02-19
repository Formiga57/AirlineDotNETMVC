using System.Diagnostics;
using DotNETAPI.Services;
using Microsoft.AspNetCore.Mvc;
namespace DotNETAPI.Controllers;
[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpGet]
    public string CheckLoggedIn()
    {
        return "Logado?";
    }

    [HttpPost]
    [Route("login")]
    public string GenerateJwt([FromServices] ITokenService tokenService)
    {
        return tokenService.GenerateToken();
    }
}
