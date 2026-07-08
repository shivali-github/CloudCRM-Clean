using CloudCRM.Application.Interfaces.Services;
using CloudCRM.Core.Entities;
using CloudCRM.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CloudCRM.Web.Controllers;

public class MembershipTypesController : Controller
{
    private readonly IMembershipTypeService _membershipTypeService;

    public MembershipTypesController(IMembershipTypeService membershipTypeService)
    {
        _membershipTypeService = membershipTypeService;
    }

    public async Task<IActionResult> Index()
    {
        var membershipTypes = await _membershipTypeService.GetAllMembershipTypesAsync();
        return View(membershipTypes);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(MembershipTypeViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var membershipType = new MembershipType
        {
            Name = model.Name,
            DurationInMonths = model.DurationInMonths,
            Price = model.Price,
            Description = model.Description
        };

        await _membershipTypeService.AddMembershipTypeAsync(membershipType);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var membershipType = await _membershipTypeService.GetMembershipTypeByIdAsync(id);

        if (membershipType == null)
            return NotFound();

        var model = new MembershipTypeViewModel
        {
            Id = membershipType.Id,
            Name = membershipType.Name,
            DurationInMonths = membershipType.DurationInMonths,
            Price = membershipType.Price,
            Description = membershipType.Description
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(MembershipTypeViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var membershipType = new MembershipType
        {
            Id = model.Id,
            Name = model.Name,
            DurationInMonths = model.DurationInMonths,
            Price = model.Price,
            Description = model.Description
        };

        await _membershipTypeService.UpdateMembershipTypeAsync(membershipType);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var membershipType = await _membershipTypeService.GetMembershipTypeByIdAsync(id);

        if (membershipType == null)
            return NotFound();

        var model = new MembershipTypeViewModel
        {
            Id = membershipType.Id,
            Name = membershipType.Name,
            DurationInMonths = membershipType.DurationInMonths,
            Price = membershipType.Price,
            Description = membershipType.Description
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(MembershipTypeViewModel model)
    {
        await _membershipTypeService.DeleteMembershipTypeAsync(model.Id);

        return RedirectToAction(nameof(Index));
    }
}