namespace Messenger.Entities.Queues
{
    public interface IInQueueItem<TPayLoad, TCommand, TCommandType> 
        where TPayLoad : IPayLoad
        where TCommand : IInQueueCommand<TCommandType>
        where TCommandType : struct
    {
        public TCommand Command { get; }
        public TPayLoad PayLoad { get; }
    }
}