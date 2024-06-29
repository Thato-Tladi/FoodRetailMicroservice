using Api.Models;

namespace Api.Services.Interfaces;

public interface IConsumerHistoryService
{
    public Task<ConsumerHistory> AddConsumerHistory(ConsumerHistory consumerHistory);

    public Task<ICollection<ConsumerHistory>> GetEveryConsumerHistory();

    public Task DeleteEveryConsumerHistory();
}