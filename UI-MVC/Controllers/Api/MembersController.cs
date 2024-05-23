using Microsoft.AspNetCore.Mvc;
using ProjectFitness.BL;
using ProjectFitness.Domain;
using ProjectFitness.UI_MVC.Models.Dto;

namespace ProjectFitness.UI_MVC.Controllers.Api;

[ApiController]
[Route("/Api/[controller]")]
public class MembersController : ControllerBase
{
    private readonly IManager _manager;

    public MembersController(IManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public ActionResult<IEnumerable<MemberDto>> GetAllMembers()
    {
        var members = _manager.GetAllMembers();
        
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