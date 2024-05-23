using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjectFitness.BL;
using ProjectFitness.UI_MVC.Models;
using ProjectFitness.UI_MVC.Models.Dto;

namespace ProjectFitness.UI_MVC.Controllers.Api;

[ApiController]
[Route("/api/[controller]")]
public class MemberExercisesController : ControllerBase
{
    private readonly IManager _manager;

    public MemberExercisesController(IManager manager)
    {
        _manager = manager;
    }

    [HttpPost]
    public IActionResult Add(AddMemberExercisesDto memberExercise)
    {
        var member = _manager.GetMember(memberExercise.MemberId);
        var exercise = _manager.GetExercise(memberExercise.ExerciseId);
        
        _manager.AddMemberExercise(exercise, member, memberExercise.Reps, memberExercise.Sets);
    
        return CreatedAtAction("Details", new { controller = "Exercise", id = memberExercise.Id }, memberExercise);
    }
}