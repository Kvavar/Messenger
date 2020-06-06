namespace Messenger.Entities.Queues.Users
{
    public sealed class UserInQueueCommand : IInQueueCommand<UserInQueueCommandType>
    {
        public UserInQueueCommand(UserInQueueCommandType type)
        {
            Type = type;
        }

        public UserInQueueCommandType Type { get ; }
    }
}
