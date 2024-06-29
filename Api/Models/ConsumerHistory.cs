using System.ComponentModel.DataAnnotations;

namespace Api.Models;

public partial class ConsumerHistory
{
    public int ConsumerHistoryId { get; set; }

    [Required(ErrorMessage = "ConsumerId is required")]
    public int ConsumerId { get; set; }

    public DateTime? PurchasedDate { get; set; }
}
