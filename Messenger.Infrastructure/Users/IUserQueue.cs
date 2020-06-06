using Messenger.Entities.Queues;
using Messenger.Entities.Queues.Users;
using Messenger.Entities.Users;

namespace Messenger.Infrastructure.Users
{
    public interface IUserQueue : IQueue<UserInQueueItem, UserOutQueueItem, User, OutQueueResponse, UserInQueueCommand, UserInQueueCommandType>
    {
    }
}
