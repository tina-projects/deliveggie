using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using DelVeggieConsoleApp.DAL;

namespace DelVeggieConsoleApp.BusinessLayer
{
    public class VeggieService
    {
        private readonly IMongoCollection<Veggie> _veggie;

        public VeggieService()
        {
            var client = DbConnection.GetInstance().GetDbClient();
            var database = client.GetDatabase("DeliVeggie");
            _veggie = database.GetCollection<Veggie>("Veggie");
        }

        public List<Veggie> GetVeggieList(double priceReduction)
        {
            List<Veggie> veggieList = _veggie.Find(veggie =>true).ToList();
            veggieList.ForEach(v => v.Price = v.Price * priceReduction);
            return veggieList;
        }

        public Veggie GetVeggie(string id, double priceReduction)
        {
            Veggie veggie = _veggie.Find(veggie => veggie.Id == id).FirstOrDefault();
            veggie.Price = veggie.Price * priceReduction;
            return veggie;
        }
    }
}