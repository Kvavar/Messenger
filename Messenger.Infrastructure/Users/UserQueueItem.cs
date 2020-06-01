namespace Messenger.Infrastructure.Users
{
    public class UserQueueItem : IQueueItem
    {
        public UserQueueItem(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}
