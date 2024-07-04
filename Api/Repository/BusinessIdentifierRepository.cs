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

    public async Task<string> GetBusinessIdentifierValue(string businessIdentifier)
    {
        BusinessIdentifier? identifier = await _foodRetailContext.BusinessIdentifiers.FirstOrDefaultAsync(b => b.PropertyName == businessIdentifier);
        return identifier == null ? "" : identifier.PropertyValue;
    }

    public void SetBusinessIdentifier(string identifier, string value)
    {
        BusinessIdentifier? businessIdentifier = _foodRetailContext.BusinessIdentifiers.FirstOrDefault(b => b.PropertyName == identifier);

        if (businessIdentifier == null)
            return;

        businessIdentifier.PropertyValue = value;
        _foodRetailContext.SaveChanges();
    }


    public async Task ResetBusinessIdentifiers()
    {
        await _foodRetailContext.BusinessIdentifiers.ExecuteUpdateAsync(b => b.SetProperty(p => p.PropertyValue, p => ""));
        await _foodRetailContext.SaveChangesAsync();
    }
}