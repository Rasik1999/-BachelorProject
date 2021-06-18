using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Rabbit
{
    public class ProjectProducer : ProducerBase<Project>
    {
        public ProjectProducer(
            ConnectionFactory connectionFactory,
            ILogger<RabbitMqClientBase> logger,
            ILogger<ProducerBase<Project>> producerBaseLogger) :
            base(connectionFactory, logger, producerBaseLogger)
        {
        }

        protected override string ExchangeName => "CUSTOM_HOST.LoggerExchange";
        protected override string RoutingKeyName => "log.message";
        protected override string AppId => "LogProducer";
    }
}
