using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sentry.Models;
using Microsoft.EntityFrameworkCore;

namespace Sentry.Controllers;
[SessionCheck]
public class DeviceController : Controller
{
    private readonly ILogger<DeviceController> _logger;

    private MyContext _context;
    public DeviceController(ILogger<DeviceController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }


    [HttpGet("dashboard")]
    public ViewResult AllDevices()
    {
        List<Device> Devices = _context.Devices
                                                        .Include(ud => ud.UserDevices)
                                                        .ThenInclude(usd =>usd.DeviceUser)
                                                    
                                                        .OrderByDescending(c => c.CreatedAt).ToList();
        return View(Devices);
    }


    [HttpGet("devices/new")]
    public ViewResult NewDevice()
    {
        return View("NewDevice");
    }


    [HttpPost("devices/new")]
    public IActionResult CreateDevice(Device newDevice)
    {
        if (!ModelState.IsValid)
        {
            string message = string.Join(" | ", ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage));
            Console.WriteLine(message);
            return View("NewDevice", newDevice);
        }
        newDevice.UserId = (int)HttpContext.Session.GetInt32("UserId");
        _context.Add(newDevice);
        _context.SaveChanges();
        return RedirectToAction("AllDevices");
    }


    [HttpGet("devices/{deviceId}")]
    public IActionResult ViewDevice(int deviceId)
    {
        Device? SingleDevice = _context.Devices
                                                            .Include(d => d.UserDevices)
                                                            .ThenInclude(du => du.DeviceUser)
                                                            .Include(d => d.UserHas)
                                                            .FirstOrDefault(d => d.DeviceId == deviceId);
        if (SingleDevice == null)
        {
            return RedirectToAction("AllDevices");
        }
        return View(SingleDevice);
    }


    [HttpGet("devices/edit/{deviceId}")]
    public IActionResult Edit(int deviceId)
    {
        int? UserId = (int)HttpContext.Session.GetInt32("UserId");
        Device? SingleDevice = _context.Devices.FirstOrDefault(d => d.DeviceId == deviceId);
        if (SingleDevice == null)
        {
            return RedirectToAction("ViewDevice", new { deviceId });
        }
        return View(SingleDevice);
    }


    [HttpPost("devices/edit/{deviceId}")]
    public IActionResult UpdateDevice(int deviceId, Device updatedDevice)
    {
        int? UserId = (int)HttpContext.Session.GetInt32("UserId");
        Device? SingleDevice = _context.Devices.FirstOrDefault(d => d.DeviceId == deviceId);
        if (!ModelState.IsValid || SingleDevice == null)
        {
            if (SingleDevice == null)
            { ModelState.AddModelError("Description", "Device is not found."); }
            return RedirectToAction("Edit", updatedDevice);
        }
        else
        {
            SingleDevice.SerialNumber = updatedDevice.SerialNumber;
            SingleDevice.HostName = updatedDevice.HostName;
            SingleDevice.Badge = updatedDevice.Badge;
            SingleDevice.EmployeeName = updatedDevice.EmployeeName;
            SingleDevice.Status = updatedDevice.Status;
            SingleDevice.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("ViewDevice", new { deviceId });
        }
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

