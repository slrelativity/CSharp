#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Dishes.Models;

public class Dish

{
    [Key]
    public int DishId { get; set; }


    [Required]
    [MinLength(2, ErrorMessage = "A dish name is required!")]
    [MaxLength(60)]
    public string Name { get; set; }


    [Required]
    [MinLength(2, ErrorMessage = "A chef name is required!")]
    [MaxLength(60)]
    public string Chef { get; set; }


    [Required]
    [Range(1, 5)]
    public int Tastiness { get; set; }


    [Required]
    [Range(1, 5000)]
    public int Calories { get; set; }


    [Required]
    [MinLength(2, ErrorMessage = "A description is required!")]
    public string Description { get; set; }
    
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
