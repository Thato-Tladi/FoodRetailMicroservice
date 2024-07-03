public class CentralRevenueService
{
    private readonly IHttpClientFactory _factory;

    public CentralRevenueService(IHttpClientFactory factory)
    {
        _factory = factory;
    }

    public async void RegisterBusiness() {
    }
}