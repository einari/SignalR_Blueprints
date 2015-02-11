using Bifrost.FluentValidation.Commands;
using FluentValidation;

namespace Web.Domain.Accounts
{
    public class TransferInputValidator : CommandInputValidator<Transfer>
    {
        public TransferInputValidator()
        {
            RuleFor(t => (string)t.From)
                .NotEmpty().WithMessage("You must specify account")
                .Length(6).WithMessage("Account must have 6 digits");
            RuleFor(t => (string)t.To)
                .NotEmpty().WithMessage("You must specify account")
                .Length(6).WithMessage("Account must have 6 digits");
            RuleFor(t => t.Amount)
                .NotEmpty().WithMessage("You must specify an amount")
                .GreaterThan(0).WithMessage("Amount must be more than 0");
        }
    }
}