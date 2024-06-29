namespace Api.Models;

public partial class ConsumerHistory
{
    public int ConsumerHistoryId { get; set; }

    public long ConsumerId { get; set; }

    public DateTime? PurchasedDate { get; set; }

    public double Price { get; set; }
}
