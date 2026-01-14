using OpsAnalytics.Domain.Entities;

namespace OpsAnalytics.Infrastructure.Repositories.Interface;

public interface ITransactionRepository
{
    Task<List<Transaction>> GetAllAsync();
    Task<Transaction?> GetByIdAsync(Guid Id);
    Task AddAsync(Transaction transaction);
    Task SaveChangesAsync();
}