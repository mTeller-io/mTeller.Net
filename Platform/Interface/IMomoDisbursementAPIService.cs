namespace Platform.Interface
{
    public interface IMomoDisbursementAPIService
    {
        Task<string?> GetAccountBalance(string subscriptionType, string token);

        Task<bool> GetAccountHolderActiveStatus(string partyID, string partyIdType);

        Task<string?> GetAccountHolderBaseInfo(string subscriptionType, string partyID, string token);

        Task<string?> CreateTransfer(string partyIdType, decimal amount, string currency, string partyId, string externalId, string paymentMsg);

        Task<string?> GetTransferStatus(string subscriptionType, string paymentXreferenceId, string token);
    }
}