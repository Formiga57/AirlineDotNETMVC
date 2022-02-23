using System.Diagnostics;
using System.Security.Cryptography;
using AutoMapper;
using DefaultNamespace;
using System.Web;
using DotNETAPI.Models.DbModels;
using DotNETAPI.Models.PostModels;
using DotNETAPI.Services;
using Microsoft.AspNetCore.Mvc;
namespace DotNETAPI.Controllers;
[Route("[controller]")]
[ApiController]
public class SegurancaController : ControllerBase
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
        string refresh = segurançaService.GerarRefresh(loginModel.Email);
        Response.Cookies.Append("refresh",refresh,new CookieOptions
        {
            Secure = true,
            SameSite = SameSiteMode.None,
            HttpOnly = true,
            MaxAge = TimeSpan.FromDays(5),
        });
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
    [HttpPost]
    [Route("verificarToken")]
    public ActionResult<RetornoVerificarTokenModel> VerificarToken(VerificarTokenModel tokenModel, [FromServices] ISegurançaService segurançaService,[FromServices] IMapper mapper,[FromServices] IUsuárioService usuárioService)
    {
        string email = segurançaService.VerificarToken(tokenModel.Token);
        if (email != null)
        {
            Usuário usuário = usuárioService.EncontrarUsuário(email);
            RetornoVerificarTokenModel retorno = new RetornoVerificarTokenModel
            {
                Verificado = true
            };
            retorno.Usuário = mapper.Map<UsuárioInfos>(usuário);
            return Ok(retorno);
        }
        return Unauthorized();
    }

    [HttpGet]
    [Route("refresh")]
    public ActionResult<RetornoVerificarTokenModel> Refresh([FromServices] IMapper mapper,[FromServices] ISegurançaService segurançaService,[FromServices] IUsuárioService usuárioService)
    {
        string? refreshToken = Request.Cookies["refresh"];
        if (refreshToken == null) { return Unauthorized(); }
        string email = segurançaService.VerificarRefresh(refreshToken);
        string refresh = segurançaService.GerarRefresh(email);
        Response.Cookies.Append("refresh",refresh,new CookieOptions
        {
            Secure = true,
            SameSite = SameSiteMode.None,
            HttpOnly = true,
            MaxAge = TimeSpan.FromDays(5),
        });
        Usuário usuário = usuárioService.EncontrarUsuário(email);
        RetornoVerificarTokenModel retorno = new RetornoVerificarTokenModel
        {
            Verificado = true
        };
        retorno.Usuário = mapper.Map<UsuárioInfos>(usuário);
        retorno.Token = segurançaService.GerarToken(email);
        return Ok(retorno);
    }
}
