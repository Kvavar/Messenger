using System;

namespace Messenger.Entities.Queues
{
    public sealed class OutQueueResponse : IPayLoad
    {
        public OutQueueResponse(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentException(nameof(content));
            }

            Content = content;
        }

        public string Content { get; }
    }
}
