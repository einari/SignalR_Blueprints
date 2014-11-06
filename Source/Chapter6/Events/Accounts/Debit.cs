using System;
using Bifrost.Events;

namespace Web.Events.Accounts
{
    public class Debit : Event
    {
        public Debit(Guid eventSourceId) : base(eventSourceId) { }
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
    }
}