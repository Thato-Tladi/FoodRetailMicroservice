using Api.Models;

namespace Api.Repository.Interfaces;

public interface IFinancialInfoRepository
{
    long GetPropertyValue(FinancialInfoProperties property);

    Task SetProfitValue(long profit);

    Task AddToProfit(long profit);

    Task<ICollection<FinancialInfo>> GetAllFinancialInfo();
}