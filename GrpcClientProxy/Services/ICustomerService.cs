using GrpcService;

namespace GrpcClientProxy.Services;

public interface ICustomerService
{
    Task<CustomerModel> GetCustomerInfoAsync(CustomerLookupModel request);
    IAsyncEnumerable<CustomerModel> GetNewCustomers(NewCustomerRequest request);
}
