using System.Collections.Generic;
using System.Windows.Input;
using Bifrost.Interaction;
using Bifrost.Messaging;
using PropertyChanged;

namespace Chapter7.Accounts
{
    [ImplementPropertyChanged]
    public class OverviewViewModel
    {
        IMessenger _messenger;
        public OverviewViewModel(IMessenger messenger, IAccountsOverview accountsOverview)
        {
            _messenger = messenger;
            Accounts = accountsOverview.GetAccountsOverview();

            accountsOverview.OnAccountBalanceChanged((accountNumber, balance) =>
            {
                foreach (var accountOverview in Accounts)
                {
                    if (accountOverview.AccountNumber == accountNumber)
                    {
                        accountOverview.Balance = balance;
                    }
                }

            });

            TransferCommand = DelegateCommand.Create<string>(Transfer);
        }

        public IEnumerable<AccountOverview> Accounts { get; private set; }

        public ICommand TransferCommand { get; private set; }

        public void Transfer(string accountNumber)
        {
            _messenger.Publish(new TransferMessage { AccountNumber = accountNumber });
        }
    }
}
