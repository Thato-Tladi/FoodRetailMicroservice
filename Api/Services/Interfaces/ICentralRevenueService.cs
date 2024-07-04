using Api.Dtos;

namespace Api.Services.Interfaces
{
    public interface ICentralRevenueService
    {
        Task<TaxInvoiceResponse> CreateTaxInvoice(TaxInvoiceRequest request);
        Task<NoticeOfPaymentResponse> SubmitNoticeOfPayment(NoticeOfPaymentRequest request);
        Task<TaxPaymentResult> ProcessTaxPayment();
    }
}