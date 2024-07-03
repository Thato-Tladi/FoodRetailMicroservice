using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class ConsumerHistory
{
    public int ConsumerHistoryId { get; set; }

    public long ConsumerId { get; set; }

    public string? PurchasedDate { get; set; }

    public long Price { get; set; }
}
