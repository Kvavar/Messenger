using System.Threading.Tasks;
using Messenger.Entities.Queues;

namespace Messenger.Infrastructure
{
    public interface IQueue<TInQueueItem, TOutQueueItem, TInPayLoad, TOutPayLoad, TCommand, TCommandType> 
        where TInQueueItem : IInQueueItem<TInPayLoad, TCommand, TCommandType>
        where TOutQueueItem : IOutQueueItem<TOutPayLoad>
        where TInPayLoad : IPayLoad
        where TOutPayLoad : IPayLoad
        where TCommand : IInQueueCommand<TCommandType>
        where TCommandType : struct
    {
        void Enqueue(TInQueueItem item);

        Task<TOutQueueItem> Dequeue();
    }
}
