using Business.DTO;
using Platform.Interface;

namespace Platform.MoMo
{
    public class Disbursement
    {
        private readonly IMomoDisbursementAPIService _momoDisbursementAPIService;

        public Disbursement(IMomoDisbursementAPIService momoDisbursementAPIService)
        {
            _momoDisbursementAPIService = momoDisbursementAPIService;
        }

        public async Task<bool> Disburse(CashInDTO cashInDTO)
        {
            bool result;
            try
            {
                var isPartyIdActive = await _momoDisbursementAPIService.GetAccountHolderActiveStatus(cashInDTO.Payer.PartyId);

                await _momoDisbursementAPIService.CreateTransfer(cashInDTO.Payer.PartyIdType, cashInDTO.Amount, cashInDTO.Currency, cashInDTO.Payer.PartyId, cashInDTO.ExternalId, cashInDTO.PayerMessage);
                result = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }

            return result;
        }
    }
}