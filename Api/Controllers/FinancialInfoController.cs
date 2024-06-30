using Api.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FinancialInfoController : ControllerBase
{
    private readonly IFinancialInfoRepository _financialInfoRepository;

    public FinancialInfoController(IFinancialInfoRepository financialInfoRepository)
    {
        _financialInfoRepository = financialInfoRepository;
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
        return Ok(await _financialInfoRepository.GetAllFinancialInfo());
    }
}