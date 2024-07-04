using Api.Models;

namespace Api.Repository.Interfaces;

public interface IBusinessIdentifierRepository
{
    Task<ICollection<BusinessIdentifier>> GetAllBusinessIdentifiers();

    Task ResetBusinessIdentifiers();

    Task<string> GetBusinessIdentifierValue(string identifier);

    void SetBusinessIdentifier(string identifier, string value);
}