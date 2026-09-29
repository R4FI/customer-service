using CustomerSoapService.Models;
using System.ServiceModel;
namespace CustomerSoapService.Contracts;
[ServiceContract]
public interface ICustomerService
{
[OperationContract]
string AddCustomer(
string fullName,
string email,
string phone,
string address);
[OperationContract]
Customer GetCustomerById(int customerId);
[OperationContract]
List<Customer> GetAllCustomers();
}