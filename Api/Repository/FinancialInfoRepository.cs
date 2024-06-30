using Api.Models;
using Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository;

public class FinancialInfoRepository : IFinancialInfoRepository
{
    private readonly FoodRetailContext _foodRetailContext;

    public FinancialInfoRepository(FoodRetailContext foodRetailContext)
    {
        _foodRetailContext = foodRetailContext;
    }

    public async Task<ICollection<FinancialInfo>> GetAllFinancialInfo()
    {
        return await _foodRetailContext.FinancialInfos.ToListAsync();
    }

    public long GetPropertyValue(FinancialInfoProperties property)
    {
        FinancialInfo? financialInfo = _foodRetailContext.FinancialInfos.FirstOrDefault(info => info.PropertyName == property.ToString());
        return financialInfo == null ? 0 : financialInfo.PropertyValue;
    }

    public async Task AddToProfit(long profit)
    {
        FinancialInfo? profitInfo = _foodRetailContext.FinancialInfos.FirstOrDefault(info => info.PropertyName == FinancialInfoProperties.PROFIT.ToString());

        if (profitInfo == null)
            return;

        profitInfo.PropertyValue += profit;
        await _foodRetailContext.SaveChangesAsync();
    }

    public async Task SetProfitValue(long profit)
    {
        FinancialInfo? profitInfo = _foodRetailContext.FinancialInfos.FirstOrDefault(info => info.PropertyName == FinancialInfoProperties.PROFIT.ToString());

        if (profitInfo == null)
            return;

        profitInfo.PropertyValue = profit;
        await _foodRetailContext.SaveChangesAsync();
    }
}