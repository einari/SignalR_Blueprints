using System;
using Bifrost.Events;

namespace Web.Events.Accounts
{
    public class Credited : Event
    {
        public Credited(Guid eventSourceId) : base(eventSourceId) { }
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
    }
}