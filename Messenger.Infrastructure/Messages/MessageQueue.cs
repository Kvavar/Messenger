using System;

namespace Messenger.Infrastructure.Messages
{
    public class QueueMessage : IMessageQueue
    {
        public MessageQueueItem Dequeue()
        {
            throw new NotImplementedException();
        }

        public void Enqueue(MessageQueueItem message)
        {
            throw new NotImplementedException();
        }
    }
}
