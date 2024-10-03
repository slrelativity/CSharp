using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FirstConnection.Models;

namespace FirstConnection.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private MyContext _context;
    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }



    [HttpGet("")]
    public IActionResult Index()
    {
        List<Monster> AllMonsters = _context.Monsters.ToList();
        return View("monsters");
    }

    public IActionResult Privacy()
    {
        return View("Index");
    }

    // Inside HomeController
    [HttpPost("monsters/create")]
    public IActionResult CreateMonster(Monster newMon)
    {
        if (ModelState.IsValid)
        {
            string message = string.Join(" | ", ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage));
            Console.WriteLine(message);
            // We can take the Monster object created from a form submission
            // and pass the object through the .Add() method  
            // Remember that _context is our database  
            _context.Add(newMon);
            // OR _context.Monsters.Add(newMon); if we want to specify the table
            // EF Core will be able to figure out which table you meant based on the model  
            // VERY IMPORTANT: save your changes at the end! 
            _context.SaveChanges();
            return RedirectToAction("monsters", newMon);
        }
        else
        {
            // Handle unsuccessful validations
            return View("Index");
        }
    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
