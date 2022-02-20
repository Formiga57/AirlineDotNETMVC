using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNETAPI.Models.DbModels;
public class Usuário
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MinLength(3)]
    [MaxLength(40)]
    public string Nome { get; set; }
    [Required]
    [MinLength(16)]
    [MaxLength(150)]
    public int Idade { get; set; }
    [Required]
    public float Milhas { get; set; }
}