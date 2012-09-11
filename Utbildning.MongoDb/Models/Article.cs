using System;
using MongoDB.Bson;

namespace Utbildning.MongoDb.Models
{
    public class Article
    {
        public ObjectId Id { get; set; }

        public string Header { get; set; }
        public string MainBody { get; set; }
        public DateTime? PublishedDate { get; set; }
    }
}
