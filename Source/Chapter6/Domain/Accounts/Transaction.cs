using System;
using Bifrost.Domain;
using Web.Concepts.Accounts;
using Web.Events.Accounts;

namespace Web.Domain.Accounts
{
    public class Transaction : AggregateRoot
    {
        public Transaction(Guid id) : base(id) { }

        public void Transfer(AccountNumber from, AccountNumber to, decimal amount)
        {
            Apply(new Credit(Id) { AccountNumber = from, Amount = amount });
            Apply(new Debit(Id) { AccountNumber = to, Amount = amount });
        }
    }
}