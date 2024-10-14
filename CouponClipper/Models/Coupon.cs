#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace CouponClipper.Models;

public class Coupon

{
    [Key]
    //UPDATE ID
    public int CouponId { get; set; }
    
    
    [Required]
    public string CouponCode { get; set; }    
    
    
    [Required]
    public string Website { get; set; }
    
    
    [Required]
    [MinLength(10, ErrorMessage = "A description is required!")]
    public string Description { get; set; }
    
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
    
    //Foriegn key
    public int UserId { get; set; }
    
    
    //NAVPROPS
    public User? Clipper { get; set; }
    public List<UserCouponClipping> UserClippings { get; set; } = [];
}