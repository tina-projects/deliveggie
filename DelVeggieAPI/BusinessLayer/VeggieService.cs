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

        public VeggieService(ILogger<VeggieService> logger, IDeliVeggieDatabaseSettings settings)
        {
            _logger = logger;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _veggie = database.GetCollection<Veggie>(settings.VeggieCollectionName);
        }

        public List<Veggie> GetVeggieList()
        {
            return _veggie.Find(veggie =>true).ToList();
        }

        public Veggie GetVeggie(string id)
        {
            return _veggie.Find(veggie => veggie.Id == id).FirstOrDefault();
        }
    }
}