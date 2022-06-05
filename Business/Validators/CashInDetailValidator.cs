using Business.DTO;
using Common.Constant;
using FluentValidation;

namespace Business.Validators
{
    public class CashInDetailValidator : AbstractValidator<CashInDTO>
    {
        private static CashInDetailValidator _instance = null;

        public static CashInDetailValidator GetInstance
        {
            get
            {
                if (_instance == null) _instance = new CashInDetailValidator();
                return _instance;
            }
        }

        public CashInDetailValidator()
        {
            RuleFor(c => c.DepositorName).NotEmpty();
            RuleFor(c => c.BranchAccountNumber).NotEmpty().Must(BeLenghtOfTen);
            RuleFor(c => c.Provider).NotEmpty();
            RuleFor(c => c.UserName).NotEmpty();
            RuleFor(c => c.DepositorContactNo).NotEmpty();//.Must(BeLenghtOfTen);
            RuleFor(c => c.Amount).NotEmpty();//.Must(GreaterThanZero);
            RuleFor(c => c.PayerName).NotEmpty();
            RuleFor(c => c.Payer.PartyId).NotEmpty().Must(BeLenghtOfTen);
            RuleFor(c => c.Currency).NotEmpty().Must(localCurrency);
            RuleFor(c => c.ExternalId).NotEmpty();
            RuleFor(c => c.Payer.PartyIdType).NotEmpty();

            // TODO: Add more rules
        }

        public bool BeLenghtOfTen(string BranchNumber)
        {
            if (BranchNumber.Length < 10)
                return false;
            else
                return true;
        }

        public bool localCurrency(string currency)
        {
            if (currency == nameof(Currency.GHS))
                return true;
            else
                return false;
        }

        public bool GreaterThanZero(int value)
        {
            if (value > 0)
                return true;
            else
                return false;
        }

        // public bool GreaterThan(this decimal amount,decimal value)=>amount>value;
    }
}