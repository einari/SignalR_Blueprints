using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Transports;
using Xamarin.Forms;

namespace Chapter8.Accounts
{
    public delegate void AccountBalanceChanged(string accountNumber, decimal balance);

    public class AccountsOverview
    {
        IHubProxy _proxy;

        List<AccountBalanceChanged> _accountBalanceChangedCallbacks;

        public AccountsOverview()
        {
            _accountBalanceChangedCallbacks = new List<AccountBalanceChanged>();

            var hubConnection = new HubConnection("http://10.0.1.38:9044/");

            _proxy = hubConnection.CreateHubProxy("OverviewHub");
            _proxy.On("accountBalanceChanged", (string accountNumber, decimal amount) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    foreach (var callback in _accountBalanceChangedCallbacks)
                    {
                        callback(accountNumber, amount);
                    }
                });
            });

            hubConnection.Start(new LongPollingTransport()).Wait();
        }

        public IEnumerable<AccountOverview> GetAccountsOverview(Action<AccountOverview> itemCallback)
        {
            var accounts = new ObservableCollection<AccountOverview>();
            _proxy.Invoke<IEnumerable<AccountOverview>>("GetAccountsOverview").ContinueWith(t =>
            {
                foreach (var accountOverview in t.Result)
                {
                    Device.BeginInvokeOnMainThread(() => {
                        itemCallback(accountOverview);
                        accounts.Add(accountOverview);
                    });
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
