using Grpc.Core;
using Grpc.Net.Client;
using GrpcService;

#if DEBUG
const string Host = "https://localhost";
const int Port = 7113;
#else
const string Host = "http://localhost";
const int Port = 5000;
#endif

var channel = GrpcChannel.ForAddress($"{Host}:{Port}");

// -- 簡單範例
//var client = new Greeter.GreeterClient(channel);

//string name = "Jed";
//var request = new HelloRequest { Name = name };

//var reply = await client.SayHelloAsync(request);

//Console.WriteLine($"Server replied: {reply.Message}");


// 自製 proto 範例
var client = new Customer.CustomerClient(channel);
var request = new CustomerLookupModel { UserId = 2 };

var reply = client.GetCustomerInfo(request);

Console.WriteLine($"Server replied: {reply.FisrtName} {reply.LastName}");

Console.WriteLine();
Console.WriteLine($"New Customer List");
Console.WriteLine();

using (var call = client.GetNewCustomers(new NewCustomerRequest()))
{
    while (await call.ResponseStream.MoveNext())
    {
        var customer = call.ResponseStream.Current;

        Console.WriteLine($"Server replied: {customer.FisrtName} {customer.LastName} {customer.EmailAddress}");
    }
}



channel.ShutdownAsync().Wait();
Console.WriteLine("Press any key to exit...");
Console.ReadKey();