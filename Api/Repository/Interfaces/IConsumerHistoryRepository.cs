using Api.Models;

namespace Api.Repository.Interfaces;

public interface IConsumerHistoryRepository
{
    Task<ICollection<ConsumerHistory>> GetEveryConsumerHistory();

    Task<ConsumerHistory> AddConsumerHistory(ConsumerHistory consumerHistory);

    Task ClearConsumerHistory();
}