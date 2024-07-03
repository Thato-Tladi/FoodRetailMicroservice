namespace Api.Models;

public partial class BusinessIdentifier
{
    public int BusinessIdentifierId { get; set; }

    public string PropertyName { get; set; } = null!;

    public string PropertyValue { get; set; } = null!;
}
