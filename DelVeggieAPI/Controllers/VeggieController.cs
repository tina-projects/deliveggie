using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using EasyNetQ;
using EasyNetQ.Topology;
using DelVeggieAPI.BusinessLayer;

namespace DelVeggieAPI.Controllers 
{
[ApiController]
[Route("[controller]")]
   public class VeggieController : ControllerBase
    {
        private readonly ILogger<VeggieController> _logger;
        private readonly IVeggieService _veggieService;

        public VeggieController(ILogger<VeggieController> logger, IVeggieService veggieService)
        {
            _logger = logger;
            _veggieService=veggieService;
        }

        [HttpGet]
        public IEnumerable<Veggie> Get()
        {
            var bus = RabbitHutch.CreateBus("host=192.168.99.100:5672,timeout=120").Advanced;
            var correlationId = Guid.NewGuid().ToString();
            var message = new Message<String>(correlationId);

            // Request Queue
            var queue = bus.QueueDeclare("veggie.request");
            var exchange = bus.ExchangeDeclare("Veggie.Exchange", ExchangeType.Direct);
            var binding = bus.Bind(exchange, queue, "veggie.request");
            bus.Publish(exchange, "veggie.request", false, message);

            // Read Response
            var responseQueue = bus.QueueDeclare(correlationId);
            bus.Consume<List<Veggie>>(responseQueue, (resp,info) =>{
                Console.WriteLine(resp.Body);
            });
            return new List<Veggie>();
   //         List<Veggie> veggieList = this._veggieService.GetVeggieList();
   //         return veggieList;
        }

        [HttpGet("{id:length(24)}")]
        public Veggie Get(string Id)
        {
            Veggie veggie =this._veggieService.GetVeggie(Id);
            return veggie;
        }
    }
}