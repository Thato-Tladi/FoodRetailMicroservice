using System.Text;
using Api.Dtos;
using Newtonsoft.Json;

public class StockExchangeService
{
    private readonly HttpClient _client;
    private readonly IConfiguration _config;

    public StockExchangeService(HttpClient client, IConfiguration config)
    {
        _client = client;
        _config = config;
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

        string callbackUrl = _config["AppSettings:Url"] + "/trading";
        using HttpResponseMessage response = await _client.PostAsync($"businesses?callbackUrl='{callbackUrl}'", jsonContent);
        response.EnsureSuccessStatusCode();
        var jsonResponse = await response.Content.ReadAsStringAsync();

        StockExchangeRegisterDto registerResponse = JsonConvert.DeserializeObject<StockExchangeRegisterDto>(jsonResponse);
    }
}