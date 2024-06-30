using Api.Models;

namespace Api.Services.Interfaces;

public interface IFinancialInfoService
{
    public Task<ICollection<FinancialInfo>> GetFinancialInfo();
}