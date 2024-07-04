using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Api.Dtos;
using Api.Services.Interfaces;

namespace Api.Services
{
    public class CommercialBankService
    {
        private readonly HttpClient _httpClient;

        public CommercialBankService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TransactionResponse> CreateTransaction(TransactionRequest request)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            
            var response = await _httpClient.PostAsync("/transactions/create", content);
            response.EnsureSuccessStatusCode();
            
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TransactionResponse>(jsonResponse);
        }
    }
}
