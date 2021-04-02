using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace DelVeggieAPI.BusinessLayer
{
    public class PriceReductionsService:IPriceReductionsService
    {
        private readonly ILogger<PriceReductionsService> _logger;
        private readonly IMongoCollection<PriceReductions> _priceReductions;
        private List<PriceReductions> _reductionList;

        public PriceReductionsService(ILogger<PriceReductionsService> logger, IDeliVeggieDatabaseSettings settings)
        {
            _logger = logger;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _priceReductions = database.GetCollection<PriceReductions>(settings.PriceReductionsCollectionName);
            Console.WriteLine("Getting PriceReductions");
            _reductionList = _priceReductions.Find(priceReductions =>true).ToList();
        }

        public double GetPriceReduction()
        {
            if (_reductionList ==null) {
                Console.WriteLine("Getting PriceReductions as it is null");
                _reductionList =  _priceReductions.Find(priceReductions =>true).ToList();
            }
            int dayOfWeek = (int)DateTime.Today.DayOfWeek + 1;
            PriceReductions reduction = _reductionList.Where(priceReduction => priceReduction.DayOfWeek == dayOfWeek).FirstOrDefault();
            return reduction.Reduction;
        }
    }
}