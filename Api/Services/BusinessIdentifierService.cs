using Api.Repository.Interfaces;
using Api.Models;
using Api.Services.Interfaces;

namespace Api.Services;

public class BusinessIdentifierService : IBusinessIdentifierService
{
    private readonly IBusinessIdentifierRepository _businessIdentifierRepository;

    public BusinessIdentifierService(IBusinessIdentifierRepository businessIdentifierRepository)
    {
        _businessIdentifierRepository = businessIdentifierRepository;
    }

    public void SetBusinessIdentifier(string identifier, string value)
    {
        _businessIdentifierRepository.SetBusinessIdentifier(identifier, value);
    }

    public async Task<string> GetBusinessIdentifier(string identifier)
    {
        return await _businessIdentifierRepository.GetBusinessIdentifierValue(identifier);
    }

    public async Task ResetBusinessIdentifiers()
    {
        await _businessIdentifierRepository.ResetBusinessIdentifiers();
    }

    public async Task<ICollection<BusinessIdentifier>> GetAllBusinessIdentifiers()
    {
        return await _businessIdentifierRepository.GetAllBusinessIdentifiers();
    }
}