using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNETAPI.Models.DbModels;

public class Aeroporto
{
    [Key] 
    public int Id { get; set; }
    [Required]
    [MinLength(3)]
    [MaxLength(30)]
    public string Nome { get; set; }
    [Required]
    [Column(TypeName = "char(3)")]
    public string Cód { get; set; }
}