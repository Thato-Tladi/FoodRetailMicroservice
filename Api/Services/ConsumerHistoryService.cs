using Api.Repository.Interfaces;
using Api.Models;
using Api.Services.Interfaces;

namespace Api.Services;

public class ConsumerHistoryService : IConsumerHistoryService
{
    private readonly IConsumerHistoryRepository _consumerHistoryRepository;

    public ConsumerHistoryService(IConsumerHistoryRepository consumerHistoryRepository)
    {
        _consumerHistoryRepository = consumerHistoryRepository;
    }

    public async Task<ConsumerHistory> AddConsumerHistory(ConsumerHistory consumerHistory)
    {
        return await _consumerHistoryRepository.AddConsumerHistory(consumerHistory);
    }

    public async Task<ICollection<ConsumerHistory>> GetEveryConsumerHistory()
    {
        return await _consumerHistoryRepository.GetEveryConsumerHistory();
    }
}