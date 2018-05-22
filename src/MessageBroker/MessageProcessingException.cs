using System;

namespace MessageBroker
{
  public class MessageProcessingException : ApplicationException
  {
    public MessageProcessingException(string message) : base(message)
    {

    }
  }
}
