using Microsoft.Extensions.Configuration;
using Platform.Interface;
using Platform.Model;
using RestSharp;

namespace Platform
{
    public class MomoDisbursementAPIService : IMomoDisbursementAPIService
    {
        private readonly IAPIAdapter _apiAdaptor;

        private readonly IConfiguration _configuration;

        public MomoAPIDisbursementConfig? MomoAPIDisbursementConfig { get; private set; }

        public MomoDisbursementAPIService(IConfiguration configuration)
        {
            _configuration = configuration;

            MomoAPIDisbursementConfig = _configuration.GetSection(MomoAPIDisbursementConfig.ConfigKey)
                                                    .Get<MomoAPIDisbursementConfig>();

            RestClient _restClient = new(MomoAPIDisbursementConfig.BaseUrl);

            _apiAdaptor = new APIAdapter(MomoAPIDisbursementConfig.APIUser,
            MomoAPIDisbursementConfig.APIKey, MomoAPIDisbursementConfig.BaseUrl, _restClient);
        }

        /// <summary>
        /// This method gets the auth token
        /// </summary>
        /// <param name="subscriptionType">The type of subscription (disbursement, collection, remittance)</param>
        /// <returns>Returns an auth token</returns>
        public static string GenerateToken(string subscriptionType)
        {
            // var client = new RestClient($"{endpoint}/{subscriptionType}/token/")
            // {
            //     Timeout = -1
            // };

            // var request = new RestRequest(Method.POST);
            // request.AddHeader("Ocp-Apim-Subscription-Key", subscriptionKey);
            // request.AddHeader("Authorization", "Basic N2YyZjllY2UtMjNlZC00OWRlLWFiNDgtYmNhODY3M2M0NDAzOjkwZmExYjc0MjI5YjRjYmZhNjQ1ODg0M2MzZjBiZWRk");
            // IRestResponse response = client.Execute(request);
            return string.Empty;
        }

        /// <summary>
        /// This method gets the account balance
        /// </summary>
        /// <returns>Returns the account balance</returns>
        public async Task<string?> GetAccountBalance(string subscriptionType, string token)
        {
            //prepare  headers
            var requestHeaders = new Dictionary<string, string>
            {
                { MomoAPIDisbursementConfig!.TargetEnvironmentHeaderKeyName, MomoAPIDisbursementConfig!.TargetEnvironment },
                { MomoAPIDisbursementConfig!.SubscriptionHeaderKeyName, MomoAPIDisbursementConfig!.PrimarySubscriptionKey }
            };

            var response = await _apiAdaptor.ExecuteGetAsync(MomoAPIDisbursementConfig.AccountBalanceEndPoint, requestHeaders, null, null);

            return response.Content;
        }

        /// <summary>
        /// This method gets the account holders active status
        /// </summary>
        /// <param name="partyID">The customer number or Id</param>
        /// <returns>Returns the status of the momo account which holds a subscription</returns>
        public async Task<string?> GetAccountHolderActiveStatus(string partyID)
        {
            var routeParams = new Dictionary<string, string>();
            var requestHeaders = new Dictionary<string, string>();
            routeParams.Add(MomoAPIDisbursementConfig!.AccountHolderIdHeaderKeyName, partyID);
            requestHeaders.Add(MomoAPIDisbursementConfig!.TargetEnvironmentHeaderKeyName, MomoAPIDisbursementConfig!.TargetEnvironment);
            requestHeaders.Add(MomoAPIDisbursementConfig!.SubscriptionHeaderKeyName, MomoAPIDisbursementConfig!.PrimarySubscriptionKey);

            var response = await _apiAdaptor.ExecuteGetAsync(MomoAPIDisbursementConfig.AccountHolderActiveStatusEndPoint, requestHeaders, null, routeParams);

            return response.Content;
        }

