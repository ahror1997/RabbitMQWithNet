namespace RabbitMQWithNet.Services.RabbitMQService
{
    public interface IRabbitMQService
    {
        public void SendProductMessage<T>(T message);
    }
}
