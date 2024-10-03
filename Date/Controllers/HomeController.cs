using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Date.Models;

namespace Date.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("")]
    public ViewResult Index()
    {
        return View();
    }


    [HttpPost("results")]
    public IActionResult Process(DateForm newFutureDate)
    {
        if (!ModelState.IsValid)
        {
            string message = string.Join(" | ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
            Console.WriteLine(message);
            return View("Index");
        }
        else
            return View("Results", newFutureDate);
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
