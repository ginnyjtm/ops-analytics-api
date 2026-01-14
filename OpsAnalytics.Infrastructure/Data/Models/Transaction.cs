using System;
using System.Collections.Generic;

namespace OpsAnalytics.Infrastructure.Data.Models;

public partial class Transaction
{
    public Guid Id { get; set; }

    public DateTime TransactionDate { get; set; }

    public decimal Amount { get; set; }

    public string Category { get; set; }

    public string Region { get; set; }

    public string Source { get; set; }

    public DateTime CreateAt { get; set; }
}
