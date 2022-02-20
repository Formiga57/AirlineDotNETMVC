using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNETAPI.Models.DbModels;

public class Cidade
{
    [Key] 
    public int Id { get; set; }
    [Required]
    [MinLength(3)]
    [MaxLength(30)]
    public string Nome { get; set; }
    [Required]
    [Column(TypeName = "char(2)")]
    public string UF { get; set; }
}