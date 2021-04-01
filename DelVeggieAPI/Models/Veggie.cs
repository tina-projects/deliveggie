using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DelVeggieAPI
{
    public class Veggie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }
        public double Price{get;set;}
    }
}