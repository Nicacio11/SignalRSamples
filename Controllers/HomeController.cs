using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRSample.Hubs;
using SignalRSample.Models;

namespace SignalRSample.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHubContext<DeathlyHallowHub> _deathlyHallowHub;

    public HomeController(ILogger<HomeController> logger, IHubContext<DeathlyHallowHub> deathlyHallowHub)
    {
        _logger = logger;
        _deathlyHallowHub = deathlyHallowHub;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> DeathlyHallows(string type){
        if(SD.DealthyHallowRace.ContainsKey(type)){
            SD.DealthyHallowRace[type]++;
        }
        await _deathlyHallowHub.Clients.All.SendAsync("updateDealthlyHallowCount", 
            SD.DealthyHallowRace[SD.Cloak],
            SD.DealthyHallowRace[SD.Stone],
            SD.DealthyHallowRace[SD.Wand]
        );
        return Accepted();
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
