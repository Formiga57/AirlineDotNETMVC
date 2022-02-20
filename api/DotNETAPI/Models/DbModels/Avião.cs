using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNETAPI.Models.DbModels;

public class Avião
{
    [Key] 
    public int Id { get; set; }
    [Column(TypeName = "varchar(4)")] 
    public string Cód { get; set; }
    public int AssentosTotais { get; set; }
    public int Fileiras { get; set; }
}