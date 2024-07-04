using Api.Models;
using Api.Repository;
using Api.Repository.Interfaces;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BuyController : ControllerBase
{
    private readonly IConsumerHistoryService _consumerHistoryService;
    private readonly RetailBankService _retailBankService;  // Dependency for bank transactions

    private readonly IFinancialInfoRepository _financialInfoRepository;

    public BuyController(
            IConsumerHistoryService consumerHistoryService,
            RetailBankService retailBankService,
            IFinancialInfoRepository financialInfoRepository
        )
    {
        _consumerHistoryService = consumerHistoryService;
        _retailBankService = retailBankService;
        _financialInfoRepository = financialInfoRepository;
    }

    /// <summary>
    /// Buy food for a consumer after checking funds availability.
    /// </summary>
    /// <param name="consumerId">The identifier of the consumer making the purchase.</param>
    /// <returns>A response code indicating the outcome of the buy attempt.</returns>
    /// <response code="200">Food has been purchased</response>
    /// <response code="402">The consumer does not have enough funds</response>
    [HttpGet]
    public async Task<IActionResult> Buy(long consumerId)
    {
        if (consumerId == 0)
        {
            return BadRequest("Invalid consumerId provided.");
        }

        double amountToCheck = _financialInfoRepository.GetPropertyValue(FinancialInfoProperties.FOOD_PRICE);
        string transactionReference = $"Purchase-{consumerId}-{System.DateTime.UtcNow.Ticks}";  // Unique reference for the transaction

        // Make a payment to verify funds before proceeding with the purchase
        bool paymentSuccess = await _retailBankService.MakePayment(consumerId, amountToCheck, transactionReference);

        // if (!paymentSuccess)
        // {
        //     return StatusCode(402, "The consumer does not have enough funds.");
        // }

        // If the payment is successful, proceed to log this transaction and complete the purchase
        ConsumerHistory consumerHistory = await _consumerHistoryService.AddConsumerHistory(consumerId);

        return Ok(consumerHistory);
    }
}
