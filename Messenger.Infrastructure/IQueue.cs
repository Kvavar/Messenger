namespace Messenger.Infrastructure
{
    public interface IQueue<T> where T : IQueueItem
    {
        void Enqueue(T message);

        T Dequeue();
    }
}
