namespace GrpcService.Services;

//public class CalculatorService : Calculator.CalculatorBase
//{
//    private readonly ILogger<CalculatorService> _logger;
//    private readonly TransformBlock<AddRequest, AddResponse> _transformBlock;

//    public CalculatorService(ILogger<CalculatorService> logger)
//    {
//        _logger = logger;

//        _transformBlock = new TransformBlock<AddRequest, AddResponse>(async request =>
//        {
//            _logger.LogInformation($"[Client][{request.Threadid}] Guid: {request.Guid}, X: {request.X}, Y: {request.Y}");

//            await Task.Delay(2000);

//            // Do your computation here and return the result
//            var result = new AddResponse
//            {
//                Guid = request.Guid,
//                Threadid = request.Threadid,
//                Result = request.X + request.Y
//            };

//            return result;
//        });
//    }

//    public override async Task<AddResponse> SayHello2(AddRequest request, ServerCallContext context)
//    {
//        await _transformBlock.SendAsync(request);

//        var response = await _transformBlock.ReceiveAsync();

//        return response;
//    }

//}