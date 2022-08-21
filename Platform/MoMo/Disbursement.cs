using Platform.Model;
using Platform.Interface;

namespace Platform.MoMo
{
    public class Disbursement : IDisbursement
    {
        private readonly IMomoDisbursementAPIService _momoDisbursementAPIService;

        public Disbursement(IMomoDisbursementAPIService momoDisbursementAPIService)
        {
            this._momoDisbursementAPIService = momoDisbursementAPIService;
        }

        public async Task<bool> Disburse(CashInPayload cashInPayload)
        {
            var result = false;
            try
            {
                var isPartyIdActive = await _momoDisbursementAPIService.GetAccountHolderActiveStatus(cashInPayload.Payer.PartyId);
              
               if(isPartyIdActive)
               {
                 await _momoDisbursementAPIService.CreateTransfer(cashInPayload.Payer.PartyIdType, cashInPayload.Amount, cashInPayload.Currency, cashInPayload.Payer.PartyId, cashInPayload.ExternalId, cashInPayload.PayerMessage);
                 result = true;

               }
               else{
                 result=false;
               }
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }

            return result;
        }
    }
}