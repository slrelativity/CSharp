// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace PortfolioWeb.Controllers;
public class PortfolioController : Controller   // Remember inheritance?    

// [Route("pizza")]
{
    [HttpGet] // We will go over this in more detail on the next page    
    [Route("")] // We will go over this in more detail on the next page //pizza/page
    public string Index()
    {
        return "This is my Index";
    }

    //http://localhost:5007/projects
    [HttpGet("projects")]
    public string Projects()
    {
        return "These are my projects";
    }
    //localhost:5007/params/565/bob ROUTE PARAMETERS
    [HttpGet("contact")]
    public string Contact()
    {
        return "This is my Contact";
    }
}