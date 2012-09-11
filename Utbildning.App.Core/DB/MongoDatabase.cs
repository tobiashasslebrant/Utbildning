using System.Collections.Generic;

namespace Utbildning.App.Core.DB
{
    public class MongoDatabase<T> : IDatabase<T>
    {
        private readonly MongoDB.Driver.MongoDatabase _database;

        public MongoDatabase(string connectionString)
        {
            _database = MongoDB.Driver.MongoDatabase.Create(connectionString);
        }

        public IEnumerable<T> ReadAll(string collectionName)
        {
            return _database.GetCollection<T>(collectionName).FindAll();
        }

        public void DeleteAll(string collectionName)
        {
            _database.GetCollection(collectionName).RemoveAll();
        }

        public void Create(IEnumerable<T> documents, string collectionName)
        {
            _database.GetCollection(collectionName).InsertBatch(documents);
        }
    }
}