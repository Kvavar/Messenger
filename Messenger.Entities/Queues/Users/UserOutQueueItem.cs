namespace Messenger.Entities.Queues.Users
{
    public sealed class UserOutQueueItem : IOutQueueItem<OutQueueResponse>
    {
        public UserOutQueueItem(bool success, string content)
        {
            Success = success;
            PayLoad = new OutQueueResponse(content);
        }

        public bool Success { get; }

        public OutQueueResponse PayLoad { get; }
    }
}
