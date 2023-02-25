using Business;
using Microsoft.AspNetCore.Mvc;
using MVC_Patterns.Models;
using System.Diagnostics;

namespace MVC_Patterns.Controllers;
public class PagesController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IConfiguration _configuration;

    public PagesController(ILogger<HomeController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public IActionResult Index()
    {
        ViewBag.Pages = new Page(_configuration).GetPagesList();
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
