namespace Messenger.Infrastructure.Users
{
    public class UserQueue : IUserQueue
    {
        public UserQueueItem Dequeue()
        {
            throw new System.NotImplementedException();
        }

        public void Enqueue(UserQueueItem message)
        {
            throw new System.NotImplementedException();
        }
    }
}
