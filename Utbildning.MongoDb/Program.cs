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

            var server = MongoDB.Driver.MongoServer.Create("mongodb://localhost:27017/");
            var db =  server.GetDatabase("test");
            var collection = db.GetCollection<Article>("Article");

            collection.Drop();
            collection.Insert(new Article { Header = "header1", MainBody = "mainbody1", PublishedDate = new DateTime(2001, 1, 1) });
            collection.Insert(new Article { Header = "header2", MainBody = "mainbody2", PublishedDate = null });
            collection.Insert(new Article { Header = "header3", MainBody = "mainbody3" });

            foreach (var article in collection.FindAll())
            {
                Console.WriteLine(article.Header);
                Console.WriteLine(article.MainBody);
                Console.WriteLine(article.PublishedDate);
            }
            Console.Read();
            
        }
    }
}
