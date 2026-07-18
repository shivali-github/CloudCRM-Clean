using CloudCRM.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using CloudCRM.Web.Models.ViewModels;

namespace CloudCRM.Web.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;
using CloudCRM.Core.Entities;

public class MembershipsController : Controller
{
    private readonly IMembershipService _membershipService;
    private readonly ICustomerService _customerService;
    private readonly IMembershipTypeService _membershipTypeService;

    public MembershipsController(
        IMembershipService membershipService,
        ICustomerService customerService,
        IMembershipTypeService membershipTypeService)
    {
        _membershipService = membershipService;
        _customerService = customerService;
        _membershipTypeService = membershipTypeService;
    }

     public async Task<IActionResult> Index()
    {
        var memberships = await _membershipService.GetAllMembershipsAsync();
        return View(memberships);
    }

    public async Task<IActionResult> Create()
    {
        var model = new MembershipViewModel();

        var customers = await _customerService.GetAllCustomersAsync();

        model.Customers = customers.Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = $"{c.FirstName} {c.LastName}"
        }).ToList();

        var membershipTypes = await _membershipTypeService.GetAllMembershipTypesAsync();

        model.MembershipTypes = membershipTypes.Select(m => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
        {
            Value = m.Id.ToString(),
            Text = m.Name
        }).ToList();

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(MembershipViewModel model)
    {
        if (!ModelState.IsValid)
        {
            await LoadDropdowns(model);
            return View(model);
        }

        var membershipType = await _membershipTypeService
            .GetMembershipTypeByIdAsync(model.MembershipTypeId);

        if (membershipType == null)
        {
            ModelState.AddModelError("", "Invalid Membership Type.");
            await LoadDropdowns(model);
            return View(model);
        }

        var membership = new Membership
        {
            CustomerId = model.CustomerId,
            MembershipTypeId = model.MembershipTypeId,
            StartDate = model.StartDate,
            EndDate = model.StartDate.AddMonths(membershipType.DurationInMonths),
            Price = membershipType.Price,
            IsActive = true
        };

        await _membershipService.AddMembershipAsync(membership);

        return RedirectToAction(nameof(Index));
    }

    private async Task LoadDropdowns(MembershipViewModel model)
    {
        var customers = await _customerService.GetAllCustomersAsync();

        model.Customers = customers.Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = $"{c.FirstName} {c.LastName}"
        }).ToList();

        var membershipTypes =
            await _membershipTypeService.GetAllMembershipTypesAsync();

        model.MembershipTypes = membershipTypes.Select(m => new SelectListItem
        {
            Value = m.Id.ToString(),
            Text = m.Name
        }).ToList();
    }
}