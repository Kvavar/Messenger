using System;
using System.Threading.Tasks;

namespace Messenger.Infrastructure.Messages
{
    public class MessageQueue : IMessageQueue
    {
        public Task<MessageQueueItem> Dequeue()
        {
            throw new NotImplementedException();
        }

        public void Enqueue(MessageQueueItem item)
        {
            throw new NotImplementedException();
        }
    }
}
