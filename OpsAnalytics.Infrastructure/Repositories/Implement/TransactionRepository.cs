using Microsoft.EntityFrameworkCore;
using OpsAnalytics.Infrastructure.Data.Models;
using OpsAnalytics.Infrastructure.Repositories.Interface;
using OpsAnalytics.Domain.Entities;

namespace OpsAnalytics.Infrastructure.Repositories.Implement;

public class TransactionRepository : ITransactionRepository
{
    private readonly OpsanalyticsContext _context;
    public TransactionRepository(OpsanalyticsContext context)
    {
        _context = context;
    }


    public async Task<List<TransactionModel>> GetAllAsync()
    {
        return await _context.Transactions.Select(e => new TransactionModel
        {
            Id = e.Id,
            Amount = e.Amount,
            CreateAt = e.CreateAt
        }).ToListAsync();
    }

    public async Task<TransactionModel?> GetByIdAsync(Guid id)
    {
        var transaction = await _context.Transactions.FindAsync(id);
        if (transaction == null) return null;

        return new TransactionModel
        {
            Id = transaction.Id,
            Amount = transaction.Amount,
            CreateAt = transaction.CreateAt
        };
    }

    public async Task AddAsync(TransactionModel transaction)
    {
        var entity = new Transaction
        {
            Id = transaction.Id,
            Amount = transaction.Amount,
            CreateAt = transaction.CreateAt
        };

        _context.Transactions.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}