using Messenger.Entities.Users;

namespace Messenger.Entities.Queues.Users
{
    public sealed class UserInQueueItem : IInQueueItem<User, UserInQueueCommand, UserInQueueCommandType> 
    {
        public UserInQueueItem(UserInQueueCommand command, User payload)
        {
            Command = command;
            PayLoad = payload;
        }

        public UserInQueueCommand Command { get; }
        public User PayLoad { get; }
    }
}
