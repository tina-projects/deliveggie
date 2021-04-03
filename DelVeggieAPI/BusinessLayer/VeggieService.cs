using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace DelVeggieAPI.BusinessLayer
{
    public class VeggieService:IVeggieService
    {
        private readonly ILogger<VeggieService> _logger;
        private readonly IMongoCollection<Veggie> _veggie;
        private readonly IPriceReductionsService _priceReductionService;

        public VeggieService(ILogger<VeggieService> logger, IDeliVeggieDatabaseSettings settings, 
                                                        IPriceReductionsService priceReductionService)
        {
            _logger = logger;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _veggie = database.GetCollection<Veggie>(settings.VeggieCollectionName);
            _priceReductionService = priceReductionService;
        }

        public List<Veggie> GetVeggieList()
        {
            double priceReduction = _priceReductionService.GetPriceReduction();
            List<Veggie> veggieList = _veggie.Find(veggie =>true).ToList();
            veggieList.ForEach(v => v.Price = v.Price * priceReduction);
            return veggieList;
        }

        public Veggie GetVeggie(string id)
        {
            double priceReduction= _priceReductionService.GetPriceReduction();
            Veggie veggie = _veggie.Find(veggie => veggie.Id == id).FirstOrDefault();
            veggie.Price = veggie.Price * priceReduction;
            return veggie;
        }
    }
}