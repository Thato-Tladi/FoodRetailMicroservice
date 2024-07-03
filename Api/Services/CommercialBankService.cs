public class CommercialBankService
{
    private readonly IHttpClientFactory _factory;

    public CommercialBankService(IHttpClientFactory factory)
    {
        _factory = factory;
    }

}