using System.Collections.Generic;
using System.Windows.Input;
using PropertyChanged;
using Xamarin.Forms;

namespace Chapter8.Accounts
{
    [ImplementPropertyChanged]
    public class OverviewViewModel
    {
        public OverviewViewModel()
        {
            TransferCommand = new Command<AccountOverview>(Transfer);

            var accountsOverview = new AccountsOverview();
            Accounts = accountsOverview.GetAccountsOverview(a=>a.TransferCommand = TransferCommand);

            accountsOverview.OnAccountBalanceChanged((accountNumber, balance) =>
            {
                foreach (var accountOverview in Accounts)
                {
                    if (accountOverview.AccountNumber == accountNumber)
                    {
                        accountOverview.Balance = balance.ToString();
                    }
                }
            });
        }

        public IEnumerable<AccountOverview>    Accounts { get; private set; }

        public ICommand TransferCommand { get; private set; }

        public void Transfer(AccountOverview account)
        {
            var transfer = new Transfer();
            transfer.ViewModel.From = account.AccountNumber;
            App.Navigation.PushAsync(transfer);
        }
    }
}
