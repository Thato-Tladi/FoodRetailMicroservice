namespace Api.Dtos
{
    public class TransactionRequest
    {
        public Transaction[] Transactions { get; set; }
    }

    public class Transaction
    {
        public string DebitAccountName { get; set; }
        public string CreditAccountName { get; set; }
        public decimal Amount { get; set; }
        public string DebitRef { get; set; }
        public string CreditRef { get; set; }
    }

    public class TransactionResponse
    {
        public int Status { get; set; }
        public TransactionData Data { get; set; }
        public string Message { get; set; }
    }

    public class TransactionData
    {
        public int PageIndex { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentItemCount { get; set; }
        public TransactionItem[] Items { get; set; }
    }

    public class TransactionItem
    {
        public Guid Id { get; set; }
        public string DebitAccountName { get; set; }
        public string CreditAccountName { get; set; }
        public string Reference { get; set; }
        public decimal Amount { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
    }
}
