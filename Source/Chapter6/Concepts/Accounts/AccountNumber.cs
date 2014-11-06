using Bifrost.Concepts;

namespace Web.Concepts.Accounts
{
    public class AccountNumber : ConceptAs<string>
    {
        public static implicit operator AccountNumber (string value)
        {
            return new AccountNumber { Value = value };
        }
    }
}