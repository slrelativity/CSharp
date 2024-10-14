using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;
using Sentry.Models;

namespace Sentry.Controllers;

public class SentryController : Controller
{
    private readonly ILogger<SentryController> _logger;

    private MyContext _context;
    public SentryController(ILogger<SentryController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

//ADD logout on USER CONTROLLER
//ADD SESSION CHECK to MANY CONTOLLER
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}