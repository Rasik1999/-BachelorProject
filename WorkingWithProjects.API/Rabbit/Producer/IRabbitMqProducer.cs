namespace WorkingWithProjects.API.Rabbit
{
    public interface IRabbitMqProducer<in T>
    {
        void Publish(T @event);
    }
}
