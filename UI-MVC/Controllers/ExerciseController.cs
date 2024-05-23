using Microsoft.AspNetCore.Mvc;
using ProjectFitness.BL;

namespace ProjectFitness.UI_MVC.Controllers;

public class ExerciseController : Controller
{
    private readonly IManager _manager;

    public ExerciseController(IManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var exercises = _manager.GetAllExercise();
        return View(exercises);
    }

    [HttpGet]
    public IActionResult Details(long id)
    {
        return View(_manager.GetExercise(id));
    }
}