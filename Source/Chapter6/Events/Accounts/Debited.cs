using System;
using Bifrost.Events;

namespace Web.Events.Accounts
{
    public class Debited : Event
    {
        public Debited(Guid eventSourceId) : base(eventSourceId) { }
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
    }
}