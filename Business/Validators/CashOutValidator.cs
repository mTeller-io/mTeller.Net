using Business.DTO;
using FluentValidation;
using System;

namespace Business
{
    public class CashOutValidator : AbstractValidator<CashOutDTO>
    {
        public CashOutValidator()
        {
            RuleFor(c => c.CustomerName).NotEmpty();
            RuleFor(c => c.BranchMerchantNumber).NotEmpty();
            RuleFor(c => c.Amount).GreaterThan(0.0).NotEmpty();
            RuleFor(c => c.ChargeAmount).GreaterThan(0.0).NotEmpty();
            RuleFor(c => c.ChargeRate).NotEmpty();
            RuleFor(c => c.CreateDateTime).LessThanOrEqualTo(DateTime.Now).NotEmpty();
            RuleFor(c => c.CreateUserName).NotEmpty();
            RuleFor(c => c.CustomerName).NotEmpty();
            RuleFor(c => c.CustomerPhoneNumber).NotEmpty();
            RuleFor(c => c.History).NotEmpty();
            RuleFor(c => c.LastProcessName).NotEmpty();
            RuleFor(c => c.ModifyDateTime).LessThanOrEqualTo(DateTime.Now).NotEmpty();
            RuleFor(c => c.ModifyUserName).NotEmpty();
            RuleFor(c => c.PrevStatus).NotEmpty();
            RuleFor(c => c.Status).NotEmpty();
            RuleFor(c => c.TransactionDate).NotEmpty();
            RuleFor(c => c.TransactionType).NotEmpty();
            RuleFor(c => c.WithdrawerName).NotEmpty();
            RuleFor(c => c.WithdrawerNetworkName).NotEmpty();
            RuleFor(c => c.WithdrawerPhoneNumber).NotEmpty();
        }
    }
}