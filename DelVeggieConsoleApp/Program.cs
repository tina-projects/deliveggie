using System;
using System.Collections.Generic;
using EasyNetQ;
using EasyNetQ.Topology;
using Newtonsoft.Json;
using  DelVeggieConsoleApp.BusinessLayer;

namespace DelVeggieConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Veggie Queue Starting...");
            var connected = false;
            IAdvancedBus bus = null;
            while (!connected)
            {
                try
                {
                    if (bus == null) 
                    {
                        bus = RabbitHutch.CreateBus("host=rabbitmq:5672, timeout=120").Advanced;
                    }
                    var testQueue = bus.QueueDeclare("veggie.test");
                    connected = true;
                    Console.WriteLine("Connected to Test Queue");
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Could not connect to queue. Retrying...");
                }
            }

            //VeggieList Queue
            var queue = bus.QueueDeclare("veggie.request");
            bus.Consume<String>(queue, (resp,info) =>{
                var correlationId = resp.Body;

                var queue = bus.QueueDeclare(correlationId);
                var exchange = bus.ExchangeDeclare("Veggie.Exchange", ExchangeType.Direct);
                var binding = bus.Bind(exchange, queue, correlationId);

                var veggieList = getVeggies();
                var veggieJson = JsonConvert.SerializeObject(veggieList);

                var message = new Message<String>(veggieJson);

                bus.Publish(exchange, correlationId, false, message);
            });

            //VeggieDetails Queue
            var detailsQueue = bus.QueueDeclare("veggieDetails.request");
            bus.Consume<String>(detailsQueue, (resp,info) =>{
                var message = resp.Body;
                string[] messages = message.Split(",");
                var correlationId = messages[0];
                var id = messages[1];

                var detailsQueue = bus.QueueDeclare(correlationId);
                var exchange = bus.ExchangeDeclare("Veggie.Exchange", ExchangeType.Direct);
                var binding = bus.Bind(exchange, detailsQueue, correlationId);

                var veggie = getVeggieDetails(id);
                var veggieJson = JsonConvert.SerializeObject(veggie);

                var responseMessage = new Message<String>(veggieJson);

                bus.Publish(exchange, correlationId, false, responseMessage);
            });
            Console.ReadLine();
        }

        private static List<Veggie> getVeggies()
        {
            PriceReductionsService prs = new PriceReductionsService();
            double priceReduction = prs.GetPriceReduction();

            VeggieService vs = new VeggieService();
            List<Veggie> veggieList = vs.GetVeggieList(0.25);
            Console.WriteLine(veggieList);
            return veggieList;
        }

        private static Veggie getVeggieDetails(string id)
        {
            PriceReductionsService prs = new PriceReductionsService();
            double priceReduction = prs.GetPriceReduction();

            VeggieService vs = new VeggieService();
            Veggie veggie = vs.GetVeggie(id, 0.25);
            Console.WriteLine(veggie);
            return veggie;
        }
    }
}
