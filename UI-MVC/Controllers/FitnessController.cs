using Microsoft.AspNetCore.Mvc;
using UI_MVC.Models;

namespace ProjectFitness.UI_MVC.Controllers;

public class FitnessController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}