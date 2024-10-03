// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace Directions.Controllers;
public class DirectionsController : Controller   // Remember inheritance?    
{
    [HttpGet]
    [Route("")]
    public ViewResult Index()
    {
        // will attempt to serve 
        // Views/Hello/Index.cshtml
        // or if that file isn't there:
        // Views/Shared/Index.cshtml
        return View();
    }
}