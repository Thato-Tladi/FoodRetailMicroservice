using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

public class RetailBankService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<RetailBankService> _logger;

    public RetailBankService(HttpClient httpClient, ILogger<RetailBankService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    /// <summary>
    /// Attempts to make a payment from the consumer's account to a predefined recipient account.
    /// </summary>
    /// <param name="consumerId">The consumer's ID, which is used as the senderId in the payment request.</param>
    /// <param name="amount">The amount in MibiBBDough to be transferred.</param>
    /// <param name="reference">A unique reference for the payment transaction.</param>
    /// <returns>true if the payment is successful; otherwise, false.</returns>
    public async Task<bool> MakePayment(long consumerId, double amount, string reference)
    {

        var paymentRequest = new
        {
            senderId = consumerId,
            amountInMibiBBDough = amount,
            recepient = new
            {
                bankId = 1001,
                accountId = "food-retailer"
            },
            reference = reference
        };


        var content = new StringContent(JsonConvert.SerializeObject(paymentRequest), Encoding.UTF8, "application/json");
        

        _httpClient.DefaultRequestHeaders.Add("X-PartnerId", "food_retailer");

        try
        {

            var response = await _httpClient.PostAsync("/api/transactions/payments", content);


            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation($"Payment successful for Consumer ID {consumerId}.");
                return true;
            }
            else
            {
                _logger.LogInformation(response.ToString());
                _logger.LogError($"Payment failed for Consumer ID {consumerId}. Status Code: {response.StatusCode}.");
                return false;
            }
        }
        catch (Exception ex)
        {

            _logger.LogError($"An error occurred during the payment transaction for Consumer ID {consumerId}: {ex.Message}");
            return false;
        }
    }
}
