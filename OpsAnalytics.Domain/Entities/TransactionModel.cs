namespace OpsAnalytics.Domain.Entities;

public class TransactionModel
{
    public Guid Id { get; set; }
    public DateTime TransactionDate { get; set; }
    public decimal Amount { get; set; }
    public string Category { get; set; } = default!;
    public string Region { get; set; } = default!;
    public string Source { get; set; } = default!;
    public DateTime CreateAt { get; set; }
}