using System;
using Bifrost.Read;
using Web.Read.Accounts;

namespace Web
{
    public class Defaults
    {
        IReadModelRepositoryFor<AccountOverview> _repository;

        public Defaults(IReadModelRepositoryFor<AccountOverview> repository)
        {
            _repository = repository;
        }

        public void Setup()
        {
            _repository.Insert(new AccountOverview
            {
                Id = Guid.NewGuid(),
                AccountNumber = "123456",
                Balance = 1000
            });

            _repository.Insert(new AccountOverview
            {
                Id = Guid.NewGuid(),
                AccountNumber = "654321",
                Balance = 5000
            });
        }
    }
}