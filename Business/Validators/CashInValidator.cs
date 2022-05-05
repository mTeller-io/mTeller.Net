using DataAccess.Models;
using FluentValidation;
using Business.DTO;

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
            RuleFor(c => c.DepositorName).NotEmpty();
            RuleFor(c => c.BranchAccountNumber).NotEmpty().Must(BeLenghtOfTen);
            RuleFor(c => c.BranchAccountNetworkName).NotEmpty();
            RuleFor(c => c.CreateDateTime).LessThanOrEqualTo(System.DateTime.Now); //Not sure
            RuleFor(c => c.CreateUserName).NotEmpty();
            RuleFor(c => c.DepositorContactNo).NotEmpty();
            RuleFor(c => c.Amount).NotEmpty().Must(GreaterThanZero);
            RuleFor(c => c.AccountName).NotEmpty();
            RuleFor(c => c.AccountNumber).NotEmpty();
            RuleFor(c => c.AccountNetworkName).NotEmpty();
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

        public bool GreaterThanZero(decimal value)
        {
            if (value<0)
                return false;
            else
                return true;
        } 
    }
}
