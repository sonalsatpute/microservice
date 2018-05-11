namespace MessageBroker
{
  public interface IConnection
  {
    bool Connect();
    void Publish<T>(string routingKey, T message) where T : class;
    void Subscribe(string queueName, MessageHandler handler);
  }
}