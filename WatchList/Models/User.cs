#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WatchList.Models;

public class User

{
    [Key]
    //UPDATE ID
    public int UserId { get; set; }


    [Required]
    [MinLength(2, ErrorMessage = "A first name is required!")]
    [MaxLength(60)]
    public string FirstName { get; set; }


    [Required]
    [MinLength(2, ErrorMessage = "A last name is required!")]
    [MaxLength(60)]
    public string LastName { get; set; }


    [Required]
    [MinLength(2, ErrorMessage = "An email address is required!")]
    [UniqueEmail]
    [EmailAddress]
    public string Email { get; set; }


    [Required]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters is required!")]
    public string Password { get; set; }


    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    [Required]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Confirmation password is required!")]
    [NotMapped]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }


    //NAVPROPS
    public List<Movie> RatedMovie { get;set; } = [];
    public List<UserMovieRating> MovieRatings { get;set; } = [];
}




public class UniqueEmailAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Email is required!");
        }
        MyContext _context = (MyContext)validationContext.GetService(typeof(MyContext));
        if (_context.Users.Any(e => e.Email == value.ToString()))
        {
            return new ValidationResult("Email must be unique!");
        }
        else
        {
            // If no, proceed
            return ValidationResult.Success; // WHY IS THE SUCCESS??
        }
    }
}