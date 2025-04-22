namespace SubTrackr.Domain.Entities;

public class Subscription
{
    public int Id { get; set; }

    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public string BillingCycle { get; set; } = default!;
    public DateTime NextBillingDate { get; set; }

    public string UserId { get; set; } = default!;
}
