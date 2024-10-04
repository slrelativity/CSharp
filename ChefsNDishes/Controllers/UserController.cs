using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
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
        List<Chef> AllChefs = _context.Chefs.Include(c => c.CreatedDishes).ToList();
        return View(AllChefs);
    }



    [HttpGet("dishes")]
    public ViewResult Dishes()
    {
        List<Dish> AllDishes = _context.Dishes.Include(c => c.Creator).ToList();
        return View(AllDishes);
    }


    [HttpGet("dishes/new")]
    public ViewResult AddDish()
    {
        List<Chef> AllChefs = _context.Chefs.ToList();
        ViewBag.ChefOptions = AllChefs;
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