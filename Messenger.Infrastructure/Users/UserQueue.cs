using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Azure.Storage.Queues;
using Messenger.Entities.Queues.Users;
using Messenger.Infrastructure.Configuration.Options;
using Newtonsoft.Json;

namespace Messenger.Infrastructure.Users
{
    public class UserQueue : IUserQueue
    {
        private readonly QueueClient _inQueueClient;
        private readonly QueueClient _outQueueClient;

        public UserQueue(IOptions<UserQueueOptions> options)
        {
            var connectionString = options.Value.ConnectionString;
            if(string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException($"{nameof(connectionString)}");
            }

            var inQueueName = options.Value.InQueueName;
            if (string.IsNullOrWhiteSpace(inQueueName))
            {
                throw new ArgumentException($"{nameof(inQueueName)}");
            }

            var outQueueName = options.Value.OutQueueName;
            if (string.IsNullOrWhiteSpace(outQueueName))
            {
                throw new ArgumentException($"{nameof(outQueueName)}");
            }

            _inQueueClient = new QueueClient(connectionString, inQueueName);
            _inQueueClient.Create();

            _outQueueClient = new QueueClient(connectionString, outQueueName);
            _outQueueClient.Create();
        }

        public async Task<UserOutQueueItem> Dequeue()
        {
            if (!_outQueueClient.Exists())
            {
                throw new InvalidOperationException("User outqueue client does not exist.");
            }

            var result = await _outQueueClient.ReceiveMessagesAsync();
            var message = result.Value.FirstOrDefault();
            if (message == null)
            {
                throw new NullReferenceException(nameof(message));
            }

            _outQueueClient.DeleteMessage(message.MessageId, message.PopReceipt);

            return new UserOutQueueItem(true, message.MessageText);
        }

        public async void Enqueue(UserInQueueItem item)
        {
            if (!_inQueueClient.Exists())
            {
                throw new InvalidOperationException("User inqueue client does not exist.");
            }

            var message = JsonConvert.SerializeObject(item);

            await _inQueueClient.SendMessageAsync(message);
        }
    }
}
