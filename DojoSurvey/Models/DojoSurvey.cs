// Disables warning notifications
#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DojoSurvey.Models;

public class Survey

{
    [DisplayName("Name")]
    [Required(ErrorMessage = "Your name is required!")]
    [MinLength(2)]
    public string Name { get; set; }
    [Required(ErrorMessage = "Please select your Dojo Location. It's required!")]
    public string Location { get; set; }
    [Required(ErrorMessage = "Please select the programming language. It's required!")]
    public string Language { get; set; }
    [MinLength(20, ErrorMessage = "Minimum length of comment is 20 characters.")]
    public string? Comment { get; set; }
}