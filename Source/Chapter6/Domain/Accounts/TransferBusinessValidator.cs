using Bifrost.FluentValidation.Commands;
using FluentValidation;
using Web.ValidationQueries;

namespace Web.Domain.Accounts
{
    public class TransferBusinessValidator : CommandBusinessValidator<Transfer>
    {
        public TransferBusinessValidator(be_a_valid_account be_a_valid_account, have_sufficient_funds have_sufficient_funds)
        {
            RuleFor(t => t.From)
                .Must(a => be_a_valid_account(a)).WithMessage("Invalid account");
            RuleFor(t => t.To)
                .Must(a => be_a_valid_account(a)).WithMessage("Invalid account");
            
            ModelRule()
                .Must(t => have_sufficient_funds(t.From, t.Amount)).WithMessage("Not enough funds");
        }
    }
}