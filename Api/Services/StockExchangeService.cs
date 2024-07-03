using System.Text;
using System.Text.Json;
using Api.Dtos;
using Api.Repository.Interfaces;
using Newtonsoft.Json;

public class StockExchangeService
{
    private readonly HttpClient _client;

    public StockExchangeService(HttpClient client)
    {
        _client = client;
    }

    public async void RegisterBusiness()
    {
        Console.WriteLine(BusinessConstants.TRADING_ID);
        StringContent jsonContent = new(
            System.Text.Json.JsonSerializer.Serialize(new
            {
                name = BusinessConstants.BUSINESS_NAME,
                bankAccount = BusinessConstants.BUSINESS_NAME
            }),
        Encoding.UTF8, "application/json");

        HttpResponseMessage response = await _client.PostAsync("/businesses", jsonContent);
        Console.WriteLine(response.ToString());
        var jsonResponse = await response.Content.ReadAsStringAsync();
        StockExchangeRegisterDto? registerResponse = JsonConvert.DeserializeObject<StockExchangeRegisterDto>(jsonResponse) ?? throw new Exception("Failed to register business");

        if (registerResponse.tradingId == null)
        {
            throw new Exception("No trading id given");
        }

        BusinessConstants.TRADING_ID = registerResponse.tradingId;
        Console.WriteLine(BusinessConstants.TRADING_ID);
    }
}