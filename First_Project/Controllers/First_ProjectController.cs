// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace First_Project.Controllers;
public class HelloController : Controller   // Remember inheritance?    
{
    [HttpGet]
    [Route("")]
    //ViewResult
    public IActionResult  Index()
    {
        // will attempt to serve 
        // Views/Hello/Index.cshtml
        // or if that file isn't there:
        // Views/Shared/Index.cshtml
        ViewBag.Name = "Your name";
        return View("Index");
    }
    // [HttpGet]
    // [Route("info")]
    // public ViewResult Info()
    // {
    //     // Same logic for serving a view applies
    //     // if we provide the exact view name or page
    //     return View("Info");
    // }
    // // You may also serve the same view twice from additional actions
    // [HttpGet("elsewhere")]
    // public ViewResult Elsewhere()
    // {
    //     // This would be a case where we have to specify the file name
    //     return View("Index");
    // }
}

