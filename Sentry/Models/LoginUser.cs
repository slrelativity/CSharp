#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Sentry.Models;

public class LoginUser


{
    [Required]
    [Display(Name = "Login email")]
    [EmailAddress]
    public string LoginEmail { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Login password")]
    public string LoginPassword { get; set; }
}