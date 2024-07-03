using Api.Repository.Interfaces;
using Api.Models;
using Api.Services.Interfaces;

namespace Api.Services;

public class FinancialInfoService : IFinancialInfoService
{
    private readonly IFinancialInfoRepository _financialInfoRepository;

    public FinancialInfoService(IFinancialInfoRepository financialInfoRepository)
    {
        _financialInfoRepository = financialInfoRepository;
    }

    public async Task<ICollection<FinancialInfo>> ResetFinancialRecords()
    {
        await _financialInfoRepository.SetProfitValue(0);
        return await _financialInfoRepository.GetAllFinancialInfo();
    }

    public async Task<ICollection<FinancialInfo>> GetFinancialInfo()
    {
        return await _financialInfoRepository.GetAllFinancialInfo();
    }
}