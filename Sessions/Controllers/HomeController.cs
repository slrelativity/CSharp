using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Sessions.Models;


namespace Sessions.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // Home page
    [HttpGet]
    [Route("")]
    public ViewResult Index()
    {
        return View();
    }


    // Post method used set name and current count
    [HttpPost("process")]
    public IActionResult Process(User newUser)
    {
        HttpContext.Session.SetInt32("Count", 22);
        if (!ModelState.IsValid)
        {
            return View("Index");
        }
        HttpContext.Session.SetString("Name", newUser.Name);
        HttpContext.Session.SetInt32("Count", 22);
        return RedirectToAction("Dashboard");
    }


    // Post method getting the current value and adding +1 to the current value to display
    [HttpPost("add")]
    public IActionResult Add()
    {
        int? Count = HttpContext.Session.GetInt32("Count"); Count ++;
        HttpContext.Session.SetInt32("Count", Count.Value);
        return RedirectToAction("Dashboard");
    }


    // Post method getting the current value and subtracting -1 from the current value to display
    [HttpPost("subtract")]
    public IActionResult Subtract()
    {
        int? Count = HttpContext.Session.GetInt32("Count"); Count --;
        HttpContext.Session.SetInt32("Count", Count.Value);
        return RedirectToAction("Dashboard");
    }


    // Post method getting the current value and multiplying the current value by 2 to display
    [HttpPost("multiply")]
    public IActionResult Multiply()
    {
        int? Count = HttpContext.Session.GetInt32("Count"); Count +=Count;
        HttpContext.Session.SetInt32("Count", Count.Value);
        return RedirectToAction("Dashboard");
    }


    // Post method getting the current value and combining a randomly generated number and current value to display
    [HttpPost("random")]
    public IActionResult Random()
    {
        Random random = new Random();
        int? Count = HttpContext.Session.GetInt32("Count"); Count += random.Next (1,1776);
        HttpContext.Session.SetInt32("Count", Count.Value);
        return RedirectToAction("Dashboard");

    }


    [HttpGet("dashboard")]
    public ViewResult Dashboard()
    {
        String? Name = HttpContext.Session.GetString("Name");
        if (Name == null)
        {
            return View("Index");
        }
        int? currentCount = HttpContext.Session.GetInt32("Count") ?? 22;
        ViewBag.Count = currentCount;
        return View();
    }


    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
