using Api.Models;

namespace Api.Services.Interfaces;

public interface IFinancialInfoService
{
    public Task<ICollection<FinancialInfo>> GetFinancialInfo();

    public Task<ICollection<FinancialInfo>> ResetFinancialRecords();
}