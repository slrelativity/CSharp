#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ArtStagram.Models;

public class UserPostLike

{
    [Key]
    //UPDATE ID
    public int UserPostLikeId { get; set; }
    
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
    
    //Foriegn Key
    public int UserId { get; set; }
    public int PostId { get; set; }
    
    
    //NAVPROPS
    public User? LikingUser { get;set; }
    public Post? LikedPost { get;set; }
}