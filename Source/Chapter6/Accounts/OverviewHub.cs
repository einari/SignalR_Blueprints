using System.Collections.Generic;
using Bifrost.Commands;
using Microsoft.AspNet.SignalR;
using Web.Domain.Accounts;
using Web.Read.Accounts;

namespace Web.Accounts
{
    public class OverviewHub : Hub
    {
        AccountsOverview _accountsOverview;
        ICommandCoordinator _commandCoordinator;
        public OverviewHub(AccountsOverview accountsOverview, ICommandCoordinator commandCoordinator)
        {
            _accountsOverview = accountsOverview;
            _commandCoordinator = commandCoordinator;
        }

        public IEnumerable<AccountOverview> GetAccountsOverview()
        {
            return _accountsOverview.Query;
        }

        public void Transfer(string from, string to, decimal amount)
        {
            var command = new Transfer
            {
                From = from,
                To = to,
                Amount = amount
            };
            _commandCoordinator.Handle(command);
        }
    }
}