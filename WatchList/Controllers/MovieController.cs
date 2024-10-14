using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WatchList.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace WatchList.Controllers;
[SessionCheck]
public class MovieController : Controller
{
    private readonly ILogger<MovieController> _logger;

    private MyContext _context;
    public MovieController(ILogger<MovieController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }
    
    
    [HttpGet("movies")]
    public ViewResult AllMovies()
    {
        List<Movie> AllMovies = _context.Movies
                                                                    .Include(m => m.Rater)
                                                                    .OrderByDescending(m => m.CreatedAt).Take(50).ToList();
        return View(AllMovies);
    }


    [HttpGet("movies/new")]
    public ViewResult NewMovie()
    {
        return View();
    }


    [HttpPost("movies/create")]
    public IActionResult CreateProcess(Movie newMovie)
    {
        if (!ModelState.IsValid)
        {
            string message = string.Join(" | ", ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage));
            Console.WriteLine(message);
            return View("NewMovie");
        }
        newMovie.UserId = (int)HttpContext.Session.GetInt32("UserId");
        _context.Add(newMovie);
        _context.SaveChanges();
        return RedirectToAction("AllMovies");
    }


    [HttpGet("movies/{movieId:int}/edit")]
    public IActionResult Edit(int movieId)
    {
        Movie? SingleMovie = _context.Movies.FirstOrDefault(m => m.MovieId == movieId);
        if (SingleMovie == null)
        {
            return RedirectToAction("AllMovies");
        }
        return View(SingleMovie);
    }



    [HttpGet("movies/{movieId}")]
    public IActionResult ViewMovie(int movieId)
    {
        Movie? SingleMovie = _context.Movies
                                                        .FirstOrDefault(m => m.MovieId == movieId);
        if (SingleMovie == null)
        {
            return RedirectToAction("AllMovies");
        }
        return View(SingleMovie);
    }



    [HttpPost("movies/{movieId:int}/edit")]
    public IActionResult EditProcess(int movieId, Movie updatedMovie)
    {
        Movie? SingleMovie = _context.Movies.FirstOrDefault(m => m.MovieId == movieId);
        if (!ModelState.IsValid || SingleMovie == null)
        {
            if (SingleMovie == null)
                {ModelState.AddModelError("Description", "Movie is not found.");}
            return View("Edit", updatedMovie);
        }
        else
        {
            SingleMovie.Title = updatedMovie.Title;
            SingleMovie.Genre = updatedMovie.Genre;
            SingleMovie.ReleaseDate = updatedMovie.ReleaseDate;
            SingleMovie.Synopsis = updatedMovie.Synopsis;
            SingleMovie.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("ViewMovie", new { MovieId = movieId });
        }
    }



    [HttpPost("movies/{movieId}")]
    public IActionResult Delete(int movieId)
    {
        Movie? SingleMovie = _context.Movies.FirstOrDefault(m => m.MovieId == movieId);
        if (SingleMovie != null)
        {
            _context.Remove(SingleMovie);
            _context.SaveChanges();
        }
        return RedirectToAction("AllMovies");
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

public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Find the session, but remember it may be null so we need int?
        int? userId = context.HttpContext.Session.GetInt32("UserId");
        // Check to see if we got back null
        if (userId == null)
        {
            // Redirect to the Index page if there was nothing in session
            // "Home" here is referring to "HomeController", you can use any controller that is appropriate here
            context.Result = new RedirectToActionResult("Index", "User", null);
        }
    }
}


