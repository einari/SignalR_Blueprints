using Web.Concepts.Accounts;

namespace Web.ValidationQueries
{
    public delegate bool have_sufficient_funds(AccountNumber accountNumber, decimal amount);
}