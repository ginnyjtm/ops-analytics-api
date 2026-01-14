using OpsAnalytics.Domain.Entities;

namespace OpsAnalytics.Infrastructure.Services.Interface;

public interface ITransactionService
{
    Task<List<Transaction>> GetAllTransactionAsync();
    Task<Transaction?> GetTransactionAsync(Guid id);
    Task CreateTransactionAsync(Transaction transaction);
}