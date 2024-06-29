using Api.Models;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BuyController : ControllerBase
{
    private readonly IConsumerHistoryService _consumerHistoryService;

    public BuyController(IConsumerHistoryService consumerHistoryService)
    {
        _consumerHistoryService = consumerHistoryService;
    }

    /// <summary>
    /// Buy food for a consumer
    /// </summary>
    /// <param name="consumerId"></param>
    /// <returns>A response code depending on whether the buy was successful</returns>
    /// <response code="200">Food has been purchased</response>
    /// <response code="402">The consumer does not have enough funds</response>
    [HttpGet]
    public async Task<IActionResult> Buy(long consumerId)
    {
        if (consumerId == 0)
        {
            return BadRequest("Invalid consumerId");
        }

        ConsumerHistory consumerHistory = await _consumerHistoryService.AddConsumerHistory(new()
        {
            ConsumerId = (int)consumerId,
            PurchasedDate = DateTime.Now
        });

        return Ok(consumerHistory);
    }
}