using Api.Repository.Interfaces;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BusinessIdentifierController : ControllerBase
{
    private readonly IBusinessIdentifierService _BusinessIdentifierService;

    public BusinessIdentifierController(IBusinessIdentifierService BusinessIdentifierService)
    {
        _BusinessIdentifierService = BusinessIdentifierService;
    }

    /// <summary>
    /// Gets all unique ids attached to the business
    /// </summary>
    /// <returns>JSON Array of all the unique ids attached to the business</returns>
    /// <response code="200"></response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllBusinessIdentifier()
    {
        return Ok(await _BusinessIdentifierService.GetAllBusinessIdentifiers());
    }
}