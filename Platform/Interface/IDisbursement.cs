using Platform.Model;

namespace Platform.Interface
{
    public interface IDisbursement
    {
        Task<bool> Disburse(CashInPayload cashInPayload);
    }
}