using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Bifrost.Execution;
using Microsoft.AspNet.SignalR.Client;

namespace Chapter7
{
    public class AccountsOverview : IAccountsOverview
    {
        IHubProxy _proxy;
        IDispatcher _dispatcher;

        List<AccountBalanceChanged> _accountBalanceChangedCallbacks;

        public AccountsOverview(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
            _accountBalanceChangedCallbacks = new List<AccountBalanceChanged>();

            var hubConnection = new HubConnection("http://localhost:9044/");

            _proxy = hubConnection.CreateHubProxy("OverviewHub");
            _proxy.On("accountBalanceChanged", (string accountNumber, decimal amount) =>
            {
                _dispatcher.BeginInvoke(() =>
                {
                    foreach (var callback in _accountBalanceChangedCallbacks)
                    {
                        callback(accountNumber, amount);
                    }
                });
            });

            hubConnection.Start().Wait();
        }

        public IEnumerable<AccountOverview> GetAccountsOverview()
        {
            var accounts = new ObservableCollection<AccountOverview>();
            _proxy.Invoke<IEnumerable<AccountOverview>>("GetAccountsOverview").ContinueWith(t =>
            {
                foreach (var accountOverview in t.Result)
                {
                    _dispatcher.BeginInvoke(() => accounts.Add(accountOverview));
                }
            });
            return accounts;
        }

        

        public void OnAccountBalanceChanged(AccountBalanceChanged callback)
        {
            _accountBalanceChangedCallbacks.Add(callback);
            
        }


        public void Transfer(string from, string to, decimal amount)
        {
            _proxy.Invoke("Transfer", from, to, amount);
        }
    }
}
