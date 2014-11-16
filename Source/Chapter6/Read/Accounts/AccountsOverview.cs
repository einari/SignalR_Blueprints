using System.Linq;
using Bifrost.Read;

namespace Web.Read.Accounts
{
    public class AccountsOverview : IQueryFor<AccountOverview>
    {
        IReadModelRepositoryFor<AccountOverview> _repository;

        public AccountsOverview(IReadModelRepositoryFor<AccountOverview> repository)
        {
            _repository = repository;
        }

        public IQueryable<AccountOverview>  Query
        {
            get
            {
                return _repository.Query;
            }
        }
    }
}