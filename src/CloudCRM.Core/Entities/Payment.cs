namespace CloudCRM.Core.Entities;

public class Payment
{
    public int Id { get; set; }

    public int MembershipId { get; set; }

    public decimal Amount { get; set; }

    public DateTime PaymentDate { get; set; }

    public string PaymentMethod { get; set; } = string.Empty;

    public string TransactionReference { get; set; } = string.Empty;

     // Navigation Property
    public Membership Membership { get; set; } = null!;
}