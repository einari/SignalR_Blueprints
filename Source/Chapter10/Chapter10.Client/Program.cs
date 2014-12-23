using System;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Transports;

namespace Chapter10.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var hubConnection = new HubConnection("http://localhost:8181");
            var hubProxy = hubConnection.CreateHubProxy("ChatHub");
            hubProxy.On("messageReceived", (string message) =>
            {
                Console.WriteLine(message);
            });

            hubConnection.Start().ContinueWith(t=>Console.WriteLine("Connected")).Wait();
            
            for (; ; )
            {
                var line = Console.ReadLine();
                if (line == "q")
                {
                    break;
                }
                hubProxy.Invoke("SendMessage", line);
            }
        }
    }
}
