#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Sentry.Models;

public class Device

{
    [Key]
    //UPDATE ID
    public int DeviceId { get; set; }
    
    
    [Required]
    public string SerialNumber { get; set; }
    
    
    [Required]
    public string HostName { get; set; }
    
    
    [Required]
    public int Badge { get; set; }
    
    
    [Required]
    public string EmployeeName { get;set; }
    
    
    [Required]
    public byte Status { get; set; } = 0;    
    
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
    
    //Foriegn key
    public int UserId { get; set; }
    
    
    public User? UserHas { get;set; }
    public List<UserHaveDevice> UserDevices { get;set; } = [];
}