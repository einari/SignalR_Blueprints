using System;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR;

namespace Chapter4
{
    public class RequestStatisticsHub : Hub
    {
        static Dictionary<string, int> _requestsLog = new Dictionary<string, int>();
        static Dictionary<string, int> _failedRequestsLog = new Dictionary<string, int>();

        public Dictionary<string, int> GetRequests()
        {
            return _requestsLog;
        }

        public Dictionary<string, int> GetFailedRequests()
        {
            return _failedRequestsLog;
        }

        static void Register(Dictionary<string, int> log, Action<dynamic, string, int> hubCallback)
        {
            var now = DateTime.Now.RoundToNearest(TimeSpan.FromMinutes(15));
            var key = now.ToString("HH:mm");

            if (log.ContainsKey(key))
                log[key] = log[key] + 1;
            else
                log[key] = 1;

            var hub = GlobalHost.ConnectionManager.GetHubContext<RequestStatisticsHub>();
            hubCallback(hub.Clients.All, key, log[key]);
        }

        public static void Request()
        {
            Register(_requestsLog, (hub, key, value) => hub.requestCountChanged(key, value));
        }

        public static void FailedRequest()
        {
            Register(_requestsLog, (hub, key, value) => hub.failedRequestCountChanged(key, value));
        }

    }
}