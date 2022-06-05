namespace Platform.Interface
{
    public interface IMomoApiCashIn
    {
        bool CashIn();

        bool RequestToPay();

        bool CheckActiveNumber();
    }
}