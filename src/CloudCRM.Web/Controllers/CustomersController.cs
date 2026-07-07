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

    public async Task<IActionResult> Edit(int id)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id);

        if (customer == null)
        {
            return NotFound();
        }

        var model = new CustomerViewModel
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            PhoneNumber = customer.PhoneNumber,
            DateOfBirth = customer.DateOfBirth,
            Address = customer.Address,
            City = customer.City,
            Country = customer.Country
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(CustomerViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var customer = await _customerService.GetCustomerByIdAsync(model.Id);

        if (customer == null)
        {
            return NotFound();
        }

        customer.FirstName = model.FirstName;
        customer.LastName = model.LastName;
        customer.Email = model.Email;
        customer.PhoneNumber = model.PhoneNumber;
        customer.DateOfBirth = model.DateOfBirth;
        customer.Address = model.Address;
        customer.City = model.City;
        customer.Country = model.Country;

        await _customerService.UpdateCustomerAsync(customer);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id);

        if (customer == null)
        {
            return NotFound();
        }

        var model = new CustomerViewModel
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            PhoneNumber = customer.PhoneNumber,
            DateOfBirth = customer.DateOfBirth,
            Address = customer.Address,
            City = customer.City,
            Country = customer.Country
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(CustomerViewModel model)
    {
        await _customerService.DeleteCustomerAsync(model.Id);

        return RedirectToAction(nameof(Index));
    }
}