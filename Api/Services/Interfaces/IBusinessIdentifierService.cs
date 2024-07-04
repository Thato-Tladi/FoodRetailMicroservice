using Api.Models;

namespace Api.Services.Interfaces;

public interface IBusinessIdentifierService
{
    public Task<ICollection<BusinessIdentifier>> GetAllBusinessIdentifiers();

    public void SetBusinessIdentifier(string identifier, string value);

    public Task<string> GetBusinessIdentifier(string identifier);

    public Task ResetBusinessIdentifiers();

}