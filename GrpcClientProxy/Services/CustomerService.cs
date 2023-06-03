using Grpc.Core;
using GrpcService;
using static GrpcService.Customer;

namespace GrpcClientProxy.Services;

public class CustomerService : ICustomerService
{
    private readonly CustomerClient _client;

    public CustomerService(CustomerClient customerClient)
    {
        _client = customerClient;
    }

    public async Task<CustomerModel> GetCustomerInfoAsync(CustomerLookupModel request)
    {
        var result = await _client.GetCustomerInfoAsync(request);

        return result;
    }

    public async IAsyncEnumerable<CustomerModel> GetNewCustomers(NewCustomerRequest request)
    {
        using (var call = _client.GetNewCustomers(request))
        {
            while (await call.ResponseStream.MoveNext())
            {
                var customer = call.ResponseStream.Current;

                yield return customer;
            }
        }
    }

}
