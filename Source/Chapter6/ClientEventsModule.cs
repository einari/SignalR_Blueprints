using Microsoft.AspNet.SignalR;
using Ninject.Modules;
using Web.Accounts;
using Web.ClientEvents;
using Web.Concepts.Accounts;

namespace Web
{
    public class ClientEventsModule : NinjectModule
    {

        public override void Load()
        {
            Bind<AccountBalanceChanged>().ToMethod(c=>AccountBalanceChanged);
        }

        void AccountBalanceChanged(AccountNumber accountNumber, decimal balance)
        {
            GlobalHost.ConnectionManager.GetHubContext<OverviewHub>().Clients.All.accountBalanceChanged(accountNumber, balance);
        }
    }
}