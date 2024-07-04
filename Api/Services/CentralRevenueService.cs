using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Api.Dtos;
using Api.Services.Interfaces;
using Api.Repository.Interfaces;
using Api.Models;

namespace Api.Services
{
    public class CentralRevenueService
    {
        private readonly HttpClient _httpClient;
        private readonly CommercialBankService _commercialBankService;
        private readonly IFinancialInfoRepository _financialInfoRepository;
        private readonly IBusinessIdentifierRepository _businessIdentifierRepository;

        public CentralRevenueService(HttpClient httpClient, CommercialBankService commercialBankService, IFinancialInfoRepository financialInfoRepository, IBusinessIdentifierRepository businessIdentifierRepository)
        {
            _httpClient = httpClient;
            _commercialBankService = commercialBankService;
            _financialInfoRepository = financialInfoRepository;
            _businessIdentifierRepository = businessIdentifierRepository;
        }

        public async Task<TaxInvoiceResponse> CreateTaxInvoice(TaxInvoiceRequest request)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/taxpayment/createTaxInvoice", content);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TaxInvoiceResponse>(jsonResponse);
        }

        public async Task<NoticeOfPaymentResponse> SubmitNoticeOfPayment(NoticeOfPaymentRequest request)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/taxpayment/submitNoticeOfPayment", content);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<NoticeOfPaymentResponse>(jsonResponse);
        }

        public async Task<TaxPaymentResult> ProcessTaxPayment()
        {
            Console.WriteLine("Starting the tax payment process.");
            // Internal construction of TaxPaymentRequest based on fetched data
            long currentProfit =  _financialInfoRepository.GetPropertyValue(FinancialInfoProperties.PROFIT);
            Console.WriteLine($"Retrieved current profit: {currentProfit}");
            //string taxId = _businessIdentifierRepository.GetBusinessIdentifierValue(BusinessIdentifierProperties.TAX_ID);
            string taxId = "0053fd68-7271-483a-b373-779c3c5365f0";
            Console.WriteLine($"Retrieved Tax ID: {taxId}");

            var request = new TaxPaymentRequest
            {
                DebitAccountName = "BusinessAccount", // assuming account name, replace with actual if different
                TaxId = taxId,
                TaxType = "INCOME",
                Amount = currentProfit
                //CallbackURL = "https://example.com/callback" // assuming callback URL
            };
             //Console.WriteLine($"Invoice created with ID: {TaxInvoiceResponse.PaymentId}");


            // Processing the internally generated request
            var invoice = await CreateTaxInvoice(new TaxInvoiceRequest
            {
                TaxId = request.TaxId,
                TaxType = request.TaxType,
                Amount = request.Amount
            });
//Console.WriteLine($"Transaction status: {transactionResponse.Status}");
            var bankTransaction = new TransactionRequest
            {
                Transactions = new[]
                {
                    new Transaction
                    {
                        DebitAccountName = request.DebitAccountName,
                        CreditAccountName = "CentralRevenueTaxAccount",
                        Amount = invoice.AmountDue,
                        DebitRef = $"TaxPayment_{invoice.PaymentId}",
                        CreditRef = invoice.PaymentId.ToString()
                    }
                }
            };

            var paymentResult = await _commercialBankService.CreateTransaction(bankTransaction);

            var noticeResult = await SubmitNoticeOfPayment(new NoticeOfPaymentRequest
            {
                TaxId = request.TaxId,
                PaymentId = invoice.PaymentId,
                CallbackURL = request.CallbackURL
            });

            return new TaxPaymentResult
            {
                Invoice = invoice,
                PaymentResult = paymentResult,
                NoticeResult = noticeResult
            };
        }
    }
}
