using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Common.Behaviours
{
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
