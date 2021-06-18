using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Rabbit
{
    public class ProjectBackgroundTask : BackgroundService
    {
        private readonly IRabbitMqProducer<Project> _producer;
        public Project Project;

        public ProjectBackgroundTask(IRabbitMqProducer<Project> producer) => _producer = producer;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var @event = this.Project ?? new Project();

                _producer.Publish(@event);
                await Task.Delay(20000, stoppingToken);
            }

            await Task.CompletedTask;
        }
    }
}
