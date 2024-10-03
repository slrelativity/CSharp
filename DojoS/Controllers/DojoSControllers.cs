using Microsoft.AspNetCore.Mvc;
//DojoS.csproj
namespace DojoS.Controllers;
//DojoS      from controller file
public class DojoSController : Controller


{
    [HttpGet]
    [Route("")]
    public ViewResult Index()
    {
        return View();
    }

    [HttpPost("results")]
    public IActionResult Process(string Name, string Location, string Language, string Comment)
    {
        ViewBag.Name = Name;
        ViewBag.Location = Location;
        ViewBag.Language = Language;
        ViewBag.Comment = Comment;
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Location: {Location}");
        Console.WriteLine($"Language: {Language}");
        Console.WriteLine($"Comment: {Comment}");
        return View("Results");
    }
}
