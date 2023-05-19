using Grpc.Core;
using Grpc.Net.Client;
using GrpcService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace GrpcClientByWPF;

public partial class MainWindow : Window
{
#if DEBUG
    const string Host = "https://localhost";
    const int Port = 7113;
#else
const string Host = "http://localhost";
const int Port = 5000;
#endif

    GrpcChannel channel;
    //Greeter.GreeterClient client;

    Customer.CustomerClient client;

    public MainWindow()
    {
        InitializeComponent();

        channel = GrpcChannel.ForAddress($"{Host}:{Port}");
        //client = new Greeter.GreeterClient(channel);
        client = new Customer.CustomerClient(channel);
    }

    private async void Request_Click(object sender, RoutedEventArgs e)
    {
        var items = await MultiRequest();

        foreach ( var item in items )
        {
            tb.Text += item + Environment.NewLine;
        }
    }

    private void ShutDown_Click(object sender, RoutedEventArgs e)
    {
        channel.ShutdownAsync().Wait();
    }

    private async Task<List<string>> MultiRequest()
    {
        var request = new CustomerLookupModel { UserId = 1 };

        var customerList = new List<string>();

        using (var call = client.GetNewCustomers(new NewCustomerRequest()))
        {
            while (await call.ResponseStream.MoveNext())
            {
                var customer = call.ResponseStream.Current;

                var result = $"Server replied: {customer.FirstName} {customer.LastName} {customer.EmailAddress}";

                customerList.Add(result);
            }
        }

        return customerList;
    }

    private async Task<string> SingleRequest()
    {
        var request = new CustomerLookupModel { UserId = 1 };

        var reply = await client.GetCustomerInfoAsync(request);

        return $"Server replied: {reply.FirstName} {reply.LastName}";
    }

    //private async Task<string> Request()
    //{
    //    string name = "Jed";
    //    var request = new HelloRequest { Name = name };

    //    var reply = await client.SayHelloAsync(request);

    //    return $"Server replied: {reply.Message}";
    //}
}
