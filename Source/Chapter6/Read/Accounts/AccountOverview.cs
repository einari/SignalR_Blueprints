using System;
using Bifrost.Read;
using Bifrost.Views;
using Web.Concepts.Accounts;

namespace Web.Read.Accounts
{
    public class AccountOverview : IReadModel, IHaveId
    {
        public Guid Id { get; set; }
        public AccountNumber AccountNumber { get; set; }
        public decimal Balance { get; set; }
    }
}