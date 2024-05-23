using Microsoft.AspNetCore.Mvc;
using ProjectFitness.BL;
using ProjectFitness.Domain;
using ProjectFitness.UI_MVC.Models.Dto;

namespace ProjectFitness.UI_MVC.Controllers.Api;

[Route("/api/[controller]")]
public class FitnessesController : ControllerBase
{
    private readonly IManager _manager;

    public FitnessesController(IManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public ActionResult<IEnumerable<FitnessDto>> AllFitnesses()
    {
        var allFitnesses = _manager.GetAllFitnesses();
        if (!allFitnesses.Any())
        {
            return NoContent();
        }

        return Ok(allFitnesses.Select(fitness => new FitnessDto
        {
            Id = fitness.Id,
            Name = fitness.Name,
            Address = fitness.Address,
            Surface = fitness.Surface
        }));

    }
    
    [HttpPost]
    public IActionResult Add(AddFitnessDto fitness)
    {
        _manager.addFitness(fitness.Name, fitness.Address, fitness.Surface);
    
        return CreatedAtAction("Index", new { controller = "Fitness"}, fitness);
    }
}