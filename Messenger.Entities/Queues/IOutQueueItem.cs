namespace Messenger.Entities.Queues
{
    public interface IOutQueueItem<TPayLoad> where TPayLoad : IPayLoad
    {
        public bool Success { get; }
        public TPayLoad PayLoad { get; }
    }
}
