using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Form.Models;

namespace Form.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    
    private static List<User> FakeUserDb = [];

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


    [HttpPost("process")]
    public IActionResult Process(User newUser)
    {
        if (!ModelState.IsValid)
        {
            string message = string.Join(" | ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
            Console.WriteLine(message);
        }
        if (!ModelState.IsValid)
        {
            return View("Index");
        }
            FakeUserDb.Add(newUser);
            return RedirectToAction("Success");   
    }

    [HttpGet("success")]
        public ViewResult Success()
    {
        return View(FakeUserDb);
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
