using Api.Repository.Interfaces;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FinancialInfoController : ControllerBase
{
    private readonly IFinancialInfoService _financialInfoService;

    public FinancialInfoController(IFinancialInfoService financialInfoService)
    {
        _financialInfoService = financialInfoService;
    }

    /// <summary>
    /// Gets all financial information of the business
    /// </summary>
    /// <returns>JSON Array of all financial information</returns>
    /// <response code="200"></response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllFinancialInfo()
    {
        return Ok(await _financialInfoService.GetFinancialInfo());
    }
}