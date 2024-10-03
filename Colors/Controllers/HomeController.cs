using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Colors.Models;

namespace Colors.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        
        HttpContext.Session.SetInt32("MyNum", 22);
        return View();
    }

    public IActionResult Privacy()
    {
        HttpContext.Session.SetString("UserName", "Bob");
        HttpContext.Session.SetInt32("MyNum", 12);
        // string? MyUsername = HttpContext.Session.GetString("UserName");
        int? MyNum = HttpContext.Session.GetInt32("MyNum");
        return View("Privacy", MyNum);
    }
    
    [HttpGet("clear")]
    public IActionResult ClearSession()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
    
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
