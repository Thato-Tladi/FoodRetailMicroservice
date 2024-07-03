using Api.Repository.Interfaces;
using Api.Models;
using Api.Services.Interfaces;

namespace Api.Services;

public class BusinessIdentifierService : IBusinessIdentifierService
{
    private readonly IBusinessIdentifierRepository _businessIdentifierRepository;

    public BusinessIdentifierService(IBusinessIdentifierRepository BusinessIdentifierRepository)
    {
        _businessIdentifierRepository = BusinessIdentifierRepository;
    }

    public void SetBusinessIdentifier(BusinessIdentifierProperties identifier, string value)
    {
        _businessIdentifierRepository.SetBusinessIdentifier(identifier, value);
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