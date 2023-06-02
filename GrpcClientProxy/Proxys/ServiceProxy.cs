using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcClientProxy.Proxys;

internal class ServiceProxy
{
}


//using ClientProxy.Service;
//using Grpc.Net.Client;
//using GrpcServer;

//namespace ClientProxy.Proxy;

//public class CalculatorServiceProxy : ICalculatorService
//{
//    private readonly CalculatorService _service;

//    public CalculatorServiceProxy()
//    {
//        var channel = GrpcChannel.ForAddress("http://localhost:5254");
//        var client = new Calculator.CalculatorClient(channel);
//        _service = new CalculatorService(client);
//    }

//    public async Task<AddResponse> AddAsync(AddRequest request)
//    {
//        return await _service.AddAsync(request);
//    }
//}
