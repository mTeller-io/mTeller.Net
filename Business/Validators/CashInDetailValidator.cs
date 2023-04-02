using Business.DTO;
using Common.Constant;
using FluentValidation;

namespace Business.Validators
{
    public class CashInDetailValidator : AbstractValidator<CashInDTO>
    {
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
            RuleFor(c => c.Currency).NotEmpty().Must(LocalCurrency);
            RuleFor(c => c.ExternalId).NotEmpty();
            RuleFor(c => c.Payer.PartyIdType).NotEmpty();

            // TODO: Add more rules
        }

        public static bool BeLenghtOfTen(string BranchNumber)
        {
            if (BranchNumber.Length < 10)
                return false;
            else
                return true;
        }

        public static bool LocalCurrency(string currency)
        {
            if (currency == nameof(Currency.EUR))
                return true;
            else
                return false;
        }

        public static bool GreaterThanZero(int value)
        {
            if (value > 0)
                return true;
            else
                return false;
        }
    }
}