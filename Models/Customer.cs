using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Runtime.Serialization;
namespace CustomerSoapService.Models;
[DataContract]
public class Customer
{
[BsonId]
[BsonRepresentation(BsonType.ObjectId)]
[IgnoreDataMember]
public string? Id { get; set; }
[DataMember]
public int CustomerId { get; set; }
    [DataMember]

public string FullName { get; set; } = "";
[DataMember]
public string Email { get; set; } = "";
[DataMember]
public string Phone { get; set; } = "";
[DataMember]
public string Address { get; set; } = "";
}
