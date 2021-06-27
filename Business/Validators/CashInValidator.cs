using DataAccess;
using FluentValidation;

namespace Business
{
    public class CashInValidator : AbstractValidator<CashIn>
    {
        private static CashInValidator _instance = null;

        public static CashInValidator GetInstance
        {
            get
            {
                if (_instance == null) _instance = new CashInValidator();
                return _instance;
            }
        }
        public CashInValidator()
        {
            RuleFor(c => c.CustomerName).NotEmpty();
            RuleFor(c => c.BranchMerchantNumber).NotEmpty();

            // TODO: Add more rules
        }
    }
}
