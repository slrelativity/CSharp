using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;
using CouponClipper.Models;

namespace CouponClipper.Controllers;
[SessionCheck]
public class CouponController : Controller
{
    private readonly ILogger<CouponController> _logger;
    
    private MyContext _context;
    public CouponController(ILogger<CouponController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }
    
    
    [HttpGet("coupons")]
    public ViewResult AllCoupons()
    {
        List<Coupon> Coupons = _context.Coupons
                                                                    .Include(uc => uc.UserClippings)
                                                                    .Include(c => c.Clipper)
                                                                    .OrderByDescending(c => c.CreatedAt).Take(3).ToList();
        return View(Coupons);
    }


    [HttpGet("account")]
    public IActionResult ViewCoupon()
    {
        int UserId = (int)HttpContext.Session.GetInt32("UserId");
        User LoggedUser = _context.Users 
                                        .Include(u => u.CouponClippings)
                                        .Include(u => u.ClippedCoupon) 
                                        .ThenInclude(c => c.UserClippings)  
                                        .FirstOrDefault(u => u.UserId == UserId);  
        return View(LoggedUser);
    }
    
    
    [HttpGet("coupons/new")]
    public ViewResult NewCoupon()
    {
        return View("NewCoupon");
    }
    
    
    [HttpPost("coupons/new")]
    public IActionResult CreateCoupon(Coupon newCoupon)
    {
        if (!ModelState.IsValid)
        {
            string message = string.Join(" | ", ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage));
            Console.WriteLine(message);
            return View("NewCoupon", newCoupon);
        }
        newCoupon.UserId = (int)HttpContext.Session.GetInt32("UserId");
        _context.Add(newCoupon);
        _context.SaveChanges();
        return RedirectToAction("AllCoupons");
    }


    [HttpPost("posts/{couponId}/toggle_coupon")]
    public IActionResult ToggleCoupon(int couponId)
    {
        int UserId = (int)HttpContext.Session.GetInt32("UserId");
        UserCouponClipping? existingCoupon = _context.UserCouponClippings.FirstOrDefault(upl => upl.UserId == UserId && upl.CouponId == couponId);
        if (existingCoupon == null)
        {
            UserCouponClipping newCoupon = new() { UserId = UserId, CouponId = couponId };
            _context.Add(newCoupon);
        }
        else
        {
            _context.Remove(existingCoupon);
        }
        _context.SaveChanges();
        return RedirectToAction("AllCoupons", new { couponId });
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

