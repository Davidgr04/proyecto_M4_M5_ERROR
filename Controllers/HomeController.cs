using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using proyecto_M4_M5.Models;
using Newtonsoft.Json;

namespace proyecto_M4_M5.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // public IActionResult Index()
    // {
    //     return View();
    // }

    public IActionResult Index()
{

    const string apiUrl = "https://apisimpsons.fly.dev/api/personajes";
    
    var client = new HttpClient();
    var response = client.GetAsync(apiUrl).Result;
    var content = response.Content.ReadAsStringAsync().Result;
    
    Simpson imagen_simpson = JsonConvert.DeserializeObject<Simpson>(content);
   

    return View(imagen_simpson);
}


    public IActionResult Privacy()
    {
        const string apiUrl = "https://rickandmortyapi.com/api/character";
    
        var client = new HttpClient();
        var response = client.GetAsync(apiUrl).Result;
        var content = response.Content.ReadAsStringAsync().Result;
    
        Ricky imagen_ricky = JsonConvert.DeserializeObject<Ricky>(content);

        return View(imagen_ricky);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
