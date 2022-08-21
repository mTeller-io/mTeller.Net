namespace Platform.Model
{
    public class CashInPayload
    {
       
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string ExternalId { get; set; }
        public Payer Payer { get; set; }
        public string PayerMessage { get; set; }
        public string PayeeNote { get; set; }
       
       
    }

    public class Payer
    {
        public string PartyIdType { get; set; }
        public string PartyId { get; set; }
    }
    
}