namespace CloudCRM.Core.Entities;

public class Membership
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int MembershipTypeId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public bool IsActive { get; set; }
}