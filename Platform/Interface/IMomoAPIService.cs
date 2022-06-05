namespace Platform.Interface
{
    public interface IMomoAPIService
    {
        string GetAPIUser();

        string GenerateToken(string subscriptionType);

        string GetRequestToPay(string paymentXreferenceId, string token);

        string GetAccountBalance(string subscriptionType, string token);

        string GetAccountHolderActiveStatus(string subscriptionType, string partyID, string token);

        string GetAccountHolderBaseInfo(string subscriptionType, string partyID, string token);

        string GetTransfer(string subscriptionType, string paymentXreferenceId, string token);

        string CreateAPIUSer();

        string CreateAPIKey();

        string CreateRequestToPay(string token, string amount, string currency, string externalId, string partyId, string paymentMsg);

        string CreateTransfer(string subscriptionType, string token, string amount, string currency, string partyId, string externalId, string paymentMsg);
    }
}