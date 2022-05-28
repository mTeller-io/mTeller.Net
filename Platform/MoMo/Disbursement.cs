using System;
using Platform.Interface;
using Business.DTO;

namespace Platform.MoMo
{
    
    public class Disbursement
    {
       readonly IMomoDisbursementAPIService _momoDisbursementAPIService;

        public Disbursement(IMomoDisbursementAPIService momoDisbursementAPIService )
        {
           
           this._momoDisbursementAPIService=momoDisbursementAPIService;

        }
        
        public async Task<bool> Disburse(CashInDTO cashInDTO)
        {
           var result = false;
           try 
           {
              var isPartyIdActive= await _momoDisbursementAPIService.GetAccountHolderActiveStatus(cashInDTO.Payer.PartyId);
           
                await _momoDisbursementAPIService.CreateTransfer(cashInDTO.Payer.PartyIdType,cashInDTO.Amount,cashInDTO.Currency,cashInDTO.Payer.PartyId,cashInDTO.ExternalId,cashInDTO.PayerMessage);
                result=true;
           }
           catch(Exception ex)
           {
                throw new Exception(ex.StackTrace);
           }
           
            return result;

        }
        


    }
}