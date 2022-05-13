using MongoDB.Bson.Serialization.Attributes;
using System;

namespace FacebookCloneApi.Models
{
    public class PostInfo
    {
        [BsonElement("id")]
        public Guid Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }


        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("date")]
        public DateTime Date { get; set; }
    }
}
