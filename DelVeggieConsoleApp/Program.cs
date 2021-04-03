using System;
using System.Collections.Generic;
using EasyNetQ;

namespace DelVeggieConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var bus = RabbitHutch.CreateBus("host=192.168.99.100:5672");
            bus.Rpc.Respond<int, int>(request => 5);
            Console.ReadLine(); 
        }
    }
}
