namespace Platform.Model
{
    public class CashInPayload
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; } = String.Empty;
        public string ExternalId { get; set; }
        public Payer Payer { get; set; }
        public string PayerMessage { get; set; } = String.Empty;
        public string PayeeNote { get; set; } = String.Empty;

        public CashInPayload()
        {
            this.Payer = new Payer();
            this.ExternalId = String.Empty;
        }
    }

    public class Payer
    {
        public string PartyIdType { get; set; } = String.Empty;
        public string PartyId { get; set; } = String.Empty;
    }
}