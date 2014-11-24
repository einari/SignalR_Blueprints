using System;
using System.Windows.Input;
using PropertyChanged;

namespace Chapter8.Accounts
{
    [ImplementPropertyChanged]
    public class AccountOverview
    {
        public Guid Id { get; set; }
        public string AccountNumber { get; set; }
        public string Balance { get; set; }

        public ICommand TransferCommand { get; set; }
    }
}
