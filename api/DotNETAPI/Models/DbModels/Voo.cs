using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNETAPI.Models.DbModels;

public class Voo
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("OrigemId")]
    public Aeroporto? Origem { get; set; }
    [ForeignKey("DestinoId")]
    public Aeroporto? Destino { get; set; }
    [ForeignKey("Avião")]
    public int AviãoFk { get; set; }
    public Avião Avião { get; set; }
    [Required]
    [Column(TypeName = "char(6)")]
    public string CódVoo { get; set; }
    [Required]
    public DateTime Embarque { get; set; }
}