using System.Text;
using Api.Dtos;
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
        using StringContent jsonContent = new(
            System.Text.Json.JsonSerializer.Serialize(new
            {
                name = BusinessConstants.BUSINESS_NAME,
                bankAccount = BusinessConstants.BUSINESS_NAME
            }),
            Encoding.UTF8, "application/json");

        using HttpResponseMessage response = await _client.PostAsync("businesses", jsonContent);
        response.EnsureSuccessStatusCode();
        var jsonResponse = await response.Content.ReadAsStringAsync();

        StockExchangeRegisterDto registerResponse = JsonConvert.DeserializeObject<StockExchangeRegisterDto>(jsonResponse);
    }
}