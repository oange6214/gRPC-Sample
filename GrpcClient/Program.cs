using GrpcClientProxy.Proxys;
using GrpcService;


CustomerProxy customerProxy = new CustomerProxy();


var request = new CustomerLookupModel { UserId = 2 };

var reply = await customerProxy.GetCustomerInfoAsync(request);

Console.WriteLine($"Server replied: {reply.FirstName} {reply.LastName}");

Console.WriteLine();
Console.WriteLine($"New Customer List");
Console.WriteLine();

await foreach (var customer in customerProxy.GetNewCustomers(new NewCustomerRequest()))
{
    Console.WriteLine($"Server replied: {customer.FirstName} {customer.LastName} {customer.EmailAddress}");
}

Console.WriteLine("Press any key to exit...");
Console.ReadKey();