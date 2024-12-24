using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CSharpTrainingCamp601.Entities
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerCity { get; set; }
        public decimal Balance { get; set; }
        public int TotalShopping { get; set; }
    }
}
