using CustomerSoapService.Models;
using MongoDB.Driver;
namespace CustomerSoapService.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase database;
    public MongoDbContext(IConfiguration configuration)
    {
        var connectionString =
        configuration["MongoDb:ConnectionString"];
        var databaseName =
        configuration["MongoDb:DatabaseName"];
        MongoClient client =
        new MongoClient(connectionString);
        database =
        client.GetDatabase(databaseName);
    }
    public IMongoCollection<Customer> Customers =>
    database.GetCollection<Customer>("Customers");
}
