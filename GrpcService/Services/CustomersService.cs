using Grpc.Core;

namespace GrpcService.Services;

public class CustomersService : Customer.CustomerBase
{

    private readonly ILogger<CustomersService> _logger;

    public CustomersService(ILogger<CustomersService> logger)
    {
        _logger = logger;
    }

    public override Task<CustomerModel> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
    {
        CustomerModel output = new CustomerModel();

        switch (request.UserId)
        {
            case 1:
                output.FirstName = "Jamie";
                output.LastName = "Smith";
                break;
            case 2:
                output.FirstName = "Jane";
                output.LastName = "Doe";
                break;
            default:
                output.FirstName = "Greg";
                output.LastName = "Thomas";
                break;
        }

        return Task.FromResult(output);
    }

    public override async Task GetNewCustomers(NewCustomerRequest request, IServerStreamWriter<CustomerModel> responseStream, ServerCallContext context)
    {
        List<CustomerModel> customers = new List<CustomerModel>
        {
            new CustomerModel
            {
                FirstName = "Tim",
                LastName = "Leo",
                EmailAddress = "Tim@gmail.com",
                Age = 41,
                IsAlive = true
            },
            new CustomerModel
            {
                FirstName = "Sue",
                LastName = "Storm",
                EmailAddress = "Sue@gmail.com",
                Age = 31,
                IsAlive = true
            },
            new CustomerModel
            {
                FirstName = "Bill",
                LastName = "Lin",
                EmailAddress = "Bill@gmail.com",
                Age = 35,
                IsAlive = false
            },
        };

        foreach(var customer in customers)
        {
            await Task.Delay(500);
            await responseStream.WriteAsync(customer);
        }
    }

}
