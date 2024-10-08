#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models;

public class Wedding

{
    internal int weddingId;

    [Key]
    //UPDATE ID
    public int WeddingId { get; set; }


    [Required]
    [MinLength(2, ErrorMessage = "A Wedder One name is required!")]
    [MaxLength(60)]
    public string WedderOne { get; set; }


    [Required]
    [MinLength(2, ErrorMessage = "A Wedder One name is required!")]
    [MaxLength(60)]
    public string WedderTwo { get; set; }



    [DisplayName("Wedding Date")]
    [Required]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }


    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    //Foriegn key
    public int UserId { get;set; }


    //NAVPROPS
    public User? RSVPer { get;set; }
    public List<RSVP> UserRSVPs { get; set; } = new ();
}


public class WeddingDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Wedding Date is required!");
        }
        // You first may want to unbox "value" here and cast to to a DateTime variable!
        if (((DateTime)value!) < DateTime.Now)
        {
            return new ValidationResult("Wedding Date must be in the future!");
        }
        else
        {
            return ValidationResult.Success;
        }
    }
}
