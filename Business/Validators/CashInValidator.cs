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
            RuleFor(c => c.BranchMerchantNumber).NotEmpty().Must(BeLenghtOfTen);
            RuleFor(c => c.BranchMerchantNumberNetworkName).NotEmpty();
            RuleFor(c => c.CreateDateTime).LessThanOrEqualTo(System.DateTime.Now); //Not sure
            RuleFor(c => c.CreateUserName).NotEmpty();
            RuleFor(c => c.CustomerPhoneNumber).NotEmpty();
            RuleFor(c => c.DepositAmount).NotEmpty().GreaterThan(0.0);
            RuleFor(c => c.DepositorName).NotEmpty();
            RuleFor(c => c.DepositPhoneNumber).NotEmpty();
            RuleFor(c => c.DepositPhoneNumberNetworkName).NotEmpty();
            RuleFor(c => c.History).NotEmpty();
            RuleFor(c => c.LastProcessName).NotEmpty();
            RuleFor(c => c.SendingCost).NotEmpty();
            RuleFor(c => c.TransactionDate).NotEmpty();
            RuleFor(c => c.TransactionType).NotEmpty(); //Not sure;

            // TODO: Add more rules
        }

        public bool BeLenghtOfTen(string BranchNumber)
        {
            if (BranchNumber.Length < 10)
                return false;
            else
                return true;
        } 
    }
}
