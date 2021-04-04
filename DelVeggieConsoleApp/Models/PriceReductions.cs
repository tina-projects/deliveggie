using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DelVeggieConsoleApp
{
    public class PriceReductions
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int DayOfWeek { get; set; }
        public double Reduction { get; set; }
    }
}