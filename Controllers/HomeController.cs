using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TrendsNews.Models;
using TrendsNews.Services;

namespace TrendsNews.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public ViewResult Form()
    {
        return View();
    }

    [Route("/news", Name="news")]
    [HttpGet]
    public ViewResult News()
    {
        NewService newService = new NewService();
        var noticiasService = newService.GetNews();
        return View(noticiasService);
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
