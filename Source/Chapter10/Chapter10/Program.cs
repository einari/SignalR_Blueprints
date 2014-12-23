using System;
using Microsoft.Owin.Hosting;

namespace Chapter10
{
    class Program
    {
        static void Main(string[] args)
        {
            using( WebApp.Start<Startup>("http://localhost:8181"))
            {
                Console.WriteLine("Server running at http://localhost:8181/");
                Console.ReadLine();
            }
        }
    }
}
