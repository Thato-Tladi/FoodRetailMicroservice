using Api.Repository.Interfaces;
using Newtonsoft.Json;

public class HandOfZeusService
{
    private readonly HttpClient _client;
    private readonly IFinancialInfoRepository _financialInfoRepository;

    public HandOfZeusService(HttpClient client, IFinancialInfoRepository financialInfoRepository)
    {
        _client = client;
        _financialInfoRepository = financialInfoRepository;
    }

    public async Task<string> GetCurrentDate()
    {
        long currentTimeMillis = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        try
        {
            using HttpResponseMessage response = await _client.GetAsync($"date?time={currentTimeMillis}");
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            CurrentDateDto dateResponse = JsonConvert.DeserializeObject<CurrentDateDto>(jsonResponse);
            return dateResponse.date;
        }
        catch (Exception)
        {
            return "01|01|01";
        }
    }

    public async void UpdateFoodPrice()
    {
        try
        {
            using HttpResponseMessage response = await _client.GetAsync("food-price");
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var foodPrice = JsonConvert.DeserializeObject<IDictionary<string, int>>(jsonResponse);
            _financialInfoRepository.SetPropertyValue(Api.Models.FinancialInfoProperties.FOOD_PRICE, foodPrice["value"]);
        }
        catch (Exception)
        {
        }
    }
}