using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private MyContext _context;
    public UserController(ILogger<UserController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        List<Chef> AllChefs = new();
        AllChefs = _context.Chefs.Include(chef => chef.tasytyDishes).ToList();
        return View("Index", AllChefs);
    }



    [HttpGet("dishes")]
    public ViewResult Dishes()
    {
        List<Dish> allDishes = _context.Dishes.Include(chef => chef.Creator).ToList();
        return View(allDishes);
    }


    [HttpGet("dishes/new")]
    public ViewResult AddDish()
    {
        List<Chef> allChefs = _context.Chefs.ToList();
        ViewBag.ChefOptions = allChefs;
        return View("AddDish");
    }
    
    [HttpPost("dishes/new")]
    public IActionResult CreateDish(Dish newDish)
    {
        if (!ModelState.IsValid)
                {
                    return AddDish();
                }
                _context.Add(newDish);
                _context.SaveChanges();
                return RedirectToAction("Index");
                }     
    

    [HttpGet("chefs/new")]
    public ViewResult AddChef()
    {
        return View();
    }
    
    
    [HttpPost("chefs/new")]
    public IActionResult CreateChef(Chef newChef)
    {
        if(!ModelState.IsValid)
        {
            return View("AddChef");
        }
        _context.Add(newChef);
        _context.SaveChanges();
        return RedirectToAction("index");
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