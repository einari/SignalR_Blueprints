using Web.Concepts.Accounts;

namespace Web.ClientEvents
{
    public delegate void AccountBalanceChanged(AccountNumber accountNumber, decimal balance);
}