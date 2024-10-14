using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;
using ArtStagram.Models;

namespace ArtStagram.Controllers;
[SessionCheck]
public class PostController : Controller
{
    private readonly ILogger<PostController> _logger;

    private MyContext _context;
    public PostController(ILogger<PostController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

//GET HOME ROUTE
    [HttpGet("posts")]
    public ViewResult AllPosts()
    {
        List<Post> Posts = _context.Posts
                                                                    .Include(p => p.UserLikes)
                                                                    .Include(p => p.Poster)
                                                                    .OrderByDescending(p => p.CreatedAt).Take(3).ToList();
        return View(Posts);
    }

    //GET ONE VIEW ROUTE
    [HttpGet("posts/{postId}")]
    public IActionResult ViewPost(int postId)
    {
        Post? SinglePost = _context.Posts
                                                            .Include(p => p.UserLikes)
                                                            .ThenInclude(lu => lu.LikingUser)
                                                            .Include(p => p.Poster)
                                                            .FirstOrDefault(p => p.PostId == postId);
        if (SinglePost == null)
        {
            return RedirectToAction("AllPosts");
        }
        return View(SinglePost);
    }


    //GET ONE POST VIEW ROUTE
    [HttpGet("posts/new")]
    public ViewResult NewPost()
    {
        return View("NewPost");
    }


    //POST CREATE A POST ACTION
    [HttpPost("posts/new")]
    public IActionResult CreatePost(Post newPost)
    {
        if (!ModelState.IsValid)
        {
            string message = string.Join(" | ", ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage));
            Console.WriteLine(message);
            return View("NewPost", newPost);
        }
        newPost.UserId = (int)HttpContext.Session.GetInt32("UserId");
        _context.Add(newPost);
        _context.SaveChanges();
        return RedirectToAction("AllPosts");
    }


    //GET EDIT VIEW ROUTE
    [HttpGet("posts/edit/{postId}")]
    public IActionResult Edit(int postId)
    {
        int UserId = (int)HttpContext.Session.GetInt32("UserId");
        Post? SinglePost = _context.Posts.FirstOrDefault(p => p.PostId == postId);
        if (SinglePost == null)
        {
            return RedirectToAction("ViewPost", new { postId});
        }
        return View(SinglePost);
    }

    //POST EDIT A POST ACTION
    [HttpPost("posts/edit/{postId}")]
    public IActionResult UpdatePost(int postId, Post updatedPost)
    {
        int UserId = (int)HttpContext.Session.GetInt32("UserId");
        Post? SinglePost = _context.Posts.FirstOrDefault(p => p.PostId == postId);
        if (!ModelState.IsValid || SinglePost == null)
        {
            if (SinglePost == null)
            { ModelState.AddModelError("Description", "Post is not found."); }
            return RedirectToAction("Edit", updatedPost);
        }
        else
        {
            SinglePost.ImgURL = updatedPost.ImgURL;
            SinglePost.Title = updatedPost.Title;
            SinglePost.Medium = updatedPost.Medium;
            SinglePost.ForSale = updatedPost.ForSale;
            SinglePost.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("ViewPost", new { postId });
        }
    }


    //POST TOGGLELIKE ACTION
    [HttpPost("posts/{postId}/toggle_like")]
    public IActionResult ToggleLike(int postId)
    {
        int UserId = (int)HttpContext.Session.GetInt32("UserId");
        UserPostLike? existingLike = _context.UserPostLikes.FirstOrDefault(upl => upl.UserId == UserId && upl.PostId == postId);
        if (existingLike == null)
        {
            UserPostLike newLike = new() { UserId = UserId, PostId = postId };
            _context.Add(newLike);
        }
        else
        {
            _context.Remove(existingLike);
        }
        _context.SaveChanges();
        return RedirectToAction("AllPosts", new { postId });
    }


    //POST DELETE ACTION
    [HttpPost("posts/{postId}")]
    public IActionResult Delete(int postId)
    {
        Post? SinglePost = _context.Posts.FirstOrDefault(p => p.PostId == postId);
        if (SinglePost != null)
        {
            _context.Remove(SinglePost);
            _context.SaveChanges();
        }
        return RedirectToAction("AllPosts");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


//SESSION CHECK
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
