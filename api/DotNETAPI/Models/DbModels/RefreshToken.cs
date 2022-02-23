using System.ComponentModel.DataAnnotations;

namespace DotNETAPI.Models.DbModels;

public class RefreshToken
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Token { get; set; }
}