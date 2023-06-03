using Grpc.Net.Client;
using GrpcClientProxy.Services;
using GrpcService;

namespace GrpcClientProxy.Proxys;

public class CustomerProxy : ICustomerService
{
    private readonly CustomerService _service;

    public CustomerProxy()
    {
        var channel = GrpcChannel.ForAddress("http://localhost:5120");
        var client = new Customer.CustomerClient(channel);
        _service = new CustomerService(client);

    }

    public async Task<CustomerModel> GetCustomerInfoAsync(CustomerLookupModel request)
    {
        var result = await _service.GetCustomerInfoAsync(request);

        return result;
    }

    public async IAsyncEnumerable<CustomerModel> GetNewCustomers(NewCustomerRequest request)
    {
        await foreach (var newCustomer in _service.GetNewCustomers(request))
        {
            yield return newCustomer;
        }
    }
}
