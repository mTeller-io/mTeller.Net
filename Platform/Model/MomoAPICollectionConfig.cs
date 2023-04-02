namespace Platform.Model
{
    public class MomoAPICollectionConfig
    {
        public const string ConfigKey = "MomoAPI:Collection";
        public string PrimarySubscriptionKey { get; set; } = String.Empty;
        public string SecondarySubscriptionKey { get; set; } = String.Empty;
        public string BaseUrl { get; set; } = String.Empty;
        public string APIUser { get; set; } = String.Empty;
        public string APIKey { get; set; } = String.Empty;
        public string TokenEndpoint { get; set; } = String.Empty;
        public string RequestToPayEndPoint { get; set; } = String.Empty;
        public string RequestToPayStatusEndPoint { get; set; } = String.Empty;
        public string AccountHolderActiveStatusEndPoint { get; set; } = String.Empty;
        public string AccountHolderBasicInfoEndPoint { get; set; } = String.Empty;
        public string AccountHolderIdHeaderKeyName { get; set; } = string.Empty;
        public string AccountBalanceEndPoint { get; set; } = String.Empty;
        public string TargetEnvironment { get; set; } = String.Empty;
        public string ReferenceIdHeaderKeyName { get; set; } = String.Empty;
        public string TargetEnvironmentHeaderKeyName { get; set; } = string.Empty;
        public string SubscriptionHeaderKeyName { get; set; } = String.Empty;
    }
}