using Api.Models;
using Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository;

public class ConsumerHistoryRepository : IConsumerHistoryRepository
{
    private readonly FoodRetailContext _foodRetailContext;

    public ConsumerHistoryRepository(FoodRetailContext foodRetailContext)
    {
        _foodRetailContext = foodRetailContext;
    }

    public async Task<ICollection<ConsumerHistory>> GetEveryConsumerHistory()
    {
        return await _foodRetailContext.ConsumerHistories.ToListAsync();
    }

    public async Task<ConsumerHistory> AddConsumerHistory(ConsumerHistory consumerHistory)
    {
        await _foodRetailContext.ConsumerHistories.AddAsync(consumerHistory);
        await _foodRetailContext.SaveChangesAsync();
        return consumerHistory;
    }

    public async Task ClearConsumerHistory()
    {
        await _foodRetailContext.ConsumerHistories.ExecuteDeleteAsync();
    }
}