        /// <summary>
        /// Makes a call to get the account holders basic information
        /// </summary>
        /// <param name="partyID">The phone number of the account holder</param>
        /// <returns>Returns the account holders basic information</returns>
        public async Task<string?> GetAccountHolderBaseInfo(string subscriptionType, string partyID, string token)
        {
            var routeParams = new Dictionary<string, string>();
            var requestHeaders = new Dictionary<string, string>();
            routeParams.Add(MomoAPIDisbursementConfig!.AccountHolderIdHeaderKeyName, partyID);
            requestHeaders.Add(MomoAPIDisbursementConfig!.TargetEnvironmentHeaderKeyName, MomoAPIDisbursementConfig!.TargetEnvironment);
            requestHeaders.Add(MomoAPIDisbursementConfig!.SubscriptionHeaderKeyName, MomoAPIDisbursementConfig!.PrimarySubscriptionKey);

            var response = await _apiAdaptor.ExecuteGetAsync(MomoAPIDisbursementConfig.AccountHolderBasicInfoEndPoint, requestHeaders, null, routeParams);

            return response.Content;
        }

        /// <summary>
        /// This method transfers funds.
        /// </summary>
        /// <param name="subscriptionType">The type of subscription (disbursement, collection, remittance)</param>
        /// <param name="amount">The amount to be transfered</param>
        /// <param name="currency">The type of currency to be used</param>
        /// <param name="externalId">The phone number of the receipient</param>
        /// <param name="partyId">The phone number of the account holder</param>
        /// <param name="paymentMsg">A message to be included in the transaction</param>
        /// <returns>Returns a status to show the success or failure of the funds transfer</returns>
        public async Task<string?> CreateTransfer(string partyIdType, decimal amount, string currency, string partyId, string externalId, string paymentMsg)
        {
            var xreferenceId = Guid.NewGuid();

            var requestHeaders = new Dictionary<string, string>
            {
                //Adding headers
                { MomoAPIDisbursementConfig!.ReferenceIdHeaderKeyName, xreferenceId.ToString() },
                { MomoAPIDisbursementConfig!.TargetEnvironmentHeaderKeyName, MomoAPIDisbursementConfig!.TargetEnvironment },
                { MomoAPIDisbursementConfig!.SubscriptionHeaderKeyName, MomoAPIDisbursementConfig!.PrimarySubscriptionKey }
            };

            //requestHeaders.Add("Authorization", $"Bearer {token}");
            //Prepare request body
            var requestJsonBody = new
            {
                amount,
                currency,
                externalId,
                payer = new { partyIdType, partyId },
                payerMessage = paymentMsg,
                payeeNote = paymentMsg
            };

            //make request
            var response = await _apiAdaptor.ExecutePostAsync(MomoAPIDisbursementConfig.TransferEndPoint, requestJsonBody, requestHeaders);

            return response.Content;
        }

        /// <summary>
        /// This method gets a transfer that was made based on the parameters supplied.
        /// </summary>
        /// <param name="subscriptionType">The type of subscription (disbursement, collection, remittance)</param>
        /// <param name="paymentXreferenceId">A UUID generated by user to track the payment provisioned resource</param>
        /// <param name="token">The access token used for auth in the API</param>
        /// <returns>Returns transfer details</returns>
        public async Task<string?> GetTransferStatus(string subscriptionType, string paymentXreferenceId, string token)
        {
            var routeParams = new Dictionary<string, string>();

            var requestHeaders = new Dictionary<string, string>();
            routeParams.Add(MomoAPIDisbursementConfig!.ReferenceIdHeaderKeyName, paymentXreferenceId);
            requestHeaders.Add(MomoAPIDisbursementConfig!.TargetEnvironmentHeaderKeyName, MomoAPIDisbursementConfig!.TargetEnvironment);
            requestHeaders.Add(MomoAPIDisbursementConfig!.SubscriptionHeaderKeyName, MomoAPIDisbursementConfig!.PrimarySubscriptionKey);

            var response = await _apiAdaptor.ExecuteGetAsync(MomoAPIDisbursementConfig.TransferStatusEndPoint, requestHeaders, null, routeParams);

            return response.Content;
        }
    }
}