#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ProductsAndCategories.Models;

public class Product

{
    [Key]
    //UPDATE ID
    public int ProductId { get; set; }

    
    [Required]
    [MinLength(2, ErrorMessage = "A name is required!")]
    [MaxLength(60)]
    public string Name { get; set; }
    
    
    [Required]
    [MinLength(2, ErrorMessage = "A Description is required!")]
    [MaxLength(60)]
    public string Description { get; set; }
    
    
    [Required]
    [MinLength(2, ErrorMessage = "A price is required!")]
    
    public double Price { get; set; }

    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public List<Category> allCategories { get;set; } = new();
}