using Api.Models;

namespace Api.Repository.Interfaces;

public interface IBusinessIdentifierRepository
{
    Task<ICollection<BusinessIdentifier>> GetAllBusinessIdentifiers();

    Task ResetBusinessIdentifiers();

    void SetBusinessIdentifier(BusinessIdentifierProperties identifier, string value);
}