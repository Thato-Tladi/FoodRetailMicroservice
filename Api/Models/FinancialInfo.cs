using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class FinancialInfo
{
    public int FinancialInfoId { get; set; }

    public string PropertyName { get; set; } = null!;

    public long PropertyValue { get; set; }
}
