using Api.Dtos;

namespace Api.Services.Interfaces
{
    public interface ICommercialBankService
    {
        Task<TransactionResponse> CreateTransaction(TransactionRequest request);
    }
}