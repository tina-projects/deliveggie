using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
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
            List<Veggie> veggieList = this._veggieService.GetVeggieList();

            return veggieList;
        }

        [HttpGet("{id:length(24)}")]
        public Veggie Get(string Id)
        {
            Veggie veggie =this._veggieService.GetVeggie(Id);
            return veggie;
        }
    }
}