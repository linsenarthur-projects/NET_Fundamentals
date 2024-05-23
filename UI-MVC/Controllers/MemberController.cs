using Microsoft.AspNetCore.Mvc;
using ProjectFitness.BL;
using ProjectFitness.Domain;
using ProjectFitness.UI_MVC.Models;
using UI_MVC.Models;

namespace ProjectFitness.UI_MVC.Controllers;

public class MemberController : Controller
{
    private readonly IManager _manager;

    public MemberController(IManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var members = _manager.GetAllMembers();
        return View(members);
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        Member member = _manager.GetMember(id);
        return View(member);
    }
    
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(AddMemberViewModel memberVm)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        var createdMember = _manager.AddMember(
            memberVm.Name,
            memberVm.Birthdate,
            memberVm.BodyWeight
        );

        return RedirectToAction(nameof(Details), new { id = createdMember.Id });
    }
}