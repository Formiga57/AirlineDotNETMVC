using System.ComponentModel.DataAnnotations;

namespace DotNETAPI.Models.PostModels;

public class RegistroModel
{
    [Required]
    public string Nome { get; set; }
    [Required]
    public int Idade { get; set; }
    [Required]
    public string Senha { get; set; }
    [Required]
    public string Email { get; set; }
    
}