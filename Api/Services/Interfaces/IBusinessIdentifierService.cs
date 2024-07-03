using Api.Models;

namespace Api.Services.Interfaces;

public interface IBusinessIdentifierService
{
    public Task<ICollection<BusinessIdentifier>> GetAllBusinessIdentifiers();

    public void SetBusinessIdentifier(BusinessIdentifierProperties identifier, string value);

    public Task ResetBusinessIdentifiers();
}