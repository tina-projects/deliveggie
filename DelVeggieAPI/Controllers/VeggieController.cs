using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using EasyNetQ;
using EasyNetQ.Topology;
using Newtonsoft.Json;

namespace DelVeggieAPI.Controllers 
{
[ApiController]
[Route("[controller]")]
   public class VeggieController : ControllerBase
    {
        private readonly ILogger<VeggieController> _logger;

        public VeggieController(ILogger<VeggieController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Veggie>> Get()
        {
            bool isMessageReturned = false;
            List<Veggie> veggieList = new List<Veggie>();
            var bus = RabbitHutch.CreateBus("host=rabbitmq:5672,timeout=120").Advanced;
            var correlationId = Guid.NewGuid().ToString();
            var message = new Message<String>(correlationId);

            // Request Queue
            var queue = bus.QueueDeclare("veggie.request");
            var exchange = bus.ExchangeDeclare("Veggie.Exchange", ExchangeType.Direct);
            var binding = bus.Bind(exchange, queue, "veggie.request");
            bus.Publish(exchange, "veggie.request", false, message);

            // Read Response
            var responseQueue = bus.QueueDeclare(correlationId);
            bus.Consume<string>(responseQueue, (resp,info) =>{
                try
                {
                    veggieList = JsonConvert.DeserializeObject<List<Veggie>>(resp.Body);
                }
                catch (System.Exception e)
                {
                    
                    Console.WriteLine(e);
                }
                isMessageReturned = true;
                Console.WriteLine("Message Returned");
            });

            while (!isMessageReturned)
            {
                Console.WriteLine("Waiting for message return");
                await Task.Delay(50);
            }
            return veggieList;
        }

        [HttpGet("{id:length(24)}")]
        public async Task<Veggie> Get(string Id)
        {
            bool isMessageReturned = false;
            Veggie veggie = new Veggie();
            var bus = RabbitHutch.CreateBus("host=rabbitmq:5672,timeout=120").Advanced;
            var correlationId = Guid.NewGuid().ToString();
            var message = new Message<String>(correlationId + "," + Id);

            // Request Queue
            var queue = bus.QueueDeclare("veggieDetails.request");
            var exchange = bus.ExchangeDeclare("Veggie.Exchange", ExchangeType.Direct);
            var binding = bus.Bind(exchange, queue, "veggieDetails.request");
            bus.Publish(exchange, "veggieDetails.request", false, message);

            // Read Response
            var responseQueue = bus.QueueDeclare(correlationId);
            bus.Consume<string>(responseQueue, (resp,info) =>{
                try
                {
                    veggie = JsonConvert.DeserializeObject<Veggie>(resp.Body);
                }
                catch (System.Exception e)
                {
                    
                    Console.WriteLine(e);
                }
                isMessageReturned = true;
                Console.WriteLine("Message Returned");
            });

            while (!isMessageReturned)
            {
                Console.WriteLine("Waiting for message return");
                await Task.Delay(50);
            }
            return veggie;
        }
    }
}