using Bifrost.Commands;
using Web.Concepts.Accounts;

namespace Web.Domain.Accounts
{
    public class Transfer : Command
    {
        public AccountNumber From { get; set; }
        public AccountNumber To { get; set; }
        public decimal Amount { get; set; }
    }
}