namespace Business
{
    /*  public class MomoAPI : IMomoAPI
    {
        private readonly string endpoint = string.Empty;
        private readonly string subscriptionKey = string.Empty;
        private readonly IConfiguration _configuration;
        private readonly string xreferenceId = string.Empty;

        public MomoAPI(IConfiguration configuration)
        {
            _configuration = configuration;
            xreferenceId = "";
            subscriptionKey = "13a7c5277f7c470593bfe9edbc915679";
            endpoint = "https://sandbox.momodeveloper.mtn.com";
        }

        /// <summary>
        /// This method gets the API User
        /// </summary>
        /// <returns>Returns an API User</returns>
        public string GetAPIUser()
        {
            var client = new RestClient($"{endpoint}/v1_0/apiuser/{xreferenceId}")
            {
                Timeout = -1
            };
            var request = new RestRequest(Method.GET);
            request.AddHeader("Ocp-Apim-Subscription-Key", subscriptionKey);
            IRestResponse response = client.Execute(request);

            return response.Content;
        }

        /// <summary>
        /// This method creates the API user
        /// </summary>
        /// <returns>Returns an API User</returns>
        public string CreateAPIUSer()
        {
            var client = new RestClient($"{endpoint}/v1_0/apiuser")
            {
                Timeout = -1
            };
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Ocp-Apim-Subscription-Key", subscriptionKey);
            request.AddHeader("X-Reference-Id", xreferenceId);
            var body = @"{" + "\n" +
            @"  ""providerCallbackHost"": ""callbacks-do-not-work-in-sandbox.com""" + "\n" +
            @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        /// <summary>
        /// This method creates the API Key
        /// </summary>
        /// <returns>Returns an API Key</returns>
        public string CreateAPIKey()
        {
            var client = new RestClient($"{endpoint}/v1_0/apiuser/{xreferenceId}/apikey")
            {
                Timeout = -1
            };
            var request = new RestRequest(Method.POST);
            request.AddHeader("Ocp-Apim-Subscription-Key", subscriptionKey);
            var body = @"";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return response.Content;
        }

        /// <summary>
        /// This method gets the auth token
        /// </summary>
        /// <param name="subscriptionType">The type of subscription (disbursement, collection, remittance)</param>
        /// <returns>Returns an auth token</returns>
        public string GenerateToken(string subscriptionType)
        {
            var client = new RestClient($"{endpoint}/{subscriptionType}/token/")
            {
                Timeout = -1
            };
            var request = new RestRequest(Method.POST);
            request.AddHeader("Ocp-Apim-Subscription-Key", subscriptionKey);
            request.AddHeader("Authorization", "Basic N2YyZjllY2UtMjNlZC00OWRlLWFiNDgtYmNhODY3M2M0NDAzOjkwZmExYjc0MjI5YjRjYmZhNjQ1ODg0M2MzZjBiZWRk");
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        /// <summary>
        /// This method send a request for payment to the API
        /// </summary>
        /// <param name="token">The access token used for auth in the API</param>
        /// <param name="amount">The amount of money the user wishes to request</param>
        /// <param name="currency">The type of currency to be use (EUR only in API mode)</param>
        /// <param name="externalId">The phone number of the receipient</param>
        /// <param name="partyId">The phone number of the account holder</param>
        /// <param name="paymentMsg">Any additional comment the user wishes to input</param>
        /// <returns>Returns a request to pay provisioning response</returns>
        public string CreateRequestToPay(string token, string amount, string currency, string externalId, string partyId, string paymentMsg)
        {
            var client = new RestClient($"{endpoint}/collection/v1_0/requesttopayttopay")
            {
                Timeout = -1
            };
            var request = new RestRequest(Method.POST);
            request.AddHeader("X-Reference-Id", xreferenceId);
            request.AddHeader("X-Target-Environment", "sandbox");
            request.AddHeader("Ocp-Apim-Subscription-Key", subscriptionKey);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddHeader("Content-Type", "application/json");
            var body = @"{" + "\n" +
            @$"  ""amount"": ""{amount}""," + "\n" +
            @$"  ""currency"": ""{currency}""," + "\n" +
            @$"  ""externalId"": ""{externalId}""," + "\n" +
            @"  ""payer"": {" + "\n" +
            @"    ""partyIdType"": ""{{accountHolderIdTypeCaseUp}}""," + "\n" +
            @$"    ""partyId"": ""{partyId}""" + "\n" +
            @"  }," + "\n" +
            @$"  ""payerMessage"": ""{paymentMsg}""," + "\n" +
            @$"  ""payeeNote"": ""{paymentMsg}""" + "\n" +
            @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="paymentXreferenceId">A UUID generated by user to track the payment provisioned resource</param>
        /// <param name="token">The access token used for auth in the API</param>
        /// <returns>Returns a request to pay data</returns>
        public string GetRequestToPay(string paymentXreferenceId, string token)
        {
            var client = new RestClient($"{endpoint}/collection/v1_0/requesttopay/{paymentXreferenceId}")
            {
                Timeout = -1
            };
            var request = new RestRequest(Method.GET);
            request.AddHeader("X-Target-Environment", "sandbox");
            request.AddHeader("Ocp-Apim-Subscription-Key", subscriptionKey);
            request.AddHeader("Authorization", $"Bearer {token}");
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        /// <summary>
        /// This method gets the account balance
        /// </summary>
        /// <param name="subscriptionType">The type of subscription (disbursement, collection, remittance)</param>
        /// <param name="token">The access token used for auth in the API</param>
        /// <returns>Returns the account balance</returns>
        public string GetAccountBalance(string subscriptionType, string token)
        {
            var client = new RestClient($"{endpoint}/{subscriptionType}/v1_0/account/balance")
            {
                Timeout = -1
            };
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddHeader("X-Target-Environment", "sandbox");
            request.AddHeader("Ocp-Apim-Subscription-Key", subscriptionKey);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        /// <summary>
        /// This method gets the account holders active status
        /// </summary>
        /// <param name="subscriptionType">The type of subscription (disbursement, collection, remittance)</param>
        /// <param name="partyID">The customer number or Id</param>
        /// <param name="token">The access token used for auth in the API</param>
        /// <returns>Returns the status of the momo account which holds a subscription</returns>
        public string GetAccountHolderActiveStatus(string subscriptionType, string partyID, string token)
        {
            var client = new RestClient($"{endpoint}/{subscriptionType}/v1_0/accountholder/{{accountHolderIdTypeCaseDown}}/{partyID}/active")
            {
                Timeout = -1
            };
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddHeader("X-Target-Environment", "sandbox");
            request.AddHeader("Ocp-Apim-Subscription-Key", subscriptionKey);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        /// <summary>
        /// Makes a call to get the account holders basic information
        /// </summary>
        /// <param name="subscriptionType">The type of subscription (disbursement, collection, remittance)</param>
        /// <param name="partyID">The phone number of the account holder</param>
        /// <param name="token">The access token used for auth in the API</param>
        /// <returns>Returns the account holders basic information</returns>
        public string GetAccountHolderBaseInfo(string subscriptionType, string partyID, string token)
        {
            var client = new RestClient($"{endpoint}/{subscriptionType}/v1_0/accountholder/msisdn/{partyID}/basicuserinfo")
            {
                Timeout = -1
            };
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddHeader("X-Target-Environment", "sandbox");
            request.AddHeader("Ocp-Apim-Subscription-Key", subscriptionKey);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        /// <summary>
        /// This method transfers funds.
        /// </summary>
        /// <param name="subscriptionType">The type of subscription (disbursement, collection, remittance)</param>
        /// <param name="token">The access token used for auth in the API</param>
        /// <param name="amount">The amount to be transfered</param>
        /// <param name="currency">The type of currency to be used</param>
        /// <param name="externalId">The phone number of the receipient</param>
        /// <param name="partyId">The phone number of the account holder</param>
        /// <param name="paymentMsg">A message to be included in the transaction</param>
        /// <returns>Returns a status to show the success or failure of the funds transfer</returns>
        public string CreateTransfer(string subscriptionType, string token, string amount, string currency, string partyId, string externalId, string paymentMsg)
        {
            var client = new RestClient($"{endpoint}/{subscriptionType}/v1_0/transfer")
            {
                Timeout = -1
            };
            var request = new RestRequest(Method.POST);
            request.AddHeader("X-Reference-Id", xreferenceId);
            request.AddHeader("X-Target-Environment", "sandbox");
            request.AddHeader("Ocp-Apim-Subscription-Key", subscriptionKey);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddHeader("Content-Type", "application/json");
            var body = @"{" + "\n" +
            @$"  ""amount"": ""{amount}""," + "\n" +
            @$"  ""currency"": ""{currency}""," + "\n" +
            @$"  ""externalId"": ""{externalId}""," + "\n" +
            @"  ""payee"": {" + "\n" +
            @"    ""partyIdType"": ""{{accountHolderIdTypeCaseUp}}""," + "\n" +
            @$"    ""partyId"": ""{partyId}""" + "\n" +
            @"  }," + "\n" +
            @"  ""payerMessage"": ""Test transfer""," + "\n" +
            @"  ""payeeNote"": ""Test transfer""" + "\n" +
            @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        /// <summary>
        /// This method gets a transfer that was made based on the parameters supplied.
        /// </summary>
        /// <param name="subscriptionType">The type of subscription (disbursement, collection, remittance)</param>
        /// <param name="paymentXreferenceId">A UUID generated by user to track the payment provisioned resource</param>
        /// <param name="token">The access token used for auth in the API</param>
        /// <returns>Returns transfer details</returns>
        public string GetTransfer(string subscriptionType, string paymentXreferenceId, string token)
        {
            var client = new RestClient($"{endpoint}/{subscriptionType}/v1_0/transfer/{paymentXreferenceId}")
            {
                Timeout = -1
            };
            var request = new RestRequest(Method.GET);
            request.AddHeader("X-Target-Environment", "sandbox");
            request.AddHeader("Ocp-Apim-Subscription-Key", subscriptionKey);
            request.AddHeader("Authorization", $"Bearer {token}");
            IRestResponse response = client.Execute(request);
            return response.Content;
        }
    }*/
}