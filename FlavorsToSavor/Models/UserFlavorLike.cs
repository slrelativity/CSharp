#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace FlavorsToSavor.Models;

public class UserFlavorLike

{
    [Key]
    //UPDATE ID
    public int UserFlavorLikeId { get; set; }

    
    [Required]
    [MinLength(2, ErrorMessage = "A name is required!")]
    [MaxLength(60)]
    public string Name { get; set; }

    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}