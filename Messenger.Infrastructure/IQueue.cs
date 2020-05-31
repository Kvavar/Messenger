using System.Threading.Tasks;

namespace Messenger.Infrastructure
{
    public interface IQueue<T> where T : IQueueItem
    {
        void Enqueue(T item);

        Task<T> Dequeue();
    }
}
