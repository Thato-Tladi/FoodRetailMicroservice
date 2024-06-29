using Api.Services;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConsumerHistoryController : ControllerBase
{
    private readonly IConsumerHistoryService _consumerHistoryService;

    public ConsumerHistoryController(IConsumerHistoryService consumerHistoryService)
    {
        _consumerHistoryService = consumerHistoryService;
    }

    /// <summary>
    /// Gets all purchases for all consumers
    /// </summary>
    /// <returns>JSON Array of all purchases made</returns>
    /// <response code="200"></response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllConsumerHistory()
    {
        return Ok(await _consumerHistoryService.GetEveryConsumerHistory());
    }
}