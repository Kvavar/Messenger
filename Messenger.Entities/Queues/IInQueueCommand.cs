namespace Messenger.Entities.Queues
{
    public interface IInQueueCommand<T> where T : struct
    {
        public T Type { get; }
    }
}