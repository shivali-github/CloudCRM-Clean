using Microsoft.AspNetCore.Mvc.Rendering;

namespace CloudCRM.Web.Models.ViewModels;

public class PaymentViewModel
{
    public int Id { get; set; }

    public int MembershipId { get; set; }

    public decimal Amount { get; set; }

    public DateTime PaymentDate { get; set; }

    public string PaymentMethod { get; set; } = string.Empty;

    public string TransactionReference { get; set; }
        = string.Empty;

    public List<SelectListItem> Memberships { get; set; }
        = new();
}