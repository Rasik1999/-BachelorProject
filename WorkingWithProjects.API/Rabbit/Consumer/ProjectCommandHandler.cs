using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace WorkingWithProjects.API.Rabbit.Consumer
{
    public class ProjectCommandHandler : IRequestHandler<ProjectConsumerModel>
    {
        private readonly ILogger<ProjectCommandHandler> _logger;

        public ProjectCommandHandler(ILogger<ProjectCommandHandler> logger) => _logger = logger;

        public Task<Unit> Handle(ProjectConsumerModel request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("---- Received message: {Message} ----", request.ProjectId);
            return Task.FromResult(Unit.Value);
        }
    }
}
