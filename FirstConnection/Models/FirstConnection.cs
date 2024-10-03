#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace FirstConnection.Models;
using System.ComponentModel;
public class Monster


{
    [Key]
    [Required]
    public int MonsterId { get; set; }
    [DisplayName("Name")]
    [Required]
    [MinLength(3)]
    public string Name { get; set; }
    [Required]
    public int Height { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}