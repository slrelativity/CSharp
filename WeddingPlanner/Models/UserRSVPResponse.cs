#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models;

public class UserRSVPResponse

{
    [Key]
    //UPDATE ID
    public int UserRSVPResponseID { get; set; }

    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    //Foriegn Key
    public int UserId { get;set; }
    public int WeddingId { get;set; }


    //NAVPROPS
    public User? RSVPingUser { get;set; }
    public Wedding? RSVPedWedding { get;set; }
}