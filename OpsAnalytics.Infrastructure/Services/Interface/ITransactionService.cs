using OpsAnalytics.Domain.Entities;

namespace OpsAnalytics.Infrastructure.Services.Interface;

public interface ITransactionService
{
    Task<List<TransactionModel>> GetAllTransactionAsync();
    Task<TransactionModel?> GetTransactionAsync(Guid id);
    Task CreateTransactionAsync(TransactionModel transaction);
}