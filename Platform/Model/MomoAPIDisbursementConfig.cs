namespace Platform.Model
{
    public class MomoAPIDisbursementConfig
    {
        public const string ConfigKey = "MomoAPI:Disbursement";
        public string PrimarySubscriptionKey { get; set; } = String.Empty;
        public string SecondarySubscriptionKey { get; set; } = String.Empty;
        public string BaseUrl { get; set; } = String.Empty;
        public string APIUser { get; set; } = String.Empty;
        public string APIKey { get; set; } = String.Empty;
        public string TokenEndpoint { get; set; } = String.Empty;
        public string TransferEndPoint { get; set; } = String.Empty;
        public string TransferStatusEndPoint { get; set; } = string.Empty;
        public string AccountHolderActiveStatusEndPoint { get; set; } = String.Empty;
        public string AccountHolderIdKeyName { get; set; } = string.Empty;
        public string AccountHolderIdTypeKeyName { get; set; } = string.Empty;
        public string AccountBalanceEndPoint { get; set; } = String.Empty;
        public string AccountHolderBasicInfoEndPoint { get; set; } = string.Empty;
        public string TargetEnvironment { get; set; } = String.Empty;
        public string ReferenceIdHeaderKeyName { get; set; } = String.Empty;
        public string TargetEnvironmentHeaderKeyName { get; set; } = string.Empty;
        public string SubscriptionHeaderKeyName { get; set; } = String.Empty;
        public string ContentTypeHeaderKeyName { get; set; } = String.Empty;
        public string JsonContentType { get; set; } = String.Empty;
    }
}