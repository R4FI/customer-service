using CustomerSoapService.Contracts;
using CustomerSoapService.Data;
using CustomerSoapService.Services;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddScoped<MongoDbContext>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

var app = builder.Build();

// Configure SOAP endpoint
app.UseSoapEndpoint<ICustomerService>(
    "/soap",
    new SoapEncoderOptions());

app.MapGet("/", () => "SOAP Service is running. WSDL: http://localhost:5139/soap?wsdl");

app.Run();
