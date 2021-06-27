using DataAccess;
using FluentValidation;

namespace Business
{
    public class CashOutValidator : AbstractValidator<CashOut>
    {
        private static CashOutValidator _instance = null;

        public static CashOutValidator GetInstance
        {
            get
            {
                if (_instance == null) _instance = new CashOutValidator();
                return _instance;
            }
        }
        public CashOutValidator()
        {
            RuleFor(c => c.CustomerName).NotEmpty();
            RuleFor(c => c.BranchMerchantNumber).NotEmpty();

            // TODO: Add more rules
        }
    }
}
