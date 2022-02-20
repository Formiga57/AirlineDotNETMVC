using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNETAPI.Models.DbModels;

public class AeroportoCidade
{
    [Key] 
    public int Id { get; set; }
    [ForeignKey("Cidade")] 
    public int CidadeFk { get; set; }
    public Cidade Cidade { get; set; }
    [ForeignKey("Aeroporto")] 
    public int AeroportoFk { get; set; }
    public Aeroporto Aeroporto { get; set; }
}