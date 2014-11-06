using System;
using Bifrost.Events;

namespace Web.Events.Accounts
{
    public class Credit : Event
    {
        public Credit(Guid eventSourceId) : base(eventSourceId) { }
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
    }
}