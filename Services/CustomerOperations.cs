using CSharpTrainingCamp601.Entities;
using MongoDB.Bson;

namespace CSharpTrainingCamp601.Services
{
    public class CustomerOperations
    {
        public void AddCustomer(Customer customer)
        {
            var connection = new MongoDbConnection();
            var customerCollection = connection.GetCustomersCollection();

            var document = new BsonDocument
            {
                {"CustomerName", customer.CustomerName },
                {"CustomerSurname", customer.CustomerSurname },
                {"CustomerCity", customer.CustomerCity },
                {"Balance", customer.Balance },
                {"TotalShopping", customer.TotalShopping },
            };

            customerCollection.InsertOne(document);
        }
    }
}
