using CloudCRM.Application.Interfaces.Services;
using CloudCRM.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CloudCRM.Web.Controllers;

public class DashboardController : Controller
{
    private readonly ICustomerService _customerService;
    private readonly IMembershipService _membershipService;
    private readonly IPaymentService _paymentService;

    public DashboardController(
        ICustomerService customerService,
        IMembershipService membershipService,
        IPaymentService paymentService)
    {
        _customerService = customerService;
        _membershipService = membershipService;
        _paymentService = paymentService;
    }

    public async Task<IActionResult> Index()
    {
        var customers =
            await _customerService.GetAllCustomersAsync();

        var memberships =
            await _membershipService.GetAllMembershipsAsync();

        var payments =
            await _paymentService.GetAllPaymentsAsync();

        var model = new DashboardViewModel
        {
            TotalCustomers = customers.Count,

            ActiveMemberships = memberships
                .Count(m => m.IsActive),

            TotalPayments = payments.Count,

            TotalRevenue = payments
                .Sum(p => p.Amount)
        };

        return View(model);
    }
}