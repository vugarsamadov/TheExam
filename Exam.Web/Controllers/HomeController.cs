using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Exam.Web.Models;
using Exam.Business.Services.Abstract;
using Exam.Web.Models.Home;

namespace Exam.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public IChefService _chefService { get; }

    public HomeController(ILogger<HomeController> logger,IChefService chefService)
    {
        _logger = logger;
        _chefService = chefService;
    }

    public async Task<IActionResult> Index()
    {
        var models = await _chefService.GetTalantedChefs();
        var vm = new IndexVM();
        vm.TalantedChefs = models;
        return View(vm);
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
