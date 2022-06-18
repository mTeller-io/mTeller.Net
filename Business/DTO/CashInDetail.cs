namespace Business.DTO.Del
{
    public class CashInDetail
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string ExternalId { get; set; }
        public Payer Payer { get; set; }
        public string PayerMessage { get; set; }
        public string PayeeNote { get; set; }
        public string Provider { get; set; }
        public string PayerName { get; set; }
        public string UserName { get; set; }
        public string BranchCode { get; set; }
        public string BranchAccountNumber { get; set; }
        public string DepositorName { get; set; }
        public string DepositorContactNo { get; set; }
    }

    public class Payer
    {
        public string PartyIdType { get; set; }
        public string PartyId { get; set; }
    }
}