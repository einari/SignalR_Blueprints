using System.Collections.Generic;

namespace Chapter7.Accounts
{
    public delegate void AccountBalanceChanged(string accountNumber, decimal balance);

    public interface IAccountsOverview
    {
        IEnumerable<AccountOverview> GetAccountsOverview();
        void OnAccountBalanceChanged(AccountBalanceChanged callback);

        void Transfer(string from, string to, decimal amount);
    }
}
