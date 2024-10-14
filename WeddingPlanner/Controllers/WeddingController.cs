using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace WeddingPlanner.Controllers;
[SessionCheck]
public class WeddingController : Controller
{
    private readonly ILogger<WeddingController> _logger;
    private MyContext _context;
    public WeddingController(ILogger<WeddingController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }
    
    [HttpGet("weddings")]
    public ViewResult AllWeddings()
    {
        List<Wedding> AllWeddings = _context.Weddings
                                                        .Include(w => w.UserResponses)
                                                        .OrderByDescending(w => w.CreatedAt).ToList();
        return View(AllWeddings);
    }


    [HttpGet("weddings/{weddingId}")]
    public IActionResult ViewWedding(int weddingId)
    {
        Wedding? SingleWedding = _context.Weddings
                                                        .Include(w => w.UserResponses )
                                                        .ThenInclude(u => u.RSVPingUser)
                                                        .FirstOrDefault(w => w.WeddingId == weddingId);
        if (SingleWedding == null)
        {
            return RedirectToAction("AllWeddings");
        }
        return View(SingleWedding);
    }

    [HttpGet("weddings/new")]
    public ViewResult AddWedding()
    {
        return View("NewWedding");
    }


    [HttpPost("weddings/create")]
    public IActionResult CreateWedding(Wedding newWedding)
    {
        if (!ModelState.IsValid)
        {
            string message = string.Join(" | ", ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage));
            Console.WriteLine(message);
            return View("NewWedding");
        }
        newWedding.UserId = (int)HttpContext.Session.GetInt32("UserId");
        _context.Add(newWedding);
        _context.SaveChanges();
        return RedirectToAction("AllWeddings");
    }


    [HttpPost("weddings/{weddingId}")]
    public IActionResult DeleteRSVP(int weddingId)
    {
        Wedding? SingleWedding = _context.Weddings.FirstOrDefault(w => w.WeddingId == weddingId);
        if (SingleWedding !=null)
        {
            _context.Remove(SingleWedding);
            _context.SaveChanges();
        }
        return RedirectToAction("AllWeddings");
    }


    [HttpPost("weddings/{weddingId}/toggle_rsvp")]
    public IActionResult ToggleRSVP(int weddingId)
    {
        int UserId = (int) HttpContext.Session.GetInt32("UserId");
        UserRSVPResponse? userRSVPResponse  = _context.UserRSVPResponses.FirstOrDefault(uru => uru.UserId == UserId && uru.WeddingId == weddingId);
        if (userRSVPResponse == null)
        {
            UserRSVPResponse newRSVP = new(){ UserId=UserId, WeddingId=weddingId};
            _context.Add(newRSVP);
        }
        else
        {
            _context.Remove(userRSVPResponse);
        }
        _context.SaveChanges();
        return RedirectToAction("AllWeddings");
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

    public class SessionCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Find the session, but remember it may be null so we need int?
            int? userId = context.HttpContext.Session.GetInt32("UserId");
            // Check to see if we got back null
            if (userId == null)
            {
                // Redirect to the Index page if there was nothing in session
                // "Home" here is referring to "HomeController", you can use any controller that is appropriate here
                context.Result = new RedirectToActionResult("Index", "User", null);
            }
        }
    }