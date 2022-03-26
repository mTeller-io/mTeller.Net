using Business.DTO;
using DataAccess.Models;
using FluentValidation;
using System;

namespace Business
{
    public class CashInValidator : AbstractValidator<CashInDTO>
    {
        public CashInValidator()
        {
            RuleFor(c => c.CustomerName).NotEmpty().NotNull().WithMessage("Something went wrong");
            RuleFor(c => c.BranchMerchantNumber).NotEmpty().Must(BeLenghtOfTen);
            RuleFor(c => c.BranchMerchantNumberNetworkName).NotEmpty();
            RuleFor(c => c.CreateDateTime).LessThanOrEqualTo(System.DateTime.Now); //Not sure
            RuleFor(c => c.CreateUserName).NotEmpty();
            RuleFor(c => c.CustomerPhoneNumber).NotEmpty();
            RuleFor(c => c.DepositAmount).NotEmpty().GreaterThan(0.0);
            RuleFor(c => c.DepositorName).NotEmpty();
            RuleFor(c => c.DepositPhoneNumber).NotEmpty().Must(BeOnline);
            RuleFor(c => c.DepositPhoneNumberNetworkName).NotEmpty();
            RuleFor(c => c.History).NotEmpty();
            RuleFor(c => c.LastProcessName).NotEmpty();
            RuleFor(c => c.SendingCost).NotEmpty();
            RuleFor(c => c.TransactionDate).NotEmpty();
            RuleFor(c => c.TransactionType).NotEmpty(); //Not sure;

            // TODO: Add more rules
        }

        private bool BeOnline(string arg)
        {
            if (arg == string.Empty)
                return false;

            return true;
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
