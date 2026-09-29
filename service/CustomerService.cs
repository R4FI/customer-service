using CustomerSoapService.Contracts;
using CustomerSoapService.Data;
using CustomerSoapService.Models;
using MongoDB.Driver;
namespace CustomerSoapService.Services;

public class CustomerService : ICustomerService
{
    private readonly MongoDbContext db;
    public CustomerService(MongoDbContext db)
    {
        this.db = db;
    }
    public string AddCustomer(
    string fullName,
    string email,
    string phone,
    string address)
    {
        var allCustomers =
        db.Customers.Find(c => true).ToList();
        int nextId =
        allCustomers.Count == 0
        ? 1
        : allCustomers.Max(c => c.CustomerId) + 1;
        Customer customer = new()
        {
            CustomerId = nextId,
            FullName = fullName,
            Email = email,
            Phone = phone,
            Address = address
        };
        db.Customers.InsertOne(customer);
        return $"Customer added. ID = {nextId}";
    }
    public Customer GetCustomerById(int customerId)
    {
        return db.Customers
        .Find(c => c.CustomerId == customerId)
        .FirstOrDefault();
    }

    public List<Customer> GetAllCustomers()
    {
        return db.Customers
        .Find(c => true)
        .ToList();
    }
}