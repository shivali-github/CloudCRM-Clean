using CloudCRM.Application.Interfaces.Services;
using CloudCRM.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CloudCRM.Core.Entities;

namespace CloudCRM.Web.Controllers;

public class PaymentsController : Controller
{
    private readonly IPaymentService _paymentService;
    private readonly IMembershipService _membershipService;

    public PaymentsController(
        IPaymentService paymentService,
        IMembershipService membershipService)
    {
        _paymentService = paymentService;
        _membershipService = membershipService;
    }

    public async Task<IActionResult> Index()
    {
        var payments =
            await _paymentService.GetAllPaymentsAsync();

        return View(payments);
    }

    public async Task<IActionResult> Create()
    {
        var model = new PaymentViewModel();

        await LoadMemberships(model);

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(PaymentViewModel model)
    {
        if (!ModelState.IsValid)
        {
            await LoadMemberships(model);

            return View(model);
        }

        var payment = new Payment
        {
            MembershipId = model.MembershipId,
            Amount = model.Amount,
            PaymentDate = model.PaymentDate,
            PaymentMethod = model.PaymentMethod,
            TransactionReference = model.TransactionReference
        };

        await _paymentService.AddPaymentAsync(payment);

        return RedirectToAction(nameof(Index));
    }

    private async Task LoadMemberships(PaymentViewModel model)
    {
        var memberships =
            await _membershipService.GetAllMembershipsAsync();

        model.Memberships = memberships.Select(m => new SelectListItem
        {
            Value = m.Id.ToString(),
            Text = $"{m.Customer.FirstName} {m.Customer.LastName} - {m.MembershipType.Name}"
        }).ToList();
    }

    public async Task<IActionResult> Edit(int id)
    {
        var payment = await _paymentService
            .GetPaymentByIdAsync(id);

        if (payment == null)
            return NotFound();

        var model = new PaymentViewModel
        {
            Id = payment.Id,
            MembershipId = payment.MembershipId,
            Amount = payment.Amount,
            PaymentDate = payment.PaymentDate,
            PaymentMethod = payment.PaymentMethod,
            TransactionReference = payment.TransactionReference
        };

        await LoadMemberships(model);

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(PaymentViewModel model)
    {
        if (!ModelState.IsValid)
        {
            await LoadMemberships(model);

            return View(model);
        }

        var payment = new Payment
        {
            Id = model.Id,
            MembershipId = model.MembershipId,
            Amount = model.Amount,
            PaymentDate = model.PaymentDate,
            PaymentMethod = model.PaymentMethod,
            TransactionReference = model.TransactionReference
        };

        await _paymentService
            .UpdatePaymentAsync(payment);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var payment = await _paymentService
            .GetPaymentByIdAsync(id);

        if (payment == null)
            return NotFound();

        return View(payment);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _paymentService.DeletePaymentAsync(id);

        return RedirectToAction(nameof(Index));
    }
}