using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chapter7
{
    public delegate void AccountBalanceChanged(string accountNumber, decimal balance);

    public interface IAccountsOverview
    {
        IEnumerable<AccountOverview> GetAccountsOverview();
        void OnAccountBalanceChanged(AccountBalanceChanged callback);

        void Transfer(string from, string to, decimal amount);
    }
}
