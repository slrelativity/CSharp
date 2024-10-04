#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginAndRegistration.Models;

public class LoginUser

{
    [Required]
    [Display(Name ="LoginEmail")]
    [EmailAddress]
    public string LoginEmail { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    [Display(Name ="LoginPassword")]
    public string LoginPassword { get; set; }
}