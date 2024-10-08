#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models;

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