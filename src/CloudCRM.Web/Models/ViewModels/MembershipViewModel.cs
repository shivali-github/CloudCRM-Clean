using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CloudCRM.Web.Models.ViewModels;

public class MembershipViewModel
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Customer")]
    public int CustomerId { get; set; }

    [Required]
    [Display(Name = "Membership Type")]
    public int MembershipTypeId { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Start Date")]
    public DateTime StartDate { get; set; } = DateTime.Today;

    public DateTime EndDate { get; set; }

    public decimal Price { get; set; }

    public bool IsActive { get; set; } = true;

    public List<SelectListItem> Customers { get; set; } = new();

    public List<SelectListItem> MembershipTypes { get; set; } = new();
}