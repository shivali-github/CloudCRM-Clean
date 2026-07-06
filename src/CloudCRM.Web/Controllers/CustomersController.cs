using CloudCRM.Application.Interfaces.Services;
using CloudCRM.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CloudCRM.Web.Controllers;
using CloudCRM.Web.Models.ViewModels;

public class CustomersController : Controller
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<IActionResult> Index()
    {
        var customers = await _customerService.GetAllCustomersAsync();

        return View(customers);
    }

// GET: Customers/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Customers/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CustomerViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var customer = new Customer
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            DateOfBirth = model.DateOfBirth,
            Address = model.Address,
            City = model.City,
            Country = model.Country
        };

        await _customerService.CreateCustomerAsync(customer);

        return RedirectToAction(nameof(Index));
}
}