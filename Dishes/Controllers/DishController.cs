using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Dishes.Models;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Dishes.Controllers;

public class DishController : Controller
{
    private readonly ILogger<DishController> _logger;

    private MyContext _context;
    public DishController(ILogger<DishController> logger, MyContext context)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet("")]
    public ViewResult Index()
    {
        List<Dish> Dishes = _context.Dishes.OrderByDescending(d => d.CreatedAt).Take(50).ToList();
        return View(Dishes);
    }

    [HttpGet("dishes/new")]
    public ViewResult NewDish()
    {
        return View();
    }

    [HttpPost("dishes/new")]
    public IActionResult CreateDish(Dish newDish)
    {
        if (!ModelState.IsValid)
        {
            string message = string.Join(" | ", ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage));
            Console.WriteLine(message);
            return View("NewDish");
        }
        _context.Add(newDish);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }


    [HttpGet("dishes/{dishId}")]
    public IActionResult ViewDish(int dishId)
    {
        Dish? SingleDish = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
        if (SingleDish == null)
        {
            return RedirectToAction("Index");
        }
        return View(SingleDish);
    }


    [HttpGet("dishes/{dishId}/edit")]
    public IActionResult EditDish(int dishId)
    {
        Dish? SingleDish = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
        if (SingleDish == null)
        {
            return RedirectToAction("Index");
        }
        return View(SingleDish);
    }


    [HttpPost("dishes/{dishId}/update")]
    public IActionResult EditProcess(int dishId, Dish updatedDish)
    {
        Dish? SingleDish = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
        if (!ModelState.IsValid || SingleDish == null)
        {
            if (SingleDish == null)
                {ModelState.AddModelError("Description", "Dish is not found.");}
            return View("EditDish", updatedDish);
        }
        else
        {
            SingleDish.Name = updatedDish.Name;
            SingleDish.Chef = updatedDish.Chef;
            SingleDish.Tastiness = updatedDish.Tastiness;
            SingleDish.Calories = updatedDish.Calories;
            SingleDish.Description = updatedDish.Description;
            SingleDish.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("ViewDish", new { dishId = dishId });
        }
    }


    [HttpPost("dishes/{dishId}/destroy")]
    public IActionResult DestroyDish(int dishId)
    {
        Dish? SingleDish = _context.Dishes.SingleOrDefault(d => d.DishId == dishId);
        if (SingleDish != null)
        {
            _context.Remove(SingleDish);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
