namespace CloudCRM.Core.Entities;

public class MembershipType
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int DurationInMonths { get; set; }

    public decimal Price { get; set; }

    public string Description { get; set; } = string.Empty;

     // Navigation Property
    public ICollection<Membership> Memberships { get; set; } = new List<Membership>();
}