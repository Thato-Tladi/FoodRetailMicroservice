using System;

namespace Api.Dtos
{
    public class TaxInvoiceRequest
    {
        public string TaxId { get; set; }
        public string TaxType { get; set; }
        public decimal Amount { get; set; }
    }

    public class TaxInvoiceResponse
    {
        public string PaymentId { get; set; }
        public decimal AmountDue { get; set; }
    }

    public class NoticeOfPaymentRequest
    {
        public string TaxId { get; set; }
        public string PaymentId { get; set; }
        public string CallbackURL { get; set; }
    }

    public class NoticeOfPaymentResponse
    {
        public string Result { get; set; }
    }

    public class TaxPaymentRequest
    {
        public string TaxId { get; set; }
        public string TaxType { get; set; }
        public decimal Amount { get; set; }
        public string DebitAccountName { get; set; }
        public string CallbackURL { get; set; }
    }

    public class TaxPaymentResult
    {
        public TaxInvoiceResponse Invoice { get; set; }
        public TransactionResponse PaymentResult { get; set; }
        public NoticeOfPaymentResponse NoticeResult { get; set; }
    }
}
