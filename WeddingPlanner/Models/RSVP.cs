#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models;

public class RSVP

{
    [Key]
    //UPDATE ID
    public int RSVPId { get; set; }

    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    //Foriegn Key
    public int UserId { get;set; }
    public int WeddingId { get;set; }


    //NAVPROPS
    public User? RSVPingUser { get;set; }
    public Wedding? RSVPedWedding { get;set; }
}