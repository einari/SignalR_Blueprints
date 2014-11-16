using System.Linq;
using Bifrost.Read;
using Ninject;
using Ninject.Modules;
using Web.Concepts.Accounts;
using Web.Read.Accounts;
using Web.ValidationQueries;

namespace Web
{
    public class ValidationQueriesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<be_a_valid_account>().ToMethod(c => be_a_valid_account);
            Bind<have_sufficient_funds>().ToMethod(c => have_sufficient_funds);
        }

        bool have_sufficient_funds(AccountNumber accountNumber, decimal amount)
        {
            var repository = Kernel.Get<IReadModelRepositoryFor<AccountOverview>>();
            var account = repository.Query.Where(a => a.AccountNumber == accountNumber).Single();
            return account.Balance >= amount;
        }

        bool be_a_valid_account(AccountNumber accountNumber)
        {
            var repository = Kernel.Get<IReadModelRepositoryFor<AccountOverview>>();
            var accountExists = repository.Query.Any(a => a.AccountNumber == accountNumber);

            var ac = repository.Query.Where(a => a.AccountNumber == accountNumber);

            return accountExists;
        }

    }
}