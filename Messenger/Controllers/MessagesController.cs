using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Messenger.Infrastructure.Users;
using Messenger.Infrastructure.Messages;
using Messenger.Entities;
using Messenger.Entities.Queues.Users;
using Messenger.Entities.Users;

namespace Messenger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IUserQueue _usersQueue;
        private readonly IMessageQueue _messegesQueue;

        public MessagesController(IUserQueue usersQueue, IMessageQueue messegesQueue)
        {
            _usersQueue = usersQueue;
            _messegesQueue = messegesQueue;
        }

        [HttpPost("send")]
        public async Task<ActionResult> Send(long senderId, long receiverId, [FromBody] Message message)
        {
            var user = new User("test", "test@test.org");
            var command = new UserInQueueCommand(UserInQueueCommandType.Create);
            _usersQueue.Enqueue(new UserInQueueItem(command, user));//check user
            var result = await _usersQueue.Dequeue();
            
            return Accepted(result);
        }
    }
}
