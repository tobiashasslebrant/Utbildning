using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Driver;
using Utbildning.MongoDb.Models;

namespace Utbildning.MongoDb
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTimeSerializationOptions.Defaults = new DateTimeSerializationOptions(DateTimeKind.Local, BsonType.Document);

            var server = MongoDB.Driver.MongoServer.Create("mongodb://172.16.125.33:27017");
            server.DropDatabase("leif");
            var adminDatabase = server.GetDatabase("admin");
            adminDatabase.RunCommand("copyDatabase('master_api_hittavard','leif')");

           
            


            Console.Read();
            
        }
    }
}
