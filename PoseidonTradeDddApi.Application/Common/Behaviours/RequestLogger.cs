using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Common.Behaviours
{
    /// <summary>
    /// Custom MediatR request pipeline/filter.
    /// Gets executed before the request is processed.
    /// Request and User Details get logged
    /// https://github.com/jbogard/MediatR/wiki/Behaviors
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        private readonly ICurrentUserService _currentUserService;

        public RequestLogger(ILogger<TRequest> logger, ICurrentUserService currentUserService)
        {
            _logger = logger;
            _currentUserService = currentUserService;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var requestFullName = typeof(TRequest).FullName;

            _logger.LogInformation($"request:{requestName};userId:{_currentUserService.UserName};fullRequestName:{requestFullName}");
        }
    }
}
