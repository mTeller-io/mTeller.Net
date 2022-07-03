namespace Platform.Interface
{
    public interface IMomoCollectionAPIService
    {
        Task<string?> CreateRequestToPay(string token, string amount, string currency, string externalId, string partyId, string partyIdType, string paymentMsg);

        Task<string?> GetRequestToPay(string paymentXreferenceId, string token);

        Task<string?> GetAccountBalance();

        Task<string?> GetAccountHolderActiveStatus(string partyID);

        Task<string?> GetAccountHolderBaseInfo(string subscriptionType, string partyID, string token);
    }
}