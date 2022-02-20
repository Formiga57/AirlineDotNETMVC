using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNETAPI.Models.DbModels;

public class UsuárioVoo
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Usuário")]
    public int UsuárioFk { get; set; }
    public Usuário Usuário { get; set; }
    [ForeignKey("Voo")]
    public int VooFk { get; set; }
    public Voo Voo { get; set; }
    [Required]
    public int Assento { get; set; }
}