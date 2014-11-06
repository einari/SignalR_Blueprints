using System.Linq;
using Bifrost.Entities;
using Bifrost.Events;
using Web.ClientEvents;
using Web.Events.Accounts;

namespace Web.Read.Accounts
{
    public class EventSubscribers : IProcessEvents
    {
        IEntityContext<AccountOverview> _entityContext;
        AccountBalanceChanged _accountBalanceChanged;

        public EventSubscribers(IEntityContext<AccountOverview> entityContext, AccountBalanceChanged accountBalanceChanged)
        {
            _entityContext = entityContext;
            _accountBalanceChanged = accountBalanceChanged;
        }

        public void Process(Credit @event)
        {
            var accountOverview = _entityContext.Entities.Where(a => a.AccountNumber == @event.AccountNumber).Single();
            accountOverview.Balance -= @event.Amount;
            _entityContext.Save(accountOverview);

            _accountBalanceChanged(accountOverview.AccountNumber, accountOverview.Balance);
        }

        public void Process(Debit @event)
        {
            var accountOverview = _entityContext.Entities.Where(a => a.AccountNumber == @event.AccountNumber).Single();
            accountOverview.Balance += @event.Amount;
            _entityContext.Save(accountOverview);

            _accountBalanceChanged(accountOverview.AccountNumber, accountOverview.Balance);
        }
    }
}