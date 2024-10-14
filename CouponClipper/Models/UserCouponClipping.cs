#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace CouponClipper.Models;

public class UserCouponClipping

{
    [Key]
    //UPDATE ID
    public int UserCouponClippingId { get; set; }
    
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
    
    //Foriegn Key
    public int UserId { get; set; }
    public int CouponId { get; set; }
    
    
    //NAVPROPS
    public User? ClippingUser { get; set; }
    public Coupon? ClippedCoupon { get; set; }
}