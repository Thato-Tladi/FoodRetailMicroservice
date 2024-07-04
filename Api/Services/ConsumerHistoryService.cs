using Api.Repository.Interfaces;
using Api.Models;
using Api.Services.Interfaces;

namespace Api.Services;

public class ConsumerHistoryService : IConsumerHistoryService
{
    private readonly IConsumerHistoryRepository _consumerHistoryRepository;
    private readonly IFinancialInfoRepository _financialInfoRepository;
    private readonly IBusinessIdentifierRepository _businessIdentifierRepository;

    public ConsumerHistoryService(
        IConsumerHistoryRepository consumerHistoryRepository,
        IFinancialInfoRepository financialInfoRepository,
        IBusinessIdentifierRepository businessIdentifierRepository)
    {
        _consumerHistoryRepository = consumerHistoryRepository;
        _financialInfoRepository = financialInfoRepository;
        _businessIdentifierRepository = businessIdentifierRepository;
    }

    public async Task<ConsumerHistory> AddConsumerHistory(long consumerId)
    {
        long foodCostPrice = _financialInfoRepository.GetPropertyValue(FinancialInfoProperties.FOOD_PRICE);
        long vatPercentage = _financialInfoRepository.GetPropertyValue(FinancialInfoProperties.VAT);
        long markUpPercentage = _financialInfoRepository.GetPropertyValue(FinancialInfoProperties.MARK_UP);

        long foodSellingPrice = foodCostPrice * (100 + vatPercentage + markUpPercentage) / 100;

        ConsumerHistory consumerHistory = new()
        {
            ConsumerId = (int)consumerId,
            PurchasedDate = await _businessIdentifierRepository.GetBusinessIdentifierValue(BusinessIdentifierProperties.DATE),
            Price = foodSellingPrice
        };

        consumerHistory = await _consumerHistoryRepository.AddConsumerHistory(consumerHistory);
        await _financialInfoRepository.AddToProfit(foodSellingPrice - foodCostPrice);

        return consumerHistory;
    }

    public async Task<ICollection<ConsumerHistory>> GetEveryConsumerHistory()
    {
        return await _consumerHistoryRepository.GetEveryConsumerHistory();
    }

    public async Task DeleteEveryConsumerHistory()
    {
        await _financialInfoRepository.SetProfitValue(0);
        await _consumerHistoryRepository.ClearConsumerHistory();
    }
}