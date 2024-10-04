#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ChefsNDishes.Models;

public class Dish

{
    [Key]
    //UPDATE ID
    public int DishId { get; set; }


    [Required]
    [MinLength(2, ErrorMessage = "Dish name required!")]
    [MaxLength(60)]
    public string DishName { get; set; }


    [Required(ErrorMessage = "Number of calories is required!")]

    public int Calories { get; set; }
    
    
    [Required]
    [Range(1, 5 ,ErrorMessage = "Tastiness is required!")]
    public string Tastiness { get; set; }


    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    // foreign key
    public int ChefId { get;set; }
    public Chef? Creator { get;set; }
}
