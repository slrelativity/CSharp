#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ChefsNDishes.Models;

public class Chef

{
    [Key]
    //UPDATE ID
    public int ChefId { get; set; }


    [Required]
    [MinLength(2, ErrorMessage = "A first name is required!")]
    [MaxLength(60)]
    public string FirstName { get; set; }


    [Required]
    [MinLength(2, ErrorMessage = "A last name is required!")]
    [MaxLength(60)]
    public string LastName { get; set; }


    [DisplayName("Date of Birth")]
    [Required]
    [DataType(DataType.Date)]
    [PastDate]
    public DateTime? Date { get; set; }



    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public List<Dish> tasytyDishes { get;set; } = new();
    
}


public class PastDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Date of Birth is required.");
        }
        // You first may want to unbox "value" here and cast to to a DateTime variable!
        if (((DateTime)value!) > DateTime.Now)
        {
            return new ValidationResult("Date of Birth must be in the past! ");
        }
        else
        {
            return ValidationResult.Success;
        }
    }
}
