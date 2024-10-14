#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace WatchList.Models;

public class UserMovieRating

{
    [Key]
    public int UserMovieRatingId { get; set; }
    
    public int Rating { get;set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
    
    //FORIEGN KEY
    public int UserId { get;set; }
    public int MovieId { get;set; }
    
    
    //NAVPROPS
    public User? RatingUser { get;set; }
    public Movie? RatedMovie { get;set; }
}