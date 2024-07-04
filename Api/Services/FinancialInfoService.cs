using Api.Repository.Interfaces;
using Api.Repository;
using Api.Models;
using Api.Services.Interfaces;

namespace Api.Services;

public class FinancialInfoService : IFinancialInfoService
{
    private readonly IFinancialInfoRepository _financialInfoRepository;
    private readonly IBusinessIdentifierRepository _businessIdentifierRepository;


    public FinancialInfoService(IFinancialInfoRepository financialInfoRepository,  IBusinessIdentifierRepository businessIdentifierRepository)
    {
        _financialInfoRepository = financialInfoRepository;
       _businessIdentifierRepository = businessIdentifierRepository;
        
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