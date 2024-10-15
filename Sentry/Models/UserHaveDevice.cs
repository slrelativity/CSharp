#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Sentry.Models;

public class UserHaveDevice

{
    [Key]
    //UPDATE ID
    public int UserHaveDeviceId { get; set; }  
    
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
    
    //FORIEGN KEY
    public int UserId { get;set; }
    public int DeviceId { get;set; }
    
    
    //NAVPROPS
    public User? DeviceUser { get;set; }
    public Device? HadDevice { get;set; }
}