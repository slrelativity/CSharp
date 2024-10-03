// Disables warning notifications
#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace Date.Models;

public class DateForm

{
    
    [Required]
    [DataType(DataType.Date)]
    [NoFutureDate]
    [DisplayName("Date" )]
    public DateTime? PastDate { get; set; } 
}

public class NoFutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Date is required.");
        }
        // You first may want to unbox "value" here and cast to to a DateTime variable!
        if (((DateTime)value!)  > DateTime.Now) 
        {
            return new ValidationResult("Date must be before today's date! ");
        } else {
            return ValidationResult.Success;
        }
    }
}
