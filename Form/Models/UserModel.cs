// Disables warning notifications
#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Form.Models;

public class User

{
    [DisplayName("Name")]
    [Required(ErrorMessage = "Your Name is required!")]
    [MinLength(2)]
    public string Name { get; set; }

    [DisplayName("EmailAddress")]
    [Required(ErrorMessage = "Your Email Address is required!")]
    [DataType(DataType.EmailAddress)]
    [MinLength(2)]
    public string Email { get; set; }
    
    [DisplayName("Password")]
    [Required(ErrorMessage = "Your Password is required!")]
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string Password { get; set; }
    
    [DisplayName("Date of Birth" )]
    [Required]
    [DataType(DataType.Date)]
    [NoFutureDate]
    public DateTime? Date  { get; set; }

    [DisplayName("FavoriteOddNumber")]
    [Required(ErrorMessage = "Your Favorite Odd Number is required!") ]
    [MinLength(1)]
    [OddNumber]
    public string? OddNumber { get; set; }
}

public class NoFutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Date of Birth is required.");
        }
        // You first may want to unbox "value" here and cast to to a DateTime variable!
        if (((DateTime)value!)  > DateTime.Now) 
        {
            return new ValidationResult("Date of Birth must be in the past! ");
        } else {
            return ValidationResult.Success;
        }
    }
}

public class OddNumberAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string strValue && int.TryParse(strValue, out int number))
        {
            if (number % 2 != 0)
            {
                {
                    return ValidationResult.Success;
                }
            }
        }
        return new ValidationResult("The number you entered must be an odd number!");
    }
}