using OpsAnalytics.Domain.Entities;
using OpsAnalytics.Infrastructure.Repositories.Interface;
using OpsAnalytics.Infrastructure.Services.Interface;

namespace OpsAnalytics.Infrastructure.Services.Implement;
public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _repository;
    public TransactionService(ITransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<TransactionModel>> GetAllTransactionAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<TransactionModel?> GetTransactionAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task CreateTransactionAsync(TransactionModel transaction)
    {
        await _repository.AddAsync(transaction);
        await _repository.SaveChangesAsync();
    }
}