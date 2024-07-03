using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/")]
public class HomeController : ControllerBase
{
    private readonly IConsumerHistoryService _consumerHistoryService;
    private readonly IFinancialInfoService _financialInfoService;
    private readonly StockExchangeService _stockExchangeService;

    public HomeController(IConsumerHistoryService consumerHistoryService, IFinancialInfoService financialInfoService, StockExchangeService stockExchangeService)
    {
        _consumerHistoryService = consumerHistoryService;
        _financialInfoService = financialInfoService;
        _stockExchangeService = stockExchangeService;
    }

    [HttpGet]
    public ActionResult<string> GetApiStatus()
    {
        return Ok("FoodRetailer is up and ready to go!");
    }

    [HttpGet("start")]
    public ActionResult<string> Start()
    {
        _stockExchangeService.RegisterBusiness();
        return Ok("Starting");
    }

    [HttpGet("reset")]
    public async Task<ActionResult<string>> Reset()
    {
        await _consumerHistoryService.DeleteEveryConsumerHistory();
        await _financialInfoService.ResetFinancialRecords();
        return Ok("Reset");
    }
}
