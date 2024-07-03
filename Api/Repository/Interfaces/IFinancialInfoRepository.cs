using Api.Models;

namespace Api.Repository.Interfaces;

public interface IFinancialInfoRepository
{
    long GetPropertyValue(FinancialInfoProperties property);

    void SetPropertyValue(FinancialInfoProperties property, long propertyValue);

    Task SetProfitValue(long profit);

    Task AddToProfit(long profit);

    Task<ICollection<FinancialInfo>> GetAllFinancialInfo();
}