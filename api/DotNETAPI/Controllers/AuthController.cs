using System.Diagnostics;
using DefaultNamespace;
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
    public string GenerateJwt([FromServices] ITokenService tokenService,[FromServices] ISqlRepo sqlRepo)
    {
        sqlRepo.AddUser("Formiga");
        return tokenService.GenerateToken();
    }
}
