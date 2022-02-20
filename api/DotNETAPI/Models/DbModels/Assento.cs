using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNETAPI.Models.DbModels;

public class Assento
{
    [Key] public int Id { get; set; }
    [MinLength(3)]
    [MaxLength(40)]
    public string NomeViajante { get; set; }
    [Column(TypeName = "char(1)")]
    public string Fileira { get; set; }
    public int Seção { get; set; }
    public bool Reservado { get; set; } = false;
    [ForeignKey("Voo")]
    public int VooFk { get; set; }
    public Voo Voo { get; set; }
    [ForeignKey("Usuário")]
    public int UsuárioFk { get; set; }
    public Usuário Usuário { get; set; }
}