#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sessions.Models;

public class User

{
    [Required]
    public string Name { get; set; }
}