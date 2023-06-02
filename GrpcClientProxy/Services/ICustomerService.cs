using GrpcService;

namespace GrpcClientProxy.Services;

public interface ICustomerService
{
    Task<CustomerModel> AddAsync(CustomerLookupModel request);
}
