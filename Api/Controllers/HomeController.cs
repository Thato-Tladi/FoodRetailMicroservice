using Api.Models;
using Api.Services;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/")]
public class HomeController : ControllerBase
{
    private readonly IConsumerHistoryService _consumerHistoryService;
    private readonly IFinancialInfoService _financialInfoService;
    private readonly IBusinessIdentifierService _businessIdentifierService;
    private readonly StockExchangeService _stockExchangeService;
    private readonly HandOfZeusService _handOfZeusService;

    public HomeController(
        IConsumerHistoryService consumerHistoryService,
        IFinancialInfoService financialInfoService,
        IBusinessIdentifierService businessIdentifierService,
        StockExchangeService stockExchangeService,
        HandOfZeusService handOfZeusService)
    {
        _consumerHistoryService = consumerHistoryService;
        _financialInfoService = financialInfoService;
        _stockExchangeService = stockExchangeService;
        _handOfZeusService = handOfZeusService;
        _businessIdentifierService = businessIdentifierService;
    }

    [HttpGet]
    public async Task<ActionResult<string>> GetApiStatus()
    {
        return Ok(await _handOfZeusService.GetCurrentDate());
    }

    [HttpPost("trading")]
    public ActionResult Trading()
    {
        return Ok();
    }

    [HttpGet("start")]
    public async Task<ActionResult<string>> Start()
    {
        await _consumerHistoryService.DeleteEveryConsumerHistory();
        await _financialInfoService.ResetFinancialRecords();
        _stockExchangeService.RegisterBusiness();
        return Ok("Starting");
    }

    [HttpGet("food-price")]
    public async Task<ActionResult<string>> FoodPrice()
    {
        _handOfZeusService.UpdateFoodPrice();
        return Ok("Updated");
    }

    [HttpGet("ping")]
    public async Task<ActionResult<string>> Ping()
    {
        string currentDate = await _handOfZeusService.GetCurrentDate();
        _businessIdentifierService.SetBusinessIdentifier(BusinessIdentifierProperties.DATE, currentDate);
        return Ok("Starting");
    }
}
