using Microsoft.Extensions.Logging;

namespace BebraTemplate.Application.Common.Behaviours;

public class UnhandledExceptionBehaviour<TRequest, TResponse>(ILogger<TRequest> logger) : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull {
    private readonly ILogger<TRequest> logger = logger;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken) {
        try {
            return await next();
        }
        catch (Exception ex) {
            var requestName = typeof(TRequest).Name;

            logger.LogError(ex, "BebraTemplate Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);

            throw;
        }
    }
}
