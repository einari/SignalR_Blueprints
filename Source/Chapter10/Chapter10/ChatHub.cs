using System;
using Microsoft.AspNet.SignalR;

namespace Chapter10
{
    public class ChatHub : Hub
    {
        public void SendMessage(string message)
        {
            Console.WriteLine("Connection {0} : {1}",Context.ConnectionId, message);
            Clients.AllExcept(Context.ConnectionId).messageReceived(message);
        }
    }
}
