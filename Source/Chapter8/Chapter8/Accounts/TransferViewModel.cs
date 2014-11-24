using System.ComponentModel;
using System.Windows.Input;
using PropertyChanged;
using Xamarin.Forms;

namespace Chapter8.Accounts
{
    [ImplementPropertyChanged]
    public class TransferViewModel
    {
        AccountsOverview _accountsOverview;

        public TransferViewModel()
        {
            TransferCommand = new Command(Transfer);
            _accountsOverview = new AccountsOverview();
        }

        public string From { get; set; }
        public string To { get; set; }
        public string Amount { get; set; }

        public ICommand TransferCommand { get; private set; }

        void Transfer()
        {
            decimal amount = 0;
            decimal.TryParse(Amount, out amount);
            _accountsOverview.Transfer(From, To, amount);

            From = string.Empty;
            To = string.Empty;
            Amount = "0";

            App.Navigation.PopAsync();
        }
    }
}
