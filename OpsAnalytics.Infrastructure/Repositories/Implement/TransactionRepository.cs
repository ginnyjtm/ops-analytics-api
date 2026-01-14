using Microsoft.EntityFrameworkCore;
using OpsAnalytics.Domain.Entities;
using OpsAnalytics.Infrastructure.Data;
using OpsAnalytics.Infrastructure.Data.Models;
using OpsAnalytics.Infrastructure.Repositories.Interface;
using DomainTransaction = OpsAnalytics.Domain.Entities.Transaction;
using EfTransaction = OpsAnalytics.Infrastructure.Data.Models.Transaction;

namespace OpsAnalytics.Infrastructure.Repositories.Implement;

public class TransactionRepository : ITransactionRepository
{
    private readonly OpsanalyticsContext _context;
    public TransactionRepository(OpsanalyticsContext context)
    {
        _context = context;
    }


    public async Task<List<DomainTransaction>> GetAllAsync()
    {
        return await _context.Transactions.Select(e => new DomainTransaction
        {
            Id = e.Id,
            Amount = e.Amount,
            CreateAt = e.CreateAt
        }).ToListAsync();
    }

    public async Task<DomainTransaction?> GetByIdAsync(Guid id)
    {
        var transaction = await _context.Transactions.FindAsync(id);
        if (transaction == null) return null;

        return new DomainTransaction
        {
            Id = transaction.Id,
            Amount = transaction.Amount,
            CreateAt = transaction.CreateAt
        };
    }

    public async Task AddAsync(DomainTransaction transaction)
    {
        var entity = new EfTransaction
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