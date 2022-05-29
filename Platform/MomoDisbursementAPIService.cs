using Business.Interface;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Platform.Model;
using Platform.Interface;

namespace Platform
{
    public class MomoDisbursementAPIService:IMomoDisbursementAPIService
    {
        private readonly IAPIAdapter _apiAdaptor;
    
        private readonly IConfiguration _configuration;
      
        public MomoAPIDisbursementConfig? _momoAPIDisbursementConfig { get; private set; }
      
        public MomoDisbursementAPIService(IConfiguration configuration )
        {
            _configuration = configuration;

             _momoAPIDisbursementConfig = _configuration.GetSection(MomoAPIDisbursementConfig.ConfigKey)
                                                     .Get<MomoAPIDisbursementConfig>();
            
            
            RestClient _restClient = new RestClient(_momoAPIDisbursementConfig.BaseUrl);

            _apiAdaptor = new APIAdapter(_momoAPIDisbursementConfig.APIUser,
            _momoAPIDisbursementConfig.APIKey,_momoAPIDisbursementConfig.BaseUrl,_restClient);

        }

        /// <summary>
        /// This method gets the auth token
        /// </summary>
        /// <param name="subscriptionType">The type of subscription (disbursement, collection, remittance)</param>
        /// <returns>Returns an auth token</returns>
        public string GenerateToken(string subscriptionType)
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
        public async Task<string> GetAccountBalance(string subscriptionType, string token)
        {
             var response = new RestResponse();
             //prepare  headers
              var  requestHeaders = new Dictionary<string,string>();
           
            requestHeaders.Add(_momoAPIDisbursementConfig!.TargetEnvironmentHeaderKeyName, _momoAPIDisbursementConfig!.TargetEnvironment);
            requestHeaders.Add(_momoAPIDisbursementConfig!.SubscriptionHeaderKeyName, _momoAPIDisbursementConfig!.PrimarySubscriptionKey);
            
             response = await _apiAdaptor.ExecuteGetAsync(_momoAPIDisbursementConfig.AccountBalanceEndPoint,requestHeaders,null,null);
           
            return  response.ToString();
          
        }

        /// <summary>
        /// This method gets the account holders active status
        /// </summary>
        /// <param name="partyID">The customer number or Id</param>
        /// <returns>Returns the status of the momo account which holds a subscription</returns>
        public async Task<string> GetAccountHolderActiveStatus( string partyID)
        {
           
            var response = new RestResponse();

              var  routeParams = new Dictionary<string,string>();
             var requestHeaders = new Dictionary<string,string>();
            routeParams.Add(_momoAPIDisbursementConfig!.AccountHolderIdHeaderKeyName,partyID);
            requestHeaders.Add(_momoAPIDisbursementConfig!.TargetEnvironmentHeaderKeyName, _momoAPIDisbursementConfig!.TargetEnvironment);
            requestHeaders.Add(_momoAPIDisbursementConfig!.SubscriptionHeaderKeyName, _momoAPIDisbursementConfig!.PrimarySubscriptionKey);
            
             response = await _apiAdaptor.ExecuteGetAsync(_momoAPIDisbursementConfig.AccountHolderActiveStatusEndPoint,requestHeaders,null,routeParams);
           
            return response.ToString();
           
        }

        /// <summary>
        /// Makes a call to get the account holders basic information
        /// </summary>
        /// <param name="partyID">The phone number of the account holder</param>
        /// <returns>Returns the account holders basic information</returns>
        public async Task<string> GetAccountHolderBaseInfo(string subscriptionType, string partyID, string token)
        {
            
             var response = new RestResponse();
             var  routeParams = new Dictionary<string,string>();
             var requestHeaders = new Dictionary<string,string>();
            routeParams.Add(_momoAPIDisbursementConfig!.AccountHolderIdHeaderKeyName,partyID);
            requestHeaders.Add(_momoAPIDisbursementConfig!.TargetEnvironmentHeaderKeyName, _momoAPIDisbursementConfig!.TargetEnvironment);
            requestHeaders.Add(_momoAPIDisbursementConfig!.SubscriptionHeaderKeyName, _momoAPIDisbursementConfig!.PrimarySubscriptionKey);
            
             response = await _apiAdaptor.ExecuteGetAsync(_momoAPIDisbursementConfig.AccountHolderBasicInfoEndPoint,requestHeaders,null,routeParams);
           
            return response.ToString();
           
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
        public async Task<string> CreateTransfer(string partyIdType, decimal amount, string currency, string partyId, string externalId, string paymentMsg)
        {
           
             var response = new RestResponse();
             var xreferenceId =  Guid.NewGuid();
            
            var  requestHeaders = new Dictionary<string,string>();
            //Adding headers
            requestHeaders.Add(_momoAPIDisbursementConfig!.ReferenceIdHeaderKeyName,xreferenceId.ToString());
            requestHeaders.Add(_momoAPIDisbursementConfig!.TargetEnvironmentHeaderKeyName, _momoAPIDisbursementConfig!.TargetEnvironment);
            requestHeaders.Add(_momoAPIDisbursementConfig!.SubscriptionHeaderKeyName, _momoAPIDisbursementConfig!.PrimarySubscriptionKey);
            
            //requestHeaders.Add("Authorization", $"Bearer {token}");
            //Prepare request body
            var requestJsonBody = new {
                amount=amount,currency=currency,externalId=externalId,
            payer= new {partyIdType=partyIdType,partyId=partyId},payerMessage=paymentMsg,payeeNote=paymentMsg};
    
            //make request
             response = await _apiAdaptor.ExecutePostAsync(_momoAPIDisbursementConfig.TransferEndPoint,requestJsonBody,requestHeaders);
           
            return response.ToString();  
        }

        /// <summary>
        /// This method gets a transfer that was made based on the parameters supplied.
        /// </summary>
        /// <param name="subscriptionType">The type of subscription (disbursement, collection, remittance)</param>
        /// <param name="paymentXreferenceId">A UUID generated by user to track the payment provisioned resource</param>
        /// <param name="token">The access token used for auth in the API</param>
        /// <returns>Returns transfer details</returns>
        public async Task<string> GetTransferStatus(string subscriptionType, string paymentXreferenceId, string token)
        {
          
              var response = new RestResponse();

              var routeParams = new Dictionary<string,string>();

              var  requestHeaders = new Dictionary<string,string>();
            routeParams.Add(_momoAPIDisbursementConfig!.ReferenceIdHeaderKeyName,paymentXreferenceId);
            requestHeaders.Add(_momoAPIDisbursementConfig!.TargetEnvironmentHeaderKeyName, _momoAPIDisbursementConfig!.TargetEnvironment);
            requestHeaders.Add(_momoAPIDisbursementConfig!.SubscriptionHeaderKeyName, _momoAPIDisbursementConfig!.PrimarySubscriptionKey);
            
        
             response = await _apiAdaptor.ExecuteGetAsync(_momoAPIDisbursementConfig.TransferStatusEndPoint,requestHeaders,null,routeParams);
           
            return response.ToString();
          
        }
    }
    
}