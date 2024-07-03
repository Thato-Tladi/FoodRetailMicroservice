using Api.Models;
using Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository;

public class BusinessIdentifierRepository : IBusinessIdentifierRepository
{
    private readonly FoodRetailContext _foodRetailContext;

    public BusinessIdentifierRepository(FoodRetailContext foodRetailContext)
    {
        _foodRetailContext = foodRetailContext;
    }

    public async Task<ICollection<BusinessIdentifier>> GetAllBusinessIdentifiers()
    {
        return await _foodRetailContext.BusinessIdentifiers.ToListAsync();
    }

    public string GetBusinessIdentifierValue(BusinessIdentifierProperties businessIdentifier)
    {
        BusinessIdentifier? identifier = _foodRetailContext.BusinessIdentifiers.FirstOrDefault(b => b.PropertyName == businessIdentifier.ToString());
        return identifier == null ? "" : identifier.PropertyValue;
    }

    public void SetBusinessIdentifier(BusinessIdentifierProperties identifier, string value)
    {
        BusinessIdentifier? businessIdentifier = _foodRetailContext.BusinessIdentifiers.FirstOrDefault(b => b.PropertyName == identifier.ToString());

        if (businessIdentifier == null)
            return;

        businessIdentifier.PropertyValue = value;
    }


    public async Task ResetBusinessIdentifiers()
    {
        await _foodRetailContext.BusinessIdentifiers.ExecuteUpdateAsync(b => b.SetProperty(p => p.PropertyValue, p => ""));
    }
}