using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Azure.Storage.Queues;
using Messenger.Infrastructure.Configuration.Options;
using System.Linq;

namespace Messenger.Infrastructure.Users
{
    public class UserQueue : IUserQueue
    {
        private readonly QueueClient _queueClient;

        public UserQueue(IOptions<UserQueueOptions> options)
        {
            var connectionString = options.Value.ConnectionString;
            if(string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException($"{nameof(connectionString)}");
            }

            var name = options.Value.Name;
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"{nameof(name)}");
            }

            _queueClient = new QueueClient(connectionString, name);
            _queueClient.Create();
        }

        public async Task<UserQueueItem> Dequeue()
        {
            if (!_queueClient.Exists())
            {
                throw new InvalidOperationException("User queue client does not exist.");
            }

            var result = await _queueClient.ReceiveMessagesAsync();
            var message = result.Value.FirstOrDefault();
            if(message == null)
            {
                throw new NullReferenceException(nameof(message));
            }

            _queueClient.DeleteMessage(message.MessageId, message.PopReceipt);

            return new UserQueueItem(message.MessageText);
        }

        public async void Enqueue(UserQueueItem message)
        {
            if(!_queueClient.Exists())
            {
                throw new InvalidOperationException("User queue client does not exist.");
            }

            await _queueClient.SendMessageAsync(message.Value);
        }
    }
}
