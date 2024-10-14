#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ArtStagram.Models;

public class Post

{
    [Key]
    //UPDATE ID
    public int PostId { get; set; }

    [Required]
    [DisplayName("Image URL")]
    public string? ImgURL { get; set; }
    
    
    [Required]
    [MinLength(2)]
    [MaxLength(60)]
    public string Title { get; set; }
    
    
    [Required]
    [MinLength(2)]
    public string Medium { get; set; }
    
    
    [Required]
    public bool ForSale { get;set; }
    
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
    
    //Foriegn Key
    public int UserId { get;set; }
    
    
    //NAVPROPS
    public User? Poster { get;set; }
    public List<UserPostLike> UserLikes { get;set; } = [];
}