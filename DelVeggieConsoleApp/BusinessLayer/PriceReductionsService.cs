using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using DelVeggieConsoleApp.DAL;

namespace DelVeggieConsoleApp.BusinessLayer
{
    public class PriceReductionsService
    {
        private readonly IMongoCollection<PriceReductions> _priceReductions;
        private List<PriceReductions> _reductionList;

        public PriceReductionsService()
        {
            var client = DbConnection.GetInstance().GetDbClient();
            var database = client.GetDatabase("DeliVeggie");
            _priceReductions = database.GetCollection<PriceReductions>("PriceReductions");
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