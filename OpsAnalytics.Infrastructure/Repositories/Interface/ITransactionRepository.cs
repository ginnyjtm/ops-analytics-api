using OpsAnalytics.Domain.Entities;

namespace OpsAnalytics.Infrastructure.Repositories.Interface;

public interface ITransactionRepository
{
    Task<List<TransactionModel>> GetAllAsync();
    Task<TransactionModel?> GetByIdAsync(Guid Id);
    Task AddAsync(TransactionModel transaction);
    Task SaveChangesAsync();
}