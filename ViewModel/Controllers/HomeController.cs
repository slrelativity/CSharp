using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Models;

namespace ViewModel.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }


    [HttpGet("numbers")]
    public ViewResult Numbers()
    {
        List<int> Numbers = [1, 2, 10, 21, 8, 7, 3];
        return View("numbers", Numbers);
    }


    [HttpGet("user")]
    public IActionResult AUser()
    {
        string name = "Neil Gaiman";
        return View("user", name);
    }


    [HttpGet("users")]
    public IActionResult Users()
    {
        List<string> Names = ["Neil Gaimain", "Terry Practchet", "Jane Austen", "Stephen King", "Mary Shelby"];
        return View("users", Names);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
