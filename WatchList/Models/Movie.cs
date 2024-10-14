#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace WatchList.Models;

public class Movie

{
    [Key]
    //UPDATE ID
    public int MovieId { get; set; }

    
    [Required]
    [MinLength(2, ErrorMessage = "A Title is required!")]
    [MaxLength(60)]
    public string Title { get; set; }
    
    
    [Required]
    [MinLength(2, ErrorMessage = "A Genre is required!")]
    [MaxLength(60)]
    public string Genre { get; set; }
    
    
    [Required]
    [DataType(DataType.Date)]
    [DisplayName("Release Date")]
    [NoFutureDate]
    public DateTime? ReleaseDate { get; set; } 
    
    
    [Required]
    [MinLength(10, ErrorMessage = "A Synopsis is required!")]
    public string Synopsis { get; set; }
    
    
    
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    //FORIEGN KEY
    public int UserId { get;set; }

    //NAVPROPS
    public User? Rater { get; set; } 
    public List<UserMovieRating> UserRatings { get;set; } = [];
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

