using MediatR;
using Microsoft.Extensions.Logging;

namespace EventManagment.Application.Behaviours
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly ILogger<TRequest> _logger;
        public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exceptions.ValidationException)
            {
                throw;
            }
            catch (Exceptions.ApiException)
            {
                throw;
            }
            catch (Exception ex)
            {
                var exMsg = $"Unhandled Exception for Request {typeof(TRequest).Name}";
                _logger.LogError(ex, exMsg);
                throw new Exception("Unhandled Exception for Request");
            }
        }
    }
}
