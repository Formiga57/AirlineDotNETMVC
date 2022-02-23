using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using DotNETAPI.Contexts;
using DotNETAPI.Models.DbModels;
using Microsoft.IdentityModel.Tokens;

namespace DotNETAPI.Services;

public interface ISegurançaService
{
    public string GerarToken(string email);
    public string? VerificarToken(string token);
    public string GerarRefresh(string email);
    public string? VerificarRefresh(string refresh);
}

public class SegurançaService : ISegurançaService
{
    public SqlContext _context;
    public SegurançaService(SqlContext context)
    {
        _context = context;
    }
    public string GerarToken(string email)
    {
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        byte[] key = Encoding.ASCII.GetBytes(Settings.JWTKey);
        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature),
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("email",email)
            })
        };
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public string? VerificarToken(string token)
    {
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        byte[] key = Encoding.ASCII.GetBytes(Settings.JWTKey);
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);
            JwtSecurityToken jwtToken = (JwtSecurityToken) validatedToken;
            string email = jwtToken.Claims.First(x=>x.Type == "email").Value;
            return email;
        }catch
        {
            return null;
        }
    }

    public string GerarRefresh(string email)
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        string refreshToken = Convert.ToBase64String(randomNumber);
        var oldToken = _context.RefreshTokens.FirstOrDefault(x => x.Email == email);
        RefreshToken refreshTokenmodel = new RefreshToken {Email = email, Token = refreshToken};
        if (oldToken == null)
        {
            _context.RefreshTokens.Add(refreshTokenmodel);
            _context.SaveChanges();
        }
        else
        {
            oldToken.Token = refreshToken;
            _context.SaveChanges();
        }

        return refreshToken;
    }

    public string? VerificarRefresh(string refresh)
    {
        var refreshTokens = _context.RefreshTokens.FirstOrDefault(x => x.Token == refresh);
        if (refreshTokens == null) {return null;}
        return refreshTokens.Email;
    }
}