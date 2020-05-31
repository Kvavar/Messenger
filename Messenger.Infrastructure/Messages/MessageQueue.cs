using System;

namespace Messenger.Infrastructure.Messages
{
    public class MessageQueue : IMessageQueue
    {
        public MessageQueueItem Dequeue()
        {
            throw new NotImplementedException();
        }

        public void Enqueue(MessageQueueItem item)
        {
            throw new NotImplementedException();
        }
    }
}
