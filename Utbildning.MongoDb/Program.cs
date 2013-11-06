using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Options;
using Utbildning.MongoDb.Models;

namespace Utbildning.MongoDb
{
    class Program
    {
        static void Main(string[] args)
        {
           DateTimeSerializationOptions.Defaults = new DateTimeSerializationOptions(DateTimeKind.Local, BsonType.Document);
            var server = MongoDB.Driver.MongoServer.Create("mongodb://127.0.0.1");
            var db = server.GetDatabase("Utbildning");

            var collection = db.GetCollection<Article>("Articles");
            collection.Insert(new Article() {Header = "my new Article"});
            
            Console.Read();
            
        }
    }
}
