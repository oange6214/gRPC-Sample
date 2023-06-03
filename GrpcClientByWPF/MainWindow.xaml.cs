using GrpcClientProxy.Proxys;
using GrpcService;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace GrpcClientByWPF;

public partial class MainWindow : Window
{
    CustomerProxy customerProxy = new CustomerProxy();

    public MainWindow()
    {
        InitializeComponent();
    }

    private async void Request_Click(object sender, RoutedEventArgs e)
    {
        await foreach (var customer in customerProxy.GetNewCustomers(new NewCustomerRequest()))
        {
            tb.Text += $"Server replied: {customer.FirstName} {customer.LastName} {customer.EmailAddress}" + Environment.NewLine;
        }
    }

    private async Task<string> SingleRequest()
    {
        var request = new CustomerLookupModel { UserId = 1 };

        var reply = await customerProxy.GetCustomerInfoAsync(request);

        return $"Server replied: {reply.FirstName} {reply.LastName}";
    }
}
