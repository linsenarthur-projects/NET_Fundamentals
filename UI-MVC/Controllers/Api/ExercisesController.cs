using Microsoft.AspNetCore.Mvc;
using ProjectFitness.BL;
using ProjectFitness.UI_MVC.Models.Dto;

namespace ProjectFitness.UI_MVC.Controllers.Api;

[ApiController]
[Route("/api/[controller]")]
public class ExercisesController : ControllerBase
{
    private readonly IManager _manager;

    public ExercisesController(IManager manager)
    {
        _manager = manager;
    }
    
    [HttpGet("{exerciseId}/Members")]
    public ActionResult<IEnumerable<MemberDto>> GetMembersOfExercise(int exerciseId)
    {
        var members = _manager.GetMembersOfExercise(exerciseId);
    
        if (!members.Any())
        {
            return NoContent();
        }
    
        return Ok(members.Select(member => new MemberDto
        {
            Id = member.Id,
            Name = member.Name,
            BodyWeight = member.BodyWeight,
        }));
    }
    
    
}