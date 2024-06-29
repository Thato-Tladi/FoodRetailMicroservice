namespace Api.Models;

public partial class FinancialInfo
{
    public int FinancialInfoId { get; set; }

    public string PropertyName { get; set; } = null!;

    public string PropertyValue { get; set; } = null!;
}
