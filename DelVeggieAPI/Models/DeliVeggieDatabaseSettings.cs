namespace DelVeggieAPI
{
    public interface IDeliVeggieDatabaseSettings
    {
        string VeggieCollectionName{get;set;}
        string PriceReductionsCollectionName {get; set;}
        string ConnectionString{get;set;}
        string DatabaseName{get;set;}
    }

        public class DeliVeggieDatabaseSettings:IDeliVeggieDatabaseSettings
    {
        public string VeggieCollectionName{get;set;}
        public string PriceReductionsCollectionName {get; set;}
        public string ConnectionString{get;set;}
        public string DatabaseName{get;set;}
    }
}