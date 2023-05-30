using MediatR;
using Serilog;
namespace RD.Core.Common.Behaviours;
public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly ILogger _logger;

    public UnhandledExceptionBehaviour(ILogger logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> requestHandlerDelegate)
    {
        try
        {
            return await requestHandlerDelegate();
        }
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;

            _logger.Error(ex, "RD Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);

            throw;
        }
    }

    Task<TResponse> IPipelineBehavior<TRequest, TResponse>.Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}