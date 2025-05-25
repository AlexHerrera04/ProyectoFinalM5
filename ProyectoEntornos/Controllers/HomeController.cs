using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProyectoEntornos.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProyectoEntornos.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        const string apiUrl = "https://api.open-meteo.com/v1/forecast?latitude=41.3851&longitude=2.1734&current_weather=true&timezone=Europe/Madrid";

        var client = new HttpClient();
        var response = client.GetAsync(apiUrl).Result;
        var content = response.Content.ReadAsStringAsync().Result;

        Console.WriteLine($"API Response: {content}"); 
        JObject jsonObject = JObject.Parse(content);
        JObject? weatherObject = jsonObject["current_weather"] as JObject;

        var model = weatherObject?.ToObject<CurrentWeather>() ?? new CurrentWeather();

        return View(model);
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
