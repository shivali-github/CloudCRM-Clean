namespace CloudCRM.Web.Models.ViewModels;

public class DashboardViewModel
{
    public int TotalCustomers { get; set; }

    public int ActiveMemberships { get; set; }

    public int TotalPayments { get; set; }

    public decimal TotalRevenue { get; set; }
}