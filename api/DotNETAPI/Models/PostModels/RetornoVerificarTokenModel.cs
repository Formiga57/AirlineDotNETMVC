using System.ComponentModel.DataAnnotations;

namespace DotNETAPI.Models.PostModels;

public class RetornoVerificarTokenModel
{
    public bool Verificado { get; set; }
    public UsuárioInfos? Usuário { get; set; }
    public string? Token { get; set; }
}

public class UsuárioInfos
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Email { get; set; }
    public float Milhas { get; set; }
}