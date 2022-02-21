using System.Diagnostics;
using DefaultNamespace;
using DotNETAPI.Models.PostModels;
using DotNETAPI.Services;
using Microsoft.AspNetCore.Mvc;
namespace DotNETAPI.Controllers;
[Route("[controller]")]
[ApiController]
public class SegurançaController : ControllerBase
{
    [HttpPost]
    [Route("login")]
    public IActionResult Login(LoginModel loginModel, [FromServices] ISegurançaService segurançaService,[FromServices] IUsuárioService usuárioService)
    {
        var usuário = usuárioService.EncontrarUsuário(loginModel.Email);
        if (usuário == null)
        {
            return Unauthorized("Usuário não existente");
        }

        if (!BCrypt.Net.BCrypt.Verify(loginModel.Senha, usuário.HashSenha))
        {
            return Unauthorized("Senha errada");
        }
        string token = segurançaService.GerarToken(loginModel.Email);
        return Ok(token);
    }
    [HttpPost]
    [Route("registro")]
    public IActionResult Registro(RegistroModel registroModel,[FromServices] IUsuárioService usuárioService)
    {
        if (usuárioService.EncontrarUsuário(registroModel.Email) != null)
        {
            return Unauthorized("Usuário já existente");
        }
        string hashSenha = BCrypt.Net.BCrypt.HashPassword(registroModel.Senha);
        int usuárioId = usuárioService.AdicionarUsuário(registroModel.Nome,registroModel.Idade,hashSenha,registroModel.Email);
        return Ok(usuárioId);
    }
}
