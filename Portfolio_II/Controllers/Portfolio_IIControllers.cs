using Microsoft.AspNetCore.Mvc;

namespace Portfolio_II.Controllers;
public class Portfolio_II : Controller  


{
    [HttpGet] 
    [Route("")] 
    public ViewResult Index()
    {
        return View ();
    }

    [HttpGet("projects")]
    public ViewResult Projects()
    {
        return View();
    }

    [HttpGet("contact")]
    public ViewResult Contact()
    {
        return View();
    }
}