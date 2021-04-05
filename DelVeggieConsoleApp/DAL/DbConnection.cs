using MongoDB.Driver;

namespace DelVeggieConsoleApp.DAL
{
    class DbConnection
    {
        private static MongoClient _mongoClient;

        private static readonly DbConnection _dbConnection = new DbConnection();

        private DbConnection()
        {
            _mongoClient = new MongoClient("mongodb://localhost:27017");
        }

        public static DbConnection GetInstance() => _dbConnection;

        public MongoClient GetDbClient() => _mongoClient;
    }
}