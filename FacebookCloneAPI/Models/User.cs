using MongoDB.Bson.Serialization.Attributes;
using System;
namespace FacebookCloneAPI.Models
{
    public class User
    {
        [BsonElement]
        public Guid Id { get; set; }

        [BsonElement]
        public string Username { get; set; }

        [BsonElement]
        public string Password { get; set; }

        [BsonElement]
        public string FirstName { get; set; }

        [BsonElement]
        public string LastName { get; set; }
    }
}
