using System.ComponentModel.DataAnnotations;

namespace CloudCRM.Web.Models.ViewModels;

public class MembershipTypeViewModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(1, 60)]
    public int DurationInMonths { get; set; }

    [Required]
    [Range(1, 100000)]
    public decimal Price { get; set; }

    [StringLength(250)]
    public string Description { get; set; } = string.Empty;
